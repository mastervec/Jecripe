using UnityEngine;
using System.Collections.Generic;

public enum eEndPointsMode
{
    AUTO = 0,
    AUTOCLOSED = 1,
    EXPLICIT = 2
}

public enum eWrapMode
{
    ONCE = 0,
    LOOP = 1
}

[System.Serializable]
public class SplineNode : object
{
    public Vector3 Point;
    public Quaternion Rot;
    public float Time;
    public Vector2 EaseIO;
    public SplineNode(Vector3 p, Quaternion q, float t, Vector2 io)
    {
        this.Point = p;
        this.Rot = q;
        this.Time = t;
        this.EaseIO = io;
    }

    public SplineNode(SplineNode o)
    {
        this.Point = o.Point;
        this.Rot = o.Rot;
        this.Time = o.Time;
        this.EaseIO = o.EaseIO;
    }

}
[System.Serializable]
public partial class SplineInterpolator : MonoBehaviour
{
    private eEndPointsMode mEndPointsMode;
    public float speedFactor;
    private List<SplineNode> mNodes;
    private string mState;
    private bool mRotations;
    private object mOnEndCallback;
    public virtual void Awake()
    {
        this.Reset();
    }

    public virtual void StartInterpolation(object endCallback, bool bRotations, eWrapMode mode)
    {
        if (this.mState != "Reset")
        {
            throw new System.Exception("First reset, add points and then call here");
        }
        this.mState = mode == eWrapMode.ONCE ? "Once" : "Loop";
        this.mRotations = bRotations;
        this.mOnEndCallback = endCallback;
        this.SetInput();
    }

    public virtual void Reset()
    {
        this.mNodes = new List<SplineNode>();
        this.mState = "Reset";
        this.mCurrentIdx = 1;
        this.mCurrentTime = 0f;
        this.mRotations = false;
        this.mEndPointsMode = eEndPointsMode.AUTO;
    }

    public virtual void AddPoint(Vector3 pos, Quaternion quat, float timeInSeconds, Vector2 easeInOut)
    {
        if (this.mState != "Reset")
        {
            throw new System.Exception("Cannot add points after start");
        }
        this.mNodes.Add(new SplineNode(pos, quat, timeInSeconds, easeInOut));
    }

    public virtual void SetInput()
    {
        if (this.mNodes.Count < 2)
        {
            throw new System.Exception("Invalid number of points");
        }
        if (this.mRotations)
        {
            int c = 1;
            while (c < this.mNodes.Count)
            {
                 // Always interpolate using the shortest path -> Selective negation
                if (Quaternion.Dot(this.mNodes[c].Rot, this.mNodes[c - 1].Rot) < 0)
                {

                    {
                        float _68 = -this.mNodes[c].Rot.x;
                        SplineNode _69 = this.mNodes[c];
                        Quaternion _70 = _69.Rot;
                        _70.x = _68;
                    }

                    {
                        float _71 = -this.mNodes[c].Rot.y;
                        SplineNode _72 = this.mNodes[c];
                        Quaternion _73 = _72.Rot;
                        _73.y = _71;
                    }

                    {
                        float _74 = -this.mNodes[c].Rot.z;
                        SplineNode _75 = this.mNodes[c];
                        Quaternion _76 = _75.Rot;
                        _76.z = 0;
                    }

                    {
                        float _77 = -this.mNodes[c].Rot.w;
                        SplineNode _78 = this.mNodes[c];
                        Quaternion _79 = _78.Rot;
                        _79.w = 0;
                    }
                }
                c++;
            }
        }
        if (this.mEndPointsMode == eEndPointsMode.AUTO)
        {
            this.mNodes.Insert(0,this.mNodes[0]);
            this.mNodes.Add(this.mNodes[this.mNodes.Count - 1]);
        }
        else
        {
            if ((this.mEndPointsMode == eEndPointsMode.EXPLICIT) && (this.mNodes.Count < 4))
            {
                throw new System.Exception("Invalid number of points");
            }
        }
    }

    public virtual void SetExplicitMode()
    {
        if (this.mState != "Reset")
        {
            throw new System.Exception("Cannot change mode after start");
        }
        this.mEndPointsMode = eEndPointsMode.EXPLICIT;
    }

    //public virtual void SetAutoCloseMode(float joiningPointTime)
    //{
    //    if (this.mState != "Reset")
    //    {
    //        throw new System.Exception("Cannot change mode after start");
    //    }
    //    this.mEndPointsMode = eEndPointsMode.AUTOCLOSED;

    //    this.mNodes.Add(this.gameObject.AddComponent(Types.GetType(this.mNodes[0])) as SplineNode);
    //    this.mNodes[this.mNodes.Count - 1].Time = joiningPointTime;

    //    Vector3 vInitDir = (this.mNodes[1].Point - this.mNodes[0].Point).normalized;
    //    Vector3 vEndDir = (this.mNodes[this.mNodes.Count - 2].Point - this.mNodes[this.mNodes.Count - 1].Point).normalized;
    //    float firstLength = (float) (this.mNodes[1].Point - this.mNodes[0].Point).magnitude;
    //    float lastLength = (float) (this.mNodes[this.mNodes.Count - 2].Point - this.mNodes[this.mNodes.Count - 1].Point).magnitude;

    //    SplineNode firstNode = (this.gameObject.addComponent < SplineNode) > this.mNodes[0] as SplineNode;
    //    firstNode.Point = ((Vector3) this.mNodes[0].Point) + (vEndDir * firstLength);

    //    SplineNode lastNode = (this.gameObject.addComponent < SplineNode) > this.mNodes[this.mNodes.Count - 1] as SplineNode;
    //    lastNode.Point = ((Vector3) this.mNodes[0].Point) + (vInitDir * lastLength);
    //    this.mNodes.Insert(0, firstNode);
    //    this.mNodes.Add(lastNode);
    //}

    private float mCurrentTime;
    private int mCurrentIdx;
    public virtual void Update()
    {
        if (((this.mState == "Reset") || (this.mState == "Stopped")) || (this.mNodes.Count < 4))
        {
            return;
        }
        this.mCurrentTime = this.mCurrentTime + (Time.deltaTime * this.speedFactor);
        // We advance to next point in the path
        if (this.mCurrentTime >= this.mNodes[this.mCurrentIdx + 1].Time)
        {
            if (this.mCurrentIdx < (this.mNodes.Count - 3))
            {
                this.mCurrentIdx++;
            }
            else
            {
                if (this.mState != "Loop")
                {
                    this.mState = "Stopped";
                    // We stop right in the end point
                    this.transform.position = this.mNodes[this.mNodes.Count - 2].Point;
                    if (this.mRotations)
                    {
                        this.transform.rotation = this.mNodes[this.mNodes.Count - 2].Rot;
                    }
                    // We call back to inform that we are ended
                    if (!(this.mOnEndCallback == null))
                    {
                        this.StopAllCoroutines();
                    }
                }
                else
                {
                    this.mCurrentIdx = 1;
                    this.mCurrentTime = 0f;
                }
            }
        }
        // Debug.Log(speedFactor);
        if (this.mState != "Stopped")
        {
             // Calculates the t param between 0 and 1
            float param = (float) ((this.mCurrentTime - (float) this.mNodes[this.mCurrentIdx].Time) / (this.mNodes[this.mCurrentIdx + 1].Time - this.mNodes[this.mCurrentIdx].Time));
            // Smooth the param
            param = JecripeUtils.MathUtils.Ease(param, (float) this.mNodes[this.mCurrentIdx].EaseIO.x, (float) this.mNodes[this.mCurrentIdx].EaseIO.y);
            this.transform.position = this.GetHermiteInternal(this.mCurrentIdx, param);
            if (this.mRotations)
            {
                this.transform.rotation = this.GetSquad(this.mCurrentIdx, param);
                this.transform.rotation.SetAxisAngle(Vector3.forward,0);
            }
        }
    }

    public virtual Quaternion GetSquad(int idxFirstPoint, float t)
    {
        Quaternion Q0 = this.mNodes[idxFirstPoint - 1].Rot;
        Quaternion Q1 = this.mNodes[idxFirstPoint].Rot;
        Quaternion Q2 = this.mNodes[idxFirstPoint + 1].Rot;
        Quaternion Q3 = this.mNodes[idxFirstPoint + 2].Rot;
        Quaternion T1 = JecripeUtils.MathUtils.GetSquadIntermediate(Q0, Q1, Q2);
        Quaternion T2 = JecripeUtils.MathUtils.GetSquadIntermediate(Q1, Q2, Q3);
        return JecripeUtils.MathUtils.GetQuatSquad(t, Q1, Q2, T1, T2);
    }

    public virtual Vector3 GetHermiteInternal(int idxFirstPoint, float t)
    {
        float t2 = t * t;
        float t3 = t2 * t;
        Vector3 P0 = this.mNodes[idxFirstPoint - 1].Point;
        Vector3 P1 = this.mNodes[idxFirstPoint].Point;
        Vector3 P2 = this.mNodes[idxFirstPoint + 1].Point;
        Vector3 P3 = this.mNodes[idxFirstPoint + 2].Point;
        float tension = 0.5f; // 0.5 equivale a catmull-rom
        Vector3 T1 = tension * (P2 - P0);
        Vector3 T2 = tension * (P3 - P1);
        float Blend1 = ((2 * t3) - (3 * t2)) + 1;
        float Blend2 = (-2 * t3) + (3 * t2);
        float Blend3 = (t3 - (2 * t2)) + t;
        float Blend4 = t3 - t2;
        return (((Blend1 * P1) + (Blend2 * P2)) + (Blend3 * T1)) + (Blend4 * T2);
    }

    public virtual Vector3 GetHermiteAtTime(float timeParam)
    {
        if (timeParam >= this.mNodes[this.mNodes.Count - 2].Time)
        {
            return this.mNodes[this.mNodes.Count - 2].Point;
        }
        int c = 1;
        while (c < (this.mNodes.Count - 2))
        {
            if (this.mNodes[c].Time > timeParam)
            {
                break;
            }
            c++;
        }
        int idx = c - 1;
        float param = (float) ((timeParam - (float) this.mNodes[idx].Time) / (this.mNodes[idx + 1].Time - this.mNodes[idx].Time));
        param = JecripeUtils.MathUtils.Ease(param, (float) this.mNodes[idx].EaseIO.x, (float) this.mNodes[idx].EaseIO.y);
        return this.GetHermiteInternal(idx, param);
    }

    public SplineInterpolator()
    {
        this.mEndPointsMode = eEndPointsMode.AUTO;
        this.speedFactor = 1;
        this.mState = "";
        this.mCurrentIdx = 1;
    }

}
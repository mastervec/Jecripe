using UnityEngine;
using System.Collections.Generic;

public enum eOrientationMode
{
    NODE = 0,
    TANGENT = 1
}

// We need this to sort GameObjects by name
[System.Serializable]
[UnityEngine.AddComponentMenu("Splines/Spline Controller")]
public partial class SplineController : MonoBehaviour
{
    public GameObject SplineParent;
    public float Duration;
    public eOrientationMode OrientationMode;
    public eWrapMode WrapMode;
    public bool AutoStart;
    public bool AutoClose;
    public bool HideOnExecute;
    private SplineInterpolator mSplineInterp;
    private Transform[] mTransforms;
    public virtual SplineInterpolator Interpolator()
    {
        return this.mSplineInterp;
    }

    public virtual void OnDrawGizmos()
    {
        Transform[] trans = this.GetTransforms();
        if (trans.Length < 2)
        {
            return;
        }
        SplineInterpolator interp = new SplineInterpolator();
        this.SetupSplineInterpolator(interp, trans);
        interp.StartInterpolation(null, false, this.WrapMode);
        Vector3 prevPos = trans[0].position;
        var c = 1;
        while (c <= 100)
        {
            float currTime = (c * this.Duration) / 100f;
            Vector3 currPos = interp.GetHermiteAtTime(currTime);
            float mag = (currPos - prevPos).magnitude * 2f;
            Gizmos.color = new Color(mag, 0f, 0f, 1f);
            Gizmos.DrawLine(prevPos, currPos);
            prevPos = currPos;
            c++;
        }
    }

    public virtual void Start()
    {
        this.mSplineInterp = (SplineInterpolator) this.gameObject.AddComponent(typeof(SplineInterpolator));
        this.mTransforms = this.GetTransforms();
        if (this.HideOnExecute)
        {
            this.DisableTransforms();
        }
        if (this.AutoStart)
        {
            this.FollowSpline();
        }
    }

    public virtual void SetupSplineInterpolator(SplineInterpolator interp, Transform[] trans)
    {
        interp.Reset();
        float step;
        if (this.AutoClose)
        {
            step = this.Duration / trans.Length;
        }
        else
        {
            step = this.Duration / (trans.Length - 1);
        }
        int c = 0;
        while (c < trans.Length)
        {

            interp.AddPoint(trans[c].position, trans[c].rotation, step * c, new Vector2(0f, 1f));


            c++;
        }
        //if (this.AutoClose)
        //{
        //    interp.SetAutoCloseMode(step * c);
        //}
    }

    //
    // Returns children transforms already sorted by name
    //
    public virtual Transform[] GetTransforms()
    {
        List<Transform> ret = new List<Transform>();
        if (this.SplineParent != null)
        {
            // We need to use an ArrayList because there�s not Sort method in Array...
            List<Transform> tempTransformsArray = new List<Transform>();
            Component[] tempTransforms = this.SplineParent.GetComponentsInChildren(typeof(Transform));
            // We need to get rid of the parent, which is also returned by GetComponentsInChildren...
            foreach (Transform tr in tempTransforms)
            {
                if (tr != this.SplineParent.transform)
                {
                    tempTransformsArray.Add(tr);
                }
            }
            tempTransformsArray.Sort((Transform t1, Transform t2) => { return t1.name.CompareTo(t2.name); });
            ret = tempTransformsArray;
        }
        return ret.ToArray();
    }

    //
    // Disables the spline objects, we generally don't need them because they are just auxiliary
    //
    public virtual void DisableTransforms() //SplineParent.SetActiveRecursively(false);
    {
        if (this.SplineParent != null)
        {
        }
    }

    //
    // Starts the interpolation
    //
    public virtual void FollowSpline()
    {
        if (this.mTransforms.Length > 0)
        {
            this.SetupSplineInterpolator(this.mSplineInterp, this.mTransforms);
            this.mSplineInterp.StartInterpolation(null, true, this.WrapMode);
        }
    }

    public SplineController()
    {
        this.Duration = 10f;
        this.OrientationMode = eOrientationMode.NODE;
        this.WrapMode = eWrapMode.ONCE;
        this.AutoStart = true;
        this.AutoClose = true;
        this.HideOnExecute = true;
    }

}
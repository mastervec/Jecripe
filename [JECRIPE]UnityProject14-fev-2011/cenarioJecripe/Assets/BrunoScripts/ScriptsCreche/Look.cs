using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Look : MonoBehaviour
{
    public Transform target;
    private Quaternion originalRotation;
    private Vector3 dir;
    private Vector3 dir2;
    public virtual void Start()
    {
        this.originalRotation = this.transform.localRotation;
        this.dir = this.transform.TransformDirection(Vector3.up);
        this.dir2 = this.transform.TransformDirection(Vector3.left);
    }

    private bool lookOn;
    public virtual void LookOn(bool _state)
    {
        this.lookOn = _state;
    }

    public virtual void SetTarget(Transform _target)
    {
        this.target = _target;
    }

    public virtual void LateUpdate()//transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    {
        //var vetaux:Vector3 = target.position - transform.position;
        ///Debug.DrawRay(transform.position,vetaux* 10, Color.green);
        //this.transform.rotation.x += this.transform.rotation.x - vetaux.x;
        //Debug.Log(vetaux);
        Debug.DrawRay(this.transform.position, this.dir * 5, Color.white);
        //firstRotation = this.transform;
        //Debug.Log(Vector3.Angle(vetaux, transform.position.forward));
        //Debug.Log(firstRotation.rotation);
        //this.transform.rotation = Quaternion.Euler(90, 0,0);
        if (this.lookOn)
        {
            Vector3 auxVetx = this.target.position - this.transform.position;
            auxVetx.y = 0;
            //auxVetx.z = 0;
            //	Debug.DrawRay(transform.position,-auxVetx* 10, Color.blue);
            Vector3 auxVety = this.target.position - this.transform.position;
            auxVety.x = 0;
            //auxVety.z = 0;
            //	Debug.DrawRay(transform.position,auxVety*10, Color.green);
            //	Debug.Log(Vector3.Angle(dir, auxVetx));
            //	Debug.Log(Vector3.Angle(dir2, auxVety));
            Quaternion xQuaternion = Quaternion.AngleAxis(270 + Vector3.Angle(this.dir, auxVetx), Vector3.right);
            Quaternion yQuaternion = Quaternion.AngleAxis(((-90 + Vector3.Angle(this.dir2, auxVety)) / 2.5f) + 8, Vector3.up);
            this.transform.localRotation = (this.originalRotation * xQuaternion) * yQuaternion;
        }
    }

}
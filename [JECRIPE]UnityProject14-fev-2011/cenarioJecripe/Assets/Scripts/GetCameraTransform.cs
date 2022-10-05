using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GetCameraTransform : MonoBehaviour
{
    public Transform target;
    public virtual void Update()
    {
        this.transform.position = this.target.position;
        this.transform.rotation = this.target.rotation;
    }

}
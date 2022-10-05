using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class zzzTEST : MonoBehaviour
{
    public Transform pos;
    public virtual void Update()
    {
        this.transform.position = this.pos.position;
        this.transform.rotation = this.pos.rotation;
    }

}
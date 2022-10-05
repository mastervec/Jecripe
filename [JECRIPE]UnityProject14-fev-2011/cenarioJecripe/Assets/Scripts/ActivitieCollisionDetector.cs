using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ActivitieCollisionDetector : MonoBehaviour
{
    public virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("Chegou perto da Porta - OnTriggerEnter at ActivitieCollisionDetector");
        ((ActivitieEntrance) this.transform.parent.GetComponent(typeof(ActivitieEntrance))).enabled = true;
    }

}
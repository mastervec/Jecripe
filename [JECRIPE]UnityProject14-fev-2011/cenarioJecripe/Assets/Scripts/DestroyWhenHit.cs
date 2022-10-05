using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DestroyWhenHit : MonoBehaviour
{
    // Destroy everything that enters the trigger
    public virtual void OnTriggerExit(Collider other)
    {
        UnityEngine.Object.Destroy(other.gameObject);
    }

}
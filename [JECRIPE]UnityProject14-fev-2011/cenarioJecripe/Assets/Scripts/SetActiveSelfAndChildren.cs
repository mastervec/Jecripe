using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SetActiveSelfAndChildren : MonoBehaviour
{
    public bool isActive;
    public virtual void Update()
    {
        this.gameObject.SetActiveRecursively(this.isActive);
    }

}
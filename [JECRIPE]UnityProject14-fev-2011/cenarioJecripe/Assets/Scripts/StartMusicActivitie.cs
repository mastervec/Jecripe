using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class StartMusicActivitie : MonoBehaviour
{
    public virtual void Start()
    {
    }

    public virtual void TurnOff()
    {
        this.gameObject.SetActiveRecursively(false);
    }

}
using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PlayButtonHelper : MonoBehaviour
{
    public Transform playTranform;
    public virtual void OnMouseDown()
    {
        this.playTranform.GetComponent<PlayGameButton>().OnMouseDown();
    }

}
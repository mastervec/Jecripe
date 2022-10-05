using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CreditsScene : MonoBehaviour
{
    public virtual void Start()
    {
        GameObject gcaux = GameObject.Find("GameController");
        gcaux.GetComponent<AudioSource>().Stop();
    }

}
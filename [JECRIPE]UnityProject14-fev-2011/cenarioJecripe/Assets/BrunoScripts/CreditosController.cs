using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CreditosController : MonoBehaviour
{
    private GameObject gc;
    public virtual void Start()
    {
        gc = GameObject.Find("GameController");
        AudioSource audioSource = gc.GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        //this.gc.GetComponent("GUIFader").GUIFaderOut(0.3f, 1);
    }

}
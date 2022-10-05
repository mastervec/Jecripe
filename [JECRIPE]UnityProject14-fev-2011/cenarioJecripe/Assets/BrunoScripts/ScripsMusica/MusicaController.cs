using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MusicaController : MonoBehaviour
{
    private GameObject gc;
    public virtual void Start()
    {
        this.gc = GameObject.Find("GameController");
        if (this.gc)
        {
            if (!this.gc.GetComponent<AudioSource>().isPlaying)
            {
                this.gc.GetComponent<AudioSource>().Play();
            }
        }
        this.StartCoroutine(this.LoadInsideMusica());
    }

    public virtual IEnumerator LoadInsideMusica()
    {
        yield return new WaitForSeconds(10.1f);
        //if(gc) gc.GetComponent("GUIFader").GUIFaderIn(0.2,1);
        //yield WaitForSeconds(1.1);
        //Application.LoadLevel("CrecheInterna");
        Application.LoadLevel("MusicaInterna");
    }

}
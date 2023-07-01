using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BolhasController : MonoBehaviour
{
    public CameraFade fader;
    private GameObject gc;
    public virtual void Start()
    {
        this.gc = GameObject.Find("GameController");
        if (this.gc && (!this.gc.GetComponent<AudioSource>().isPlaying))
        {
            this.gc.GetComponent<AudioSource>().Play();
        }
        this.StartCoroutine(this.LoadInsideBolhas());
    }

    public virtual IEnumerator LoadInsideBolhas()
    {
        yield return new WaitForSeconds(5);
       
            fader.StartFade();
        
        yield return new WaitForSeconds(1.1f);
        //Application.LoadLevel("CrecheInterna");
        Application.LoadLevel("BolhasInterna");
    }

}
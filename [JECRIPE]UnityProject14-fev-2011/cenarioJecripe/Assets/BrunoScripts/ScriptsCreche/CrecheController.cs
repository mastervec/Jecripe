using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CrecheController : MonoBehaviour
{
    private GameObject gc;
    public virtual void Start()
    {
        this.gc = GameObject.Find("GameController");
        if (!this.gc.GetComponent<AudioSource>().isPlaying)
        {
            this.gc.GetComponent<AudioSource>().Play();
        }
        this.StartCoroutine(this.LoadInsideCreche());
    }

    public virtual IEnumerator LoadInsideCreche()
    {
        yield return new WaitForSeconds(5);
        if (this.gc)
        {
            //this.gc.GetComponent("GUIFader").GUIFaderIn(0.2f, 1);
        }
        yield return new WaitForSeconds(1.1f);
        Application.LoadLevel("CrecheInterna");
    }

}
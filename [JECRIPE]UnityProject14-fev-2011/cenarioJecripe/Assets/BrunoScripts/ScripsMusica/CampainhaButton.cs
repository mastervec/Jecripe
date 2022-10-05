using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CampainhaButton : MonoBehaviour
{
    public int maxClicks;
    public float offSetClickTime;
    public MusicaInsideController mc;
    private float offSetClickTimeAux;
    private int cliqueCount;
    public virtual void Start()
    {
         //offSetClickTimeAux = offSetClickTime;
        this.offSetClickTimeAux = 6.3f; // Primeiro momento proteger o clique enquanto rola a narra�ao 5seg de narra�ao ?
    }

    public virtual void OnMouseDown()
    {
        if ((this.cliqueCount < this.maxClicks) && (this.offSetClickTimeAux < 0))
        {
            this.GetComponent<AudioSource>().Play();
            this.cliqueCount = this.cliqueCount + 1;
            this.offSetClickTimeAux = this.offSetClickTime;
            if (this.cliqueCount == this.maxClicks)
            {
                this.StartCoroutine(this.ClickedEnough());
            }
        }
    }

    public virtual IEnumerator ClickedEnough()
    {
        this.mc.CampainhaFinished();
        yield return new WaitForSeconds(this.GetComponent<AudioSource>().clip.length);
        UnityEngine.Object.Destroy(this.gameObject);
    }

    public virtual void Update()
    {
        if (this.offSetClickTimeAux >= 0)
        {
            this.offSetClickTimeAux = this.offSetClickTimeAux - Time.deltaTime;
        }
    }

    public CampainhaButton()
    {
        this.maxClicks = 2;
        this.offSetClickTime = 1;
    }

}
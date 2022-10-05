using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class InsideCrecheController : MonoBehaviour
{
    public Transform cam;
    private GameObject gc;
    public virtual void Start()
    {
        this.gc = GameObject.Find("GameController");
        if (this.gc)
        {
            //this.gc.GetComponent("GUIFader").GUIFaderOut(0.2f, 1);
        }
        this.StartCoroutine(this.PlaySpline());
    }

    public virtual IEnumerator PlaySpline()
    {
        yield return new WaitForSeconds(1);
        this.cam.GetComponent<SplineControllerBruno>().PlayIt();
    }

}
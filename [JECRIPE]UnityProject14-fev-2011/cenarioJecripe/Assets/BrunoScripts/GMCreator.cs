using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GMCreator : MonoBehaviour
{
    public Transform gc;
    public Transform camPosition;
    public int frezzeSeconds;
    public virtual void Start()
    {
        if (!GameObject.Find("GameController"))
        {
            this.gc = UnityEngine.Object.Instantiate(this.gc);
            this.gc.name = "GameController";
            this.StartCoroutine(this.playAfterSeconds(this.frezzeSeconds));
            this.gc.GetComponent<GameController>().firstLoadOff();
            //this.gc.GetComponent("GUIFader").GUIFaderOut(0.3f, 1);
            this.gc.GetComponent<AudioSource>().ignoreListenerVolume = false;
        }
        else
        {
            this.transform.position = this.camPosition.position;
            this.transform.rotation = this.camPosition.rotation;
            GameObject gcaux = GameObject.Find("GameController");
            gcaux.GetComponent<GameController>().firstLoadMapOn(); // Faz o travel do mapa ocorrer novamente se voltar ate o menu
            //gcaux.GetComponent("GUIFader").GUIFaderOut(0.3f, 1);
            if (!gcaux.GetComponent<AudioSource>().isPlaying)
            {
                gcaux.GetComponent<AudioSource>().Play();
            }
        }
    }

    public virtual IEnumerator playAfterSeconds(int sec)
    {
        yield return new WaitForSeconds(sec);
        this.GetComponent<SplineControllerBruno>().PlayIt();
    }

    public GMCreator()
    {
        this.frezzeSeconds = 3;
    }

}
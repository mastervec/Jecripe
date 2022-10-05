using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MapController : MonoBehaviour
{
    public Transform cam;
    public Transform finalPosition;
    public PlayCrecheButton playCrecheButton;
    public PlayBolhasButton playBolhasButton;
    public PlayMusicaButton playMusicaButton;
    public GameObject cityIluminator;
    private bool lightTurnOff;
    private GameObject gc;
    public AudioSource travelSound;
    public AudioSource travelNarrationSound;
    public virtual void Start()
    {
        this.gc = GameObject.Find("GameController");
        if (!this.gc.GetComponent<AudioSource>().isPlaying)
        {
            this.gc.GetComponent<AudioSource>().Play();
        }
        //this.gc.GetComponent<GUIFader>().GUIFaderOut(0.3f, 1);
        if (this.gc.GetComponent<GameController>().checkFirstLoadMap())
        {
            this.StartCoroutine(this.PlaySpline());
            this.travelSound.Play();
            this.travelNarrationSound.Play();
            //cam.GetComponent("SplineControllerBruno").PlayIt();
            this.gc.GetComponent<GameController>().firstLoadMapOff();
        }
        else
        {
            this.cam.position = this.finalPosition.transform.position;
            this.cam.rotation = this.finalPosition.transform.rotation;
            UnityEngine.Object.Destroy(this.cityIluminator);
        }
    }

    public virtual IEnumerator PlaySpline()
    {
        this.playCrecheButton.disabledButton = true;
        this.playBolhasButton.disabledButton = true;
        this.playMusicaButton.disabledButton = true;
        yield return new WaitForSeconds(1);
        this.cam.GetComponent<SplineControllerBruno>().PlayIt();
        while ((this.cam.position - this.finalPosition.position).sqrMagnitude > 0.3f)
        {
            yield return new WaitForSeconds(0.2f);
        }
        this.playCrecheButton.disabledButton = false;
        this.playBolhasButton.disabledButton = false;
        this.playMusicaButton.disabledButton = false;
        this.lightTurnOff = true;
    }

    public virtual void Update()
    {
        if (this.lightTurnOff)
        {
            this.cityIluminator.GetComponent<Light>().intensity = ((float) this.cityIluminator.GetComponent<Light>().intensity) - Time.deltaTime;
            if (this.cityIluminator.GetComponent<Light>().intensity <= 0)
            {
                this.lightTurnOff = false;
                UnityEngine.Object.Destroy(this.cityIluminator);
            }
        }
    }

}
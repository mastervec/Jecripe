using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BubbleBlowerAssemble : MonoBehaviour
{
    public BBPiecesController BBPieces;
    public Transform TargetPos;
    public Transform animationPosition;
    public GameObject wallColliders;
    public AudioClip DingSound;
    public AudioClip agoraVouMostrar;
    public AudioClip facaJuntoComigo;
    public AudioClip olheBemDentro;
    public AudioClip otimoVcEstaConseguindo;
    public AudioClip soprandoMuitoBem;
    public AudioClip aguaMisturando;
    public AudioClip sabaoMisturando;
    public AudioClip tampaFechando;
    public AudioClip passeAMaoNaTampa;
    public float SpeechDeltaTime;
    public Grabber aguaGrabber;
    public Grabber sabaoGrabber;
    public Grabber tampaGrabber;
    private int count;
    private float delay;
    private AudioSource mAudio;
    private GameObject gc;
    public virtual void Start()// FIM Para Testes
    {
        this.mAudio = (AudioSource) this.GetComponent(typeof(AudioSource));
    }

    public virtual IEnumerator OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "WaterBottle":
                //Destroy(other.rigidbody);
                other.GetComponent<BoxCollider>().enabled = false;
                BBPieces.isDraggingWater = false;

                {
                    Vector3 _80 = this.animationPosition.transform.position;
                    Transform _81 = other.transform;
                    _81.position = _80;
                }
                other.GetComponent<Animation>().Play();
                this.mAudio.clip = this.aguaMisturando;
                this.mAudio.Play();
                yield return new WaitForSeconds(((float) other.GetComponent<Animation>().clip.length) + this.delay);
                UnityEngine.Object.Destroy(other.gameObject);
                this.count++;
                break;
            case "SoapBottle":
                Debug.Log("switch");
                //Destroy(other.rigidbody);
                other.GetComponent<BoxCollider>().enabled = false;
                BBPieces.isDraggingSoap = false;

                {
                    Vector3 _82 = this.animationPosition.position;
                    Transform _83 = other.transform;
                    _83.position = _82;
                }
                other.GetComponent<Animation>().Play();
                this.mAudio.clip = this.sabaoMisturando;
                this.mAudio.Play();
                yield return new WaitForSeconds(((float) other.GetComponent<Animation>().clip.length) + this.delay);
                UnityEngine.Object.Destroy(other.gameObject);
                this.mAudio.clip = this.passeAMaoNaTampa;
                this.mAudio.Play();
                yield return new WaitForSeconds(other.GetComponent<Animation>().clip.length);
                this.count++;
                break;
            case "LastPiece":
                //Destroy(other.rigidbody);
                other.GetComponent<BoxCollider>().enabled = false;
                BBPieces.isDraggingLastPiece = false;

                {
                    Vector3 _84 = this.animationPosition.position;
                    Transform _85 = other.transform;
                    _85.position = _84;
                }
                other.GetComponent<Animation>().Play();
                this.mAudio.clip = this.tampaFechando;
                this.mAudio.Play();
                yield return new WaitForSeconds(((float) other.GetComponent<Animation>().clip.length) + this.delay);
                this.count++;
                break;
        }
    }

    /*function OnGUI() {
	GUI.Label(Rect(10, 10, 200, 30), "count: "+count);
}*/
    public virtual void Update()
    {
        if (this.enabled)
        {
            if (this.aguaGrabber)
            {
                this.aguaGrabber.enabled = true;
            }
            if (this.sabaoGrabber)
            {
                this.sabaoGrabber.enabled = true;
            }
            if (this.tampaGrabber)
            {
                this.tampaGrabber.enabled = true;
            }
        }
        if (this.count == 1)
        {
            BBPieces.canDragSoapBottle = true;
        }
        else
        {
            if (this.count == 2)
            {
                BBPieces.canDragLastPiece = true;
            }
            else
            {
                if (this.count == 3)
                {
                    this.StartCoroutine("StartBlowingBubbles");
                    this.enabled = false;
                }
            }
        }
    }

    public virtual IEnumerator StartBlowingBubbles()
    {
        yield return new WaitForSeconds(1f);
        GameObject cam = GameObject.Find("Main Camera");
        ((SplineController) cam.GetComponent(typeof(SplineController))).SplineParent = GameObject.Find("CameraPosAfterAssemble");
        GameObject focus = GameObject.Find("Focus");
        ((SplineController)focus.GetComponent(typeof(SplineController))).SplineParent = GameObject.Find("FocusPosAfterAssemble");
        this.wallColliders.SetActiveRecursively(true);
        //mAudio.Play();
        //yield WaitForSeconds(mAudio.clip.length);
        this.mAudio.clip = this.DingSound;
        this.mAudio.Play();
        ((SplineController) cam.GetComponent(typeof(SplineController))).Start();
        ((SplineController) cam.GetComponent(typeof(SplineController))).FollowSpline();
        ((SplineController)focus.GetComponent(typeof(SplineController))).Start();
        ((SplineController)focus.GetComponent(typeof(SplineController))).FollowSpline();
        this.transform.position = this.TargetPos.transform.position;
        yield return new WaitForSeconds(((SplineController) cam.GetComponent(typeof(SplineController))).Duration);
        this.mAudio.clip = this.agoraVouMostrar;
        this.mAudio.Play();
        yield return new WaitForSeconds(this.mAudio.clip.length);
        this.mAudio.clip = this.facaJuntoComigo;
        this.mAudio.Play();
        yield return new WaitForSeconds(this.mAudio.clip.length / 2);
        ((BubbleBlowerBehaviour) this.GetComponent(typeof(BubbleBlowerBehaviour))).enabled = true;
        yield return new WaitForSeconds(this.mAudio.clip.length / 2);
        yield return new WaitForSeconds(this.SpeechDeltaTime);
        this.mAudio.clip = this.olheBemDentro;
        this.mAudio.Play();
        yield return new WaitForSeconds(this.mAudio.clip.length);
        yield return new WaitForSeconds(this.SpeechDeltaTime);
        this.mAudio.clip = this.otimoVcEstaConseguindo;
        this.mAudio.Play();
        yield return new WaitForSeconds(this.mAudio.clip.length);
        yield return new WaitForSeconds(this.SpeechDeltaTime);
        this.mAudio.clip = this.soprandoMuitoBem;
        this.mAudio.Play();
        yield return new WaitForSeconds(this.mAudio.clip.length);
    }

    public BubbleBlowerAssemble()
    {
        this.SpeechDeltaTime = 2f;
        this.delay = 0.5f;
    }

}
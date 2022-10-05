using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public partial class PlayGameButton : MonoBehaviour
{
    public Transform cameraRef;
    public GameObject pathToTravel;
    public int secondsToChange;
    public Transform ExitButton;
    public Transform CreditsButton;
    public Transform Credits2Button;
    public Transform PlayCollider;
    public AudioClip EnrolaAClip;
    public AudioClip DesenrolaAClip;
    private GameObject gc;
    private bool playPressed;
    public AudioSource narrationSound;
    public virtual void OnMouseDown()
    {
        this.narrationSound.Stop();
        this.cameraRef.GetComponent<SplineControllerBruno>().changePath(this.pathToTravel);
        this.cameraRef.GetComponent<SplineControllerBruno>().PlayIt();
        UnityEngine.Object.Destroy(this.GetComponent<Collider>());
        UnityEngine.Object.Destroy(this.PlayCollider.GetComponent<Collider>());
        UnityEngine.Object.Destroy(this.ExitButton.GetComponent<Collider>());
        UnityEngine.Object.Destroy(this.CreditsButton.GetComponent<Collider>());
        UnityEngine.Object.Destroy(this.Credits2Button.GetComponent<Collider>());
        this.playPressed = true;
        this.GetComponent<Animation>().Rewind();
        this.GetComponent<Animation>().Stop();
        //animation["Take 001"].time = 0;
        this.StartCoroutine(this.LoadMap());
    }

    public virtual void OnMouseEnter()
    {
        this.GetComponent<Animation>()["Take 001"].speed = 1;
        //Debug.Log("time: "+animation["Take 001"].time+ "normalizedTime: "+animation["Take 001"].normalizedTime);
        if (this.GetComponent<Animation>()["Take 001"].normalizedTime < -1)
        {
            this.GetComponent<Animation>().Rewind();
        }
        this.GetComponent<AudioSource>().Stop();
        this.GetComponent<AudioSource>().clip = this.EnrolaAClip;
        this.GetComponent<AudioSource>().Play();
        this.GetComponent<Animation>().Play();
        var increase = true;
    }

    public virtual void OnMouseExit()
    {
        if (!this.GetComponent<Animation>().isPlaying)
        {
            this.GetComponent<Animation>().Play();
            this.GetComponent<Animation>()["Take 001"].normalizedTime = 1;
        }
        this.GetComponent<Animation>()["Take 001"].speed = -1;
        this.GetComponent<AudioSource>().Stop();
        this.GetComponent<AudioSource>().clip = this.DesenrolaAClip;
        this.GetComponent<AudioSource>().Play();
    }

    public virtual IEnumerator LoadMap()
    {
        yield return new WaitForSeconds(this.secondsToChange - 1);
        //GameObject.Find("GameController").GetComponent("GUIFader").GUIFaderIn(1, 1);
        yield return new WaitForSeconds(1);
        Debug.Log("carregando mapa");
        SceneManager.LoadScene("mapa");
    }

    public PlayGameButton()
    {
        this.secondsToChange = 2;
    }

}
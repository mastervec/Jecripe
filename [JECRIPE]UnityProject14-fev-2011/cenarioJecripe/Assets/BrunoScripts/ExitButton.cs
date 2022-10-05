using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ExitButton : MonoBehaviour
{
    public Animation animationToHandle;
    public Transform PlayButton;
    public Transform CreditsButton;
    public Transform Credits2Button;
    public Transform Play2Collider;
    private GameObject gc;
    public AudioSource narrationSound;
    public virtual void OnMouseDown()
    {
        this.narrationSound.Stop();
        UnityEngine.Object.Destroy(this.GetComponent<Collider>());
        UnityEngine.Object.Destroy(this.PlayButton.GetComponent<Collider>());
        UnityEngine.Object.Destroy(this.Play2Collider.GetComponent<Collider>());
        UnityEngine.Object.Destroy(this.CreditsButton.GetComponent<Collider>());
        UnityEngine.Object.Destroy(this.Credits2Button.GetComponent<Collider>());
        this.animationToHandle.GetComponent<Animation>().Rewind();
        this.animationToHandle.GetComponent<Animation>().Stop();
        //animation["Take 001"].time = 0;
        this.StartCoroutine(this.LoadExit());
    }

    public virtual void OnMouseEnter()
    {
        this.GetComponent<AudioSource>().Play();
        this.animationToHandle.GetComponent<Animation>()["Take 001"].speed = 1;
        //Debug.Log("time: "+animation["Take 001"].time+ "normalizedTime: "+animation["Take 001"].normalizedTime);
        if (this.animationToHandle.GetComponent<Animation>()["Take 001"].normalizedTime < -1)
        {
            this.animationToHandle.GetComponent<Animation>().Rewind();
        }
        this.animationToHandle.GetComponent<Animation>().Play();
    }

    public virtual void OnMouseExit()
    {
        if (!this.animationToHandle.GetComponent<Animation>().isPlaying)
        {
            this.animationToHandle.GetComponent<Animation>().Play();
            this.animationToHandle.GetComponent<Animation>()["Take 001"].normalizedTime = 1;
        }
        this.animationToHandle.GetComponent<Animation>()["Take 001"].speed = -1;
    }

    public virtual IEnumerator LoadExit()
    {
        //GameObject.Find("GameController").GetComponent("GUIFader").GUIFaderIn(0, 1);
        yield return new WaitForSeconds(1);
        Application.LoadLevel("Encerramento");
    }

}
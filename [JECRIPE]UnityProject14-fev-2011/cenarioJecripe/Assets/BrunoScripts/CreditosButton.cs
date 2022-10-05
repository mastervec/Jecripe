using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CreditosButton : MonoBehaviour
{
    private GameObject gc;
    private bool playPressed;
    public Transform ExitButton;
    public Transform PlayButton;
    public Transform Play2Collider;
    public Transform Credits2Button;
    private float animationTime;
    public AudioSource narrationSound;
    public virtual void OnMouseDown()
    {
        this.narrationSound.Stop();
        UnityEngine.Object.Destroy(this.GetComponent<Collider>());
        UnityEngine.Object.Destroy(this.ExitButton.GetComponent<Collider>());
        UnityEngine.Object.Destroy(this.PlayButton.GetComponent<Collider>());
        UnityEngine.Object.Destroy(this.Play2Collider.GetComponent<Collider>());
        UnityEngine.Object.Destroy(this.Credits2Button.GetComponent<Collider>());
        this.StartCoroutine(this.LoadCredits());
    }

    public virtual void OnMouseEnter()
    {
        this.GetComponent<AudioSource>().Play();
        this.GetComponent<Animation>().Play();
        this.GetComponent<Animation>()["Take 001"].normalizedTime = this.animationTime;
    }

    public virtual void OnMouseExit()
    {
        this.GetComponent<AudioSource>().Stop();
        this.animationTime = this.GetComponent<Animation>()["Take 001"].normalizedTime;
        this.GetComponent<Animation>().Stop();
    }

    public virtual IEnumerator LoadCredits()
    {
        //GameObject.Find("GameController").GetComponent("GUIFader").GUIFaderIn(1, 1);
        yield return new WaitForSeconds(1);
        Application.LoadLevel("Creditos");
    }

}
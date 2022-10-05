using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BebeSoundController : MonoBehaviour
{
    public AudioClip ChorandoAudio;
    public AudioClip BeijoAudio;
    public AudioClip ContrariedadeAudio;
    public AudioClip LambendoAudio;
    public AudioClip PalmasAudio;
    public AudioClip BalbuciandoAudio;
    public virtual void ChangeToChorando()
    {
        this.GetComponent<AudioSource>().clip = this.ChorandoAudio;
        this.GetComponent<AudioSource>().Play();
    }

    public virtual void ChangeToBeijo()
    {
        this.GetComponent<AudioSource>().clip = this.BeijoAudio;
        this.GetComponent<AudioSource>().Play();
    }

    public virtual void ChangeToContrariedade()
    {
        this.GetComponent<AudioSource>().clip = this.ContrariedadeAudio;
        this.GetComponent<AudioSource>().Play();
    }

    public virtual void ChangeToLambendo()
    {
        this.GetComponent<AudioSource>().clip = this.LambendoAudio;
        this.GetComponent<AudioSource>().Play();
    }

    public virtual void ChangeToPalmas()
    {
        this.GetComponent<AudioSource>().clip = this.PalmasAudio;
        this.GetComponent<AudioSource>().Play();
    }

    public virtual void ChangeToBalbuciando()
    {
        this.GetComponent<AudioSource>().clip = this.BalbuciandoAudio;
        this.GetComponent<AudioSource>().Play();
    }

}
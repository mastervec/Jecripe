using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class NarradorCrecheSound : MonoBehaviour
{
    public AudioClip InicioAtividade1Audio;
    public AudioClip InicioAtividade2Audio;
    public AudioClip MamadeiraAudio;
    public AudioClip PapinhaAudio;
    public AudioClip ChupetaAudio;
    public AudioClip ChocalhoAudio;
    public AudioClip FimAtividade1Audio;
    public AudioClip FimAtividade2Audio;
    public AudioClip FimAtividade3Audio;
    public AudioClip FimAtividade4Audio;
    public virtual IEnumerator PlayInicioAtividade()
    {
        this.GetComponent<AudioSource>().clip = this.InicioAtividade1Audio;
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(this.InicioAtividade1Audio.length);
        this.GetComponent<AudioSource>().clip = this.InicioAtividade2Audio;
        this.GetComponent<AudioSource>().Play();
    }

    public virtual void PlayMamadeira()
    {
        this.GetComponent<AudioSource>().clip = this.MamadeiraAudio;
        this.GetComponent<AudioSource>().Play();
    }

    public virtual void PlayPapinha()
    {
        this.GetComponent<AudioSource>().clip = this.PapinhaAudio;
        this.GetComponent<AudioSource>().Play();
    }

    public virtual void PlayChupeta()
    {
        this.GetComponent<AudioSource>().clip = this.ChupetaAudio;
        this.GetComponent<AudioSource>().Play();
    }

    public virtual void PlayChocalho()
    {
        this.GetComponent<AudioSource>().clip = this.ChocalhoAudio;
        this.GetComponent<AudioSource>().Play();
    }

    public virtual IEnumerator PlayFimAtividade()
    {
        this.GetComponent<AudioSource>().clip = this.FimAtividade1Audio;
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(this.FimAtividade1Audio.length);
        this.GetComponent<AudioSource>().clip = this.FimAtividade2Audio;
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(this.FimAtividade2Audio.length);
        this.GetComponent<AudioSource>().clip = this.FimAtividade3Audio;
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(this.FimAtividade3Audio.length);
        this.GetComponent<AudioSource>().clip = this.FimAtividade4Audio;
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(this.FimAtividade4Audio.length);
    }

}
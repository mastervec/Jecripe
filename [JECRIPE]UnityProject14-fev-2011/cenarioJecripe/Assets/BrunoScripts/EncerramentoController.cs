using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class EncerramentoController : MonoBehaviour
{
    public Animation endAnimation;
    private GameController gc;
    public virtual IEnumerator Start()
    {
        //this.gc = (GameController) GameObject.Find("GameController").GetComponent("GameController");
        if (this.gc)
        {
            this.Musica = this.gc.CasaMusicaCompleta;
            this.Creche = this.gc.CrecheVovoCompleta;
            this.Bolhas = this.gc.CasaBolhasCompleta;
        }
        this.endAnimation["Take 001"].speed = 0.36f;
        yield return this.StartCoroutine(this.ExitApplication());
    }

    public virtual IEnumerator ExitApplication()
    {
        yield return new WaitForSeconds(this.endAnimation.clip.length * (1 / 0.36f));
        Application.Quit();
        yield return new WaitForSeconds(8);
    }

    private bool Musica;
    private bool Creche;
    private bool Bolhas;
    public AudioClip MA;
    public AudioClip BA;
    public AudioClip CA;
    public AudioClip MBA;
    public AudioClip MCA;
    public AudioClip BCA;
    public AudioClip MBCA;
    public AudioClip NA;
    public AudioClip Obrigado;
    public virtual IEnumerator CheckSoundToPlay()
    {
        if ((this.Musica && this.Creche) && this.Bolhas)
        {
            this.GetComponent<AudioSource>().clip = this.MBCA;
        }
        else
        {
            if (this.Musica && this.Creche)
            {
                this.GetComponent<AudioSource>().clip = this.MCA;
            }
            else
            {
                if (this.Musica && this.Bolhas)
                {
                    this.GetComponent<AudioSource>().clip = this.MBA;
                }
                else
                {
                    if (this.Bolhas && this.Creche)
                    {
                        this.GetComponent<AudioSource>().clip = this.BCA;
                    }
                    else
                    {
                        if (this.Musica)
                        {
                            this.GetComponent<AudioSource>().clip = this.MA;
                        }
                        else
                        {
                            if (this.Bolhas)
                            {
                                this.GetComponent<AudioSource>().clip = this.BA;
                            }
                            else
                            {
                                if (this.Creche)
                                {
                                    this.GetComponent<AudioSource>().clip = this.CA;
                                }
                                else
                                {
                                    this.GetComponent<AudioSource>().clip = this.NA;
                                }
                            }
                        }
                    }
                }
            }
        }
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(this.GetComponent<AudioSource>().clip.length);
        this.GetComponent<AudioSource>().clip = this.Obrigado;
        this.GetComponent<AudioSource>().Play();
    }

}
using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PlayCrecheButton : MonoBehaviour
{
    public Light lightMusica;
    public Light lightBolhas;
    public Light lightCreche;
    public bool disabledButton;
    public AudioClip narracaoClip;
    public AudioSource mapAudio;
    public MapaAudioController mAC;
    public virtual void OnMouseDown()
    {
        if (!this.disabledButton)
        {
            Application.LoadLevel("Creche");
        }
    }

    public virtual void OnMouseEnter()
    {
        if (!this.disabledButton)
        {
            if (this.mapAudio.clip.name != this.narracaoClip.name)
            {
                this.mapAudio.clip = this.narracaoClip;
                this.mapAudio.Play();
            }
            else
            {
                if (!this.mapAudio.isPlaying)
                {
                    this.mapAudio.Play();
                }
            }
            this.mAC.ResetTimer();
        }
    }

    public virtual void OnMouseOver()
    {
        if (!this.disabledButton)
        {
            this.lightMusica.enabled = false;
            this.lightBolhas.enabled = false;
        }
    }

    public virtual void OnMouseExit()
    {
        if (!this.disabledButton)
        {
            this.lightMusica.enabled = true;
            this.lightBolhas.enabled = true;
        }
    }

}
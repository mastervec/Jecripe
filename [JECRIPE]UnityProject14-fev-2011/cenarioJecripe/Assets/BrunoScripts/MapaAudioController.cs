using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MapaAudioController : MonoBehaviour
{
    public float TimeToPlayAgain;
    public float auxCount;
    private bool canPlay;
    public virtual void Start()
    {
        this.StartCoroutine(this.FirstCheck());
    }

    public virtual void ResetTimer()
    {
        this.auxCount = this.TimeToPlayAgain;
    }

    public Transform cam;
    public Transform finalPosition;
    public virtual IEnumerator FirstCheck()
    {
        while ((this.cam.position - this.finalPosition.position).sqrMagnitude > 0.3f)
        {
            yield return new WaitForSeconds(0.2f);
        }
        this.canPlay = true;
    }

    public virtual void Update()
    {
        if (this.canPlay)
        {
            if (this.auxCount <= 0)
            {
                this.auxCount = this.TimeToPlayAgain;
                StartCoroutine(this.PlaySounds());
            }
            else
            {
                this.auxCount = this.auxCount - Time.deltaTime;
            }
        }
    }

    public AudioClip narrationAudio;
    public AudioClip narrationAudio1;
    public AudioClip narrationAudio2;
    public AudioSource mapAudio;
    public virtual IEnumerator PlaySounds()
    {
        this.mapAudio.clip = this.narrationAudio;
        this.mapAudio.Play();
        yield return new WaitWhile(()=>this.mapAudio.isPlaying);
        this.mapAudio.clip = this.narrationAudio1;
        this.mapAudio.Play();
        yield return new WaitWhile(() => this.mapAudio.isPlaying);
        this.mapAudio.clip = this.narrationAudio2;
        this.mapAudio.Play();
        yield return new WaitWhile(() => this.mapAudio.isPlaying);

    }

    public MapaAudioController()
    {
        this.TimeToPlayAgain = 30;
    }

}
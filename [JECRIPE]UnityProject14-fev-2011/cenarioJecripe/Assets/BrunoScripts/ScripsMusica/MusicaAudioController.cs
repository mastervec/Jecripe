using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MusicaAudioController : MonoBehaviour
{
    public float TimeToPlayAgain;
    public float auxCount;
    private bool canPlay;
    public float firstAuxCount;
    public virtual void Start()
    {
        this.StartCoroutine(this.PositionCheck());
    }

    public Transform cam;
    public Transform finalPosition;
    public virtual IEnumerator PositionCheck()
    {
        while ((this.cam.position - this.finalPosition.position).sqrMagnitude > 0.3f)
        {
            yield return new WaitForSeconds(0.2f);
        }
        this.canPlay = true;
    }

    public virtual void ResetAndStopPlay()
    {
        this.canPlay = false;
        this.auxCount = this.firstAuxCount;
    }

    public virtual void Update()
    {
        if (this.canPlay)
        {
            if (this.auxCount <= 0)
            {
                this.auxCount = this.TimeToPlayAgain;
                this.PlaySounds();
            }
            else
            {
                this.auxCount = this.auxCount - Time.deltaTime;
            }
        }
    }

    public AudioClip narrationAudio;
    public virtual void PlaySounds()
    {
        this.GetComponent<AudioSource>().clip = this.narrationAudio;
        this.GetComponent<AudioSource>().Play();
    }

    public MusicaAudioController()
    {
        this.TimeToPlayAgain = 30;
        this.firstAuxCount = 4;
    }

}
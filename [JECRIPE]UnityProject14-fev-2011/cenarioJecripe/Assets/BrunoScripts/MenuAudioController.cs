using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MenuAudioController : MonoBehaviour
{
    public float TimeToPlayAgain;
    private float auxCount;
    private bool canPlay;
    public virtual void Start()
    {
        this.StartCoroutine(this.FirstCheck());
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

    public MenuAudioController()
    {
        this.TimeToPlayAgain = 30;
    }

}
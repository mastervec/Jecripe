using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BubbleActivitieController : MonoBehaviour
{
    public AudioSource BGSound;
    public AudioClip vamosAchar;
    public AudioClip passeAMaoNasGarrafas;
    public BubbleBlowerAssemble bubbleBlowerAssemble;
    public static int curNumOfBubbles;
    private AudioSource mAudio;
    private float delay;
    public virtual IEnumerator Start()
    {
        //Bruno 
        var gc = GameObject.Find("GameController");
        if (gc)
        {
            //gc.GetComponent("GUIFader").GUIFaderOut(0.2f, 1);
            gc.GetComponent<AudioSource>().Stop();
        }
        this.BGSound.Play();
        this.mAudio = (AudioSource) this.GetComponent(typeof(AudioSource));
        if (this.mAudio)
        {
            this.mAudio.clip = this.vamosAchar;
            this.mAudio.Play();
            yield return new WaitForSeconds(this.mAudio.clip.length + this.delay);
            this.mAudio.clip = this.passeAMaoNasGarrafas;
            this.mAudio.Play();
            yield return new WaitForSeconds(this.mAudio.clip.length);
        }
        this.bubbleBlowerAssemble.enabled = true;
    }

    public BubbleActivitieController()
    {
        this.delay = 1f;
    }

}
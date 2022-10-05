using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class PlayOnceAndDestroy : MonoBehaviour
{
    public virtual IEnumerator Start()
    {
        if (!this.GetComponent<AudioSource>().loop)
        {
            yield return new WaitForSeconds(this.GetComponent<AudioSource>().clip.length);
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

}
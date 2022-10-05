using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BetinhoAnimationController : MonoBehaviour
{
    public Animation animatedMesh;
    public virtual void Start()
    {
        this.animatedMesh["idle"].wrapMode = WrapMode.Loop;
        this.animatedMesh["saisai"].wrapMode = WrapMode.Once;
        this.animatedMesh["janelinha"].wrapMode = WrapMode.Once;
        this.animatedMesh["chove"].wrapMode = WrapMode.Once;
        this.animatedMesh["robozinho"].wrapMode = WrapMode.Once;
        this.animatedMesh["campainha"].wrapMode = WrapMode.Once;
        this.animatedMesh["lojadomestre"].wrapMode = WrapMode.Once;
    }

    public virtual void Update()
    {
        if (this.animatedMesh.IsPlaying("saisai") && (this.animatedMesh["saisai"].time > 0.9f))
        {
        }
    }

}
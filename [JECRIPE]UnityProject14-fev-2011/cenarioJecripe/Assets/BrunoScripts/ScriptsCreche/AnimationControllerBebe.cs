using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class AnimationControllerBebe : MonoBehaviour
{
    public Animation animatedMesh;
    public AtividadeCrecheController ac;
    /*animatedMesh["punch"].layer = 2;
	animatedMesh["punch"].AddMixingTransform(upperBody, true);
	
	animatedMesh["arco_shot"].layer = 3;
	animatedMesh["arco_shot"].AddMixingTransform(upperBody, true);
	
	animatedMesh["rock_shot"].layer = 3;
	animatedMesh["rock_shot"].AddMixingTransform(upperBody, true);
	
	animatedMesh["arco_idle"].layer = 2;
	animatedMesh["arco_idle"].AddMixingTransform(upperBody, true);
	
	animatedMesh["rock_idle"].layer = 2;
	animatedMesh["rock_idle"].AddMixingTransform(upperBody, true);
	animatedMesh["rock_idle"].blendMode = AnimationBlendMode.Additive;
	
	var arcoEvent:AnimationEvent = new AnimationEvent();
	arcoEvent.time = timeToShotArrow;
	arcoEvent.functionName = "FireEvent";
	arcoEvent.messageOptions = SendMessageOptions.DontRequireReceiver;
	animatedMesh["arco_shot"].clip.AddEvent(arcoEvent);
	//Debug.Log(animatedMesh["arco_shot"].length);
	arcoEvent.time = animatedMesh["arco_shot"].clip.length - 0.05;  /// When I put animatedMesh["arco_shot"].clip.legth that should be the right value... some times it dosent work
	arcoEvent.functionName = "InstatiateNewBullet";
	animatedMesh["arco_shot"].clip.AddEvent(arcoEvent);
	
	var grabEvent:AnimationEvent = new AnimationEvent();
	grabEvent.time = timeToReallyGrab;
	grabEvent.functionName = "GrabEvent";
	grabEvent.messageOptions = SendMessageOptions.DontRequireReceiver;
	animatedMesh["grab"].clip.AddEvent(grabEvent);
	
	animatedMesh["sneak_left"].AddMixingTransform(rightLeg,true);
	animatedMesh["sneak_left"].AddMixingTransform(leftLeg,true);
	
	animatedMesh["sneak_right"].AddMixingTransform(rightLeg,true);
	animatedMesh["sneak_right"].AddMixingTransform(leftLeg,true);
	
	animatedMesh["strafe_left"].AddMixingTransform(rightLeg,true);
	animatedMesh["strafe_left"].AddMixingTransform(leftLeg,true);
	
	animatedMesh["strafe_right"].AddMixingTransform(rightLeg,true);
	animatedMesh["strafe_right"].AddMixingTransform(leftLeg,true);*/    public virtual void Start()
    {
        this.animatedMesh["idle"].wrapMode = WrapMode.Loop;
        this.animatedMesh["choro"].wrapMode = WrapMode.Once;
        this.animatedMesh["Palmas"].wrapMode = WrapMode.Loop;
        this.animatedMesh["Contrariedade"].wrapMode = WrapMode.Once;
        this.animatedMesh["lambendo beico"].wrapMode = WrapMode.Once;
        this.animatedMesh["beijo"].wrapMode = WrapMode.Once;
        this.animatedMesh["apontando"].wrapMode = WrapMode.Loop;
        this.animatedMesh["apontando_RU"].wrapMode = WrapMode.Loop;
        this.animatedMesh["apontando_RD"].wrapMode = WrapMode.Loop;
        this.animatedMesh["apontando_LU"].wrapMode = WrapMode.Loop;
        this.animatedMesh["apontando_LD"].wrapMode = WrapMode.Loop;
        AnimationEvent objetoDaVezEvent = new AnimationEvent();
        objetoDaVezEvent.time = 0.2f;
        objetoDaVezEvent.functionName = "ChangeObjectRU";
        objetoDaVezEvent.messageOptions = SendMessageOptions.DontRequireReceiver;
        this.animatedMesh["apontando_RU"].clip.AddEvent(objetoDaVezEvent);
        objetoDaVezEvent.time = 0.2f;
        objetoDaVezEvent.functionName = "ChangeObjectRD";
        objetoDaVezEvent.messageOptions = SendMessageOptions.DontRequireReceiver;
        this.animatedMesh["apontando_RD"].clip.AddEvent(objetoDaVezEvent);
        objetoDaVezEvent.time = 0.2f;
        objetoDaVezEvent.functionName = "ChangeObjectLU";
        objetoDaVezEvent.messageOptions = SendMessageOptions.DontRequireReceiver;
        this.animatedMesh["apontando_LU"].clip.AddEvent(objetoDaVezEvent);
        objetoDaVezEvent.time = 0.2f;
        objetoDaVezEvent.functionName = "ChangeObjectLD";
        objetoDaVezEvent.messageOptions = SendMessageOptions.DontRequireReceiver;
        this.animatedMesh["apontando_LD"].clip.AddEvent(objetoDaVezEvent);
    }

    public virtual void ChangeObjectRU(AnimationEvent _objetoDaVezEvent)
    {
        this.ac.ChangeCurrentObject("Chocalho");
    }

    public virtual void ChangeObjectRD(AnimationEvent _objetoDaVezEvent)
    {
        this.ac.ChangeCurrentObject("Papinha");
    }

    public virtual void ChangeObjectLU(AnimationEvent _objetoDaVezEvent)
    {
        this.ac.ChangeCurrentObject("Chupeta");
    }

    public virtual void ChangeObjectLD(AnimationEvent _objetoDaVezEvent)
    {
        this.ac.ChangeCurrentObject("Mamadeira");
    }

}
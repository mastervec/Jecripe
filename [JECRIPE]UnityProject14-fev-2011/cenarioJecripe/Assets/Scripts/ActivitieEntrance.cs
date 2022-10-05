using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ActivitieEntrance : MonoBehaviour
{
    public Transform FPSController;
    public virtual void Start()
    {
        GameObject cam = GameObject.Find("/Player/Main Camera");
        Debug.Log("SplineInterpolator Duration" + ((SplineController) cam.GetComponent(typeof(SplineController))).Duration);
        ((SmoothFollow) cam.GetComponent(typeof(SmoothFollow))).enabled = false;
        ((MouseLook) cam.GetComponent(typeof(MouseLook))).enabled = false;
        ((FPSWalker) this.FPSController.GetComponent(typeof(FPSWalker))).enabled = false;
        ((MouseLook) this.FPSController.GetComponent(typeof(MouseLook))).enabled = false;
        //DESABILITAR OS BUBBLEBLOWERS	
        GameObject obj = GameObject.Find("BubbleBlowerDeviceLeft");
        ((BubbleBlowerBehaviourLeft) obj.GetComponent(typeof(BubbleBlowerBehaviourLeft))).enabled = false;
        obj = GameObject.Find("BubbleBlowerDeviceRight");
        ((BubbleBlowerBehaviourRight) obj.GetComponent(typeof(BubbleBlowerBehaviourRight))).enabled = false;
        ((SplineController) cam.GetComponent(typeof(SplineController))).enabled = true;
        ((BubbleActivitieController) this.GetComponent(typeof(BubbleActivitieController))).enabled = true;
    }

    /*var target2: Transform;
//var target: Transform;
var damping = 3.0;
//var CamPosArray = new Array ();
var FPSController: Transform;
var CamPosArray: Transform[];
private var i: int = 0;

function Start() {
	Debug.Log("BubbleActivitieStarted");
	//FPSController.GetComponent(SmoothFollow).enabled = false;	
	FPSController.GetComponent(FPSWalker).enabled = false;
	if (i == 0)
		StartCoroutine("Lerp",damping);				
}

function Lerp (time : float) {
  var pos = transform.position;
  var rot = transform.rotation;
  var originalTime = time; 
  
   while (i < 3)
   {
		while (time > 0.0)
		{
			time -= Time.deltaTime;
			Debug.Log("Time: "+time);
			//transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * damping);   
			//transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * damping);
			transform.position = Vector3.Lerp(CamPosArray[i].position, pos, time / originalTime);
			transform.rotation = Quaternion.Slerp(CamPosArray[i].rotation, rot, time / originalTime);
			yield;				  
		}
	time = originalTime;
	pos = CamPosArray[i].position;
	rot = CamPosArray[i].rotation;
	FPSController.GetComponent(Transform).position = CamPosArray[i].position;
     FPSController.GetComponent(Transform).rotation = CamPosArray[i].rotation;
	i++;		
   }
      	
}*//*function Update () {
   transform.position = Vector3.Lerp(transform.position, target2.position, Time.deltaTime * damping);   
   transform.rotation = Quaternion.Slerp(transform.rotation, target2.rotation, Time.deltaTime * damping);   
}*/
}
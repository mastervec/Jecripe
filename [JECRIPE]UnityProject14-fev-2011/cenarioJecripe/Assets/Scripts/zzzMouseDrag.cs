using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class zzzMouseDrag : MonoBehaviour
{
    public float spring;
    public float damper;
    public float drag;
    public float angularDrag;
    public float distance;
    public bool attachToCenterOfMass;
    private SpringJoint springJoint;
    /*if (!springJoint)
	{
		var go = new GameObject("Rigidbody dragger");
		body = go.AddComponent ("Rigidbody");
		springJoint = go.AddComponent ("SpringJoint");
		body.isKinematic = true;
	}
	
	springJoint.transform.position = hit.point;
	if (attachToCenterOfMass)
	{
		var anchor = transform.TransformDirection(hit.rigidbody.centerOfMass) + hit.rigidbody.transform.position;
		anchor = springJoint.transform.InverseTransformPoint(anchor);
		springJoint.anchor = anchor;
	}
	else
	{
		springJoint.anchor = Vector3.zero;
	}
	
	springJoint.spring = spring;
	springJoint.damper = damper;
	springJoint.maxDistance = distance;
	springJoint.connectedBody = hit.rigidbody;
	
	StartCoroutine ("DragObject", hit.distance);*/    public virtual void Update()//Destroy (hit.collider.gameObject);
    {
        RaycastHit hit = default(RaycastHit);
         // Make sure the user pressed the mouse down
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        Camera mainCamera = this.FindCamera();
        // We need to actually hit an object
        if (!Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            return;
        }
        // We need to hit a rigidbody that is not kinematic
        if (!hit.rigidbody || hit.rigidbody.isKinematic)
        {
            return;
        }
        Debug.Log("Object Clicked");
        if (hit.collider.CompareTag("Bubble"))
        {
            Debug.Log("Is Bubble");
        }
    }

    public virtual IEnumerator DragObject(float distance)
    {
        float oldDrag = this.springJoint.connectedBody.drag;
        float oldAngularDrag = this.springJoint.connectedBody.angularDrag;
        this.springJoint.connectedBody.drag = this.drag;
        this.springJoint.connectedBody.angularDrag = this.angularDrag;
        Camera mainCamera = this.FindCamera();
        while (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            this.springJoint.transform.position = ray.GetPoint(distance);
            yield return null;
        }
        if (this.springJoint.connectedBody)
        {
            this.springJoint.connectedBody.drag = oldDrag;
            this.springJoint.connectedBody.angularDrag = oldAngularDrag;
            this.springJoint.connectedBody = null;
        }
    }

    public virtual Camera FindCamera()
    {
        if (this.GetComponent<Camera>())
        {
            return this.GetComponent<Camera>();
        }
        else
        {
            return Camera.main;
        }
    }

    /*function Update() {
}

function FixedUpdate() {
	//if (Input.GetMouseButton(0))	
		rigidbody.AddForce(100,1000,100);		
}*//*function OnCollisionEnter(collisionInfo: Collision) {
	if (collisionInfo.gameObject.tag == "Player") {
		GetComponent(Rigidbody).AddForce(Vector3.up * 500);
	}	
}*//*var screenSpace;
var offset;

function OnMouseDown(){
	Debug.Log("OnMouseDown");
	//this.GetComponent(Rigidbody).AddForce(100,100,0);
	screenSpace = Camera.main.WorldToScreenPoint(transform.position);	 
	offset = transform.position - Camera.main.ScreenToWorldPoint(Vector3(Input.mousePosition.x,Input.mousePosition.y, screenSpace.z));
}

function OnMouseDrag () {
	Debug.Log("OnMouseDrag");
	var curScreenSpace = Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);     
	var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
	transform.position = curPosition;     
	renderer.material.color -= Color.white * Time.deltaTime;
}*//*function OnMouseUp() {
	Debug.Log("OnMouseUp");
}*//*var newRotation:  float = 0;
var increment: float = 0.5;

function Update() {
	if (Input.GetMouseButton(0)) {	
		this.transform.Rotate(0,0,newRotation);
		newRotation = newRotation + 2;
		this.transform.position.y = this.transform.position.y + increment;
	}		
}*//*var increment: float = 0;
var startingPoints: Vector3; 
startingPoints = Vector3(transform.position.x,transform.position.y,transform.position.z);

function OnMouseEnter() {
	Debug.Log("OnMouseEnter");
}

function OnMouseExit() {
	Debug.Log("OnMouseExit");
	transform.position = (startingPoints);
}

function OnMouseOver() {
	Debug.Log("OnMouseOver");
	increment = increment + 0.0001;
	transform.position.x = transform.position.x + increment;
}*//*function OnMouseDown() {
	Debug.Log("OnMouseDown");
}

function OnMouseUp() {
	Debug.Log("OnMouseUp");	
}*/
    public zzzMouseDrag()
    {
        this.spring = 50f;
        this.damper = 5f;
        this.drag = 10f;
        this.angularDrag = 5f;
        this.distance = 0.2f;
    }

}
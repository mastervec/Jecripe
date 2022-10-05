using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class zzzMouseScript : MonoBehaviour
{
    // Attach this script to an orthographic camera.
    private Transform chicken; // The chicken we will move.
    private Vector3 offSet; // The chicken's position relative to the mouse position.
    private Camera mainCamera;
    public virtual void Start()
    {
        //camera.orthographic = true;
        this.mainCamera = this.FindCamera();
    }

    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
        Ray ray = this.mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) // If we click the mouse...
        {
            Debug.Log("MousePos: " + Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // Then see if an chicken is beneath us using raycasting.
            {
                this.chicken = hit.transform; // If we hit an chicken then hold on to the chicken.
                this.offSet = this.chicken.position - ray.origin; // This is so when you click on an chicken its center does not align with mouse position.
                if (this.chicken.GetComponent<Rigidbody>())
                {
                    this.chicken.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (this.chicken.GetComponent<Rigidbody>())
                {
                    this.chicken.GetComponent<Rigidbody>().isKinematic = false;
                }
                this.chicken = null; // Let go of the chicken.
            }
        }
        if (this.chicken)
        {
            this.chicken.position = new Vector3(ray.origin.x + this.offSet.x, this.chicken.position.y, ray.origin.z + this.offSet.z); // Only move the chicken on a 2D plane.
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

    /*function Start() {
	Debug.Log("MouseDrag Started");
	Screen.showCursor = true;
}

function Update () {
}*/
}
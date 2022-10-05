using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ToyOnFloor : MonoBehaviour
{
    private Camera mainCamera;
    private OrganizationActivitie organizationScript;
    /*private var redFallingPos: Vector3;
private var yellowFallingPos: Vector3;
private var blueFallingPos: Vector3;
private var greenFallingPos: Vector3;*/
    /*redFallingPos     = GameObject.Find("FallingPosition1").transform.position;
	yellowFallingPos = GameObject.Find("FallingPosition2").transform.position;
	blueFallingPos    = GameObject.Find("FallingPosition3").transform.position;
	greenFallingPos  = GameObject.Find("FallingPosition4").transform.position;*/    public virtual void Start()
    {
        this.mainCamera = this.FindCamera();
        this.organizationScript = (OrganizationActivitie) GameObject.Find("CasaDasBolhas").GetComponent(typeof(OrganizationActivitie));
    }

    public virtual void CheckCollision(Collider other)
    {
        if ((this.tag == "RedBox") && (other.tag == "RedToy"))
        {
            ((DragOn2D) this.mainCamera.GetComponent(typeof(DragOn2D))).ReleaseObject(other.name, this.organizationScript.GetFallingPosition(1));
            this.StartCoroutine(this.organizationScript.IncreaseCount());
        }
        if ((this.tag == "YellowBox") && (other.tag == "YellowToy"))
        {
            ((DragOn2D) this.mainCamera.GetComponent(typeof(DragOn2D))).ReleaseObject(other.name, this.organizationScript.GetFallingPosition(2));
            this.StartCoroutine(this.organizationScript.IncreaseCount());
        }
        if ((this.tag == "BlueBox") && (other.tag == "BlueToy"))
        {
            ((DragOn2D) this.mainCamera.GetComponent(typeof(DragOn2D))).ReleaseObject(other.name, this.organizationScript.GetFallingPosition(3));
            this.StartCoroutine(this.organizationScript.IncreaseCount());
        }
        if ((this.tag == "GreenBox") && (other.tag == "GreenToy"))
        {
            ((DragOn2D) this.mainCamera.GetComponent(typeof(DragOn2D))).ReleaseObject(other.name, this.organizationScript.GetFallingPosition(4));
            this.StartCoroutine(this.organizationScript.IncreaseCount());
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

}
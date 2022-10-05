using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class DragOn2D : MonoBehaviour
{
    public Transform[] toys;
    private Camera mainCamera;
    private float offset;
    private RaycastHit hitPoint;
    private bool isDragging;
    private bool positionChange;
    private Transform toy;
    private Transform[] toysInBox;
    private int count;
    private OrganizationActivitie organizationScript;
    public virtual void Start()
    {
        this.mainCamera = this.FindCamera();
        this.toysInBox = new Transform[8];
        this.organizationScript = (OrganizationActivitie) GameObject.Find("CasaDasBolhas").GetComponent(typeof(OrganizationActivitie));
    }

    /*function OnGUI() {
	GUI.Label(Rect(10,80,200,100),"mousePosition: "+Input.mousePosition);
}*/
    /*if ((hit.transform.tag == "Floor") && (isDragging)) {	
		//toy.position = hit.point + offset * Vector3.up;
		toy.position = ray.GetPoint(2.0); 
	}*/    public virtual void Update()
    {
        RaycastHit hit = default(RaycastHit);
         // We need to actually hit an object
        Ray ray = this.mainCamera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit, 100))
        {
            return;
        }
        Debug.DrawRay(this.mainCamera.transform.position, ray.direction * 10, Color.green);
        //ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        //this.transform.localPosition = Camera.main.ScreenPointToRay (Input.mousePosition).GetPoint(3.8);
        if (!this.isDragging)
        {
            if ((((hit.transform.tag == "RedToy") || (hit.transform.tag == "YellowToy")) || (hit.transform.tag == "BlueToy")) || (hit.transform.tag == "GreenToy"))
            {
                this.isDragging = true;
                hit.transform.localPosition = ray.GetPoint(2f); //remover este e descomentar a linha abaixo
                //hit.transform.position = hit.point + offset * Vector3.up;
                this.toy = hit.transform;
                this.toy.gameObject.layer = 2;
                int i = 0;
                while (i < this.toys.Length)
                {
                    this.toys[i].gameObject.layer = 2;
                    i++;
                }
            }
        }
        //organizationScript.MakeBoxesIgnoreRaycast();
        if (this.isDragging)
        {
            if (((((hit.transform.tag == "Floor") || (hit.transform.tag == "RedBox")) || (hit.transform.tag == "YellowBox")) || (hit.transform.tag == "BlueBox")) || (hit.transform.tag == "GreenBox"))
            {
                //toy.position = hit.point + offset * Vector3.up;
                this.toy.position = ray.GetPoint(2f);
            }
            if ((((hit.transform.tag == "RedBox") || (hit.transform.tag == "YellowBox")) || (hit.transform.tag == "BlueBox")) || (hit.transform.tag == "GreenBox"))
            {
                ((ToyOnFloor) hit.transform.GetComponent(typeof(ToyOnFloor))).CheckCollision(this.toy.GetComponent<Collider>());
            }
        }
    }

    public virtual void ReleaseObject(string _name, Vector3 pos)
    {
        this.isDragging = false;
        //organizationScript.MakeBoxesDetectRaycast();
        int i = 0;
        while (i < this.toys.Length)
        {
            if (this.toys[i].name == _name)
            {
                this.toys[i].gameObject.layer = 2;
                this.toys[i].gameObject.tag = "Untagged";
                this.toys[i].position = pos;
                this.toysInBox[this.count] = this.toys[i];
                this.count++;
            }
            else
            {
                this.toys[i].gameObject.layer = 0;
            }
            i++;
        }
        int j = 0;
        while (j < this.count)
        {
            this.toysInBox[j].gameObject.layer = 2;
            j++;
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

    public DragOn2D()
    {
        this.offset = 1f;
    }

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public partial class BubbleBlowerBehaviour : MonoBehaviour
{
    public Transform bubble;
    public GameObject wallColliders;
    //var toy: GameObject;
    public Transform[] toys;
    public int maxNumOfBubbles;
    public float intervalTime;
    public int minVelocity;
    public int maxVelocity;
    private int targetNumber;
    public static int curNumOfBubbles;
    public static int bubblesWithToyPopped;
    private List<Transform> bubblesArray;
    private bool isBlowing;
    private int count;
    private int numToys;
    public Transform casa;
    public bool rotate=false;
    public virtual IEnumerator Start()//Screen.lockCursor = false;
    {
        bubblesArray = new List<Transform>();
        yield return new WaitForSeconds(0.5f);
        this.targetNumber = (int) Mathf.Floor((this.maxNumOfBubbles / 10) + 1);
        //Screen.showCursor = false;
        //Screen.lockCursor = true;
        while ((this.count < this.maxNumOfBubbles) && this.enabled)
        {
            Transform clone = UnityEngine.Object.Instantiate(this.bubble, this.transform.position, Quaternion.identity);
            //clone.transform.parent = this.transform; 		
            clone.transform.Rotate(new Vector3(0, 0, 180));
            if ((this.count % 10) == 0)
            {
                ((BubbleBlow) clone.GetComponent(typeof(BubbleBlow))).ResizeScale(2.5f);
                //var toyclone = Instantiate(toys[numToys], Vector3(clone.transform.position.x, clone.transform.position.y, clone.transform.position.z - 0.11), Quaternion.identity);
                Transform toyclone = UnityEngine.Object.Instantiate(this.toys[this.numToys], new Vector3(clone.transform.position.x, clone.transform.position.y, clone.transform.position.z), Quaternion.identity);
                Debug.Log("toyclone.name == " + toyclone.name);
                switch (toyclone.name)
                {
                    case "barquinho verde(Clone)":
                        toyclone.transform.Rotate(new Vector3(270, 0, 0));
                        break;
                    case "carrinho azul(Clone)":
                        toyclone.transform.Rotate(new Vector3(270, 0, 0));
                        break;
                    case "piao vermelho(Clone)":
                        toyclone.transform.Rotate(new Vector3(270, 0, 0));
                        break;
                    case "peteca amarela(Clone)":
                        toyclone.transform.Rotate(new Vector3(270, 0, 0));
                        break;
                    case "carrinho vermelho(Clone)":
                        toyclone.transform.Rotate(new Vector3(265, 0, 0));
                        break;
                    default:
                        break;
                }
                toyclone.transform.parent = clone.transform;
                this.numToys++;
            }
            this.bubblesArray.Add(clone);
            int i = 0;
            while (i < (this.bubblesArray.Count - 1))
            {
                if (!(this.bubblesArray[i] == null))
                {
                    Collider collider = null;
                }
                i++;
            }
            //Physics.IgnoreCollision(bubblesArray[i].collider, clone.GetComponent.<Collider>());
            //collider = bubblesArray[i].getComponent.<Collider>();
            //	Physics.IgnoreCollision(collider, clone.GetComponent.<Collider>());
            ((Rigidbody) clone.GetComponent(typeof(Rigidbody))).AddForce(-Random.Range(this.minVelocity, this.maxVelocity), Random.Range(this.minVelocity, this.maxVelocity), -Random.Range(this.minVelocity, this.maxVelocity));
            BubbleBlowerBehaviour.curNumOfBubbles++;
            this.count++;
            yield return new WaitForSeconds(this.intervalTime);
            if (BubbleBlowerBehaviour.bubblesWithToyPopped == this.targetNumber)
            {
                this.BlowAllRemainingBubbles();
                break;
            }
        }
        while (BubbleBlowerBehaviour.bubblesWithToyPopped < this.targetNumber)
        {
            yield return new WaitForSeconds(0.2f);
        }
        this.isBlowing = false;
        this.BlowAllRemainingBubbles();
        this.StartCoroutine(this.StartOrganizationActivitie());
        BubbleBlowerBehaviour.bubblesWithToyPopped = 0;
    }

    /** ************** DEBUG ************* */
    //function OnGUI() {
    //	GUI.Label (Rect (10, 30, 200, 40), "isBlowing: "+ isBlowing);
    //	GUI.Label (Rect (10, 40, 200, 50), "curNumOfBubbles: "+ curNumOfBubbles);
    //	GUI.Label (Rect (10, 50, 200, 60), "Bubbles Blowed: "+ count);
    //	GUI.Label (Rect (10, 60, 200, 70), "bubblesWithToyPopped: "+ bubblesWithToyPopped);
    //}
    /** ************ END DEBUG ************* */
    public virtual IEnumerator StartOrganizationActivitie()
    {
        this.wallColliders.SetActiveRecursively(false);
        GameObject cam = GameObject.Find("Main Camera");
        ((SplineController) cam.GetComponent(typeof(SplineController))).SplineParent = GameObject.Find("CameraPosBeforeOrganization");
        //two lines to disable focus
        ((SplineController)cam.GetComponent(typeof(SplineController))).target = null;
        ((SplineController)cam.GetComponent(typeof(SplineController))).rotate = true;
        //
        ((SplineController) cam.GetComponent(typeof(SplineController))).Start();
        ((SplineController) cam.GetComponent(typeof(SplineController))).FollowSpline();
        GameObject focus = GameObject.Find("Focus");
        ((SplineController)focus.GetComponent(typeof(SplineController))).SplineParent = GameObject.Find("FocusPosBeforeOrganization");
        ((SplineController)focus.GetComponent(typeof(SplineController))).Start();
        ((SplineController)focus.GetComponent(typeof(SplineController))).FollowSpline();

        //yield WaitForSeconds(cam.GetComponent(SplineController).Duration);
        yield return new WaitForSeconds(1f);
        ((OrganizationActivitie) GameObject.Find("CasaDasBolhas").GetComponent(typeof(OrganizationActivitie))).enabled = true;
        //cam.GetComponent(DragOn2D).enabled = true;
        UnityEngine.Object.Destroy(this.gameObject);
    }

    public virtual void BlowAllRemainingBubbles()
    {
        int i = 0;
        while (i < this.bubblesArray.Count)
        {
            if (!(this.bubblesArray[i] == null))
            {
                this.bubblesArray[i].GetComponent<BubbleBlow>().Explode();
            }
            i++;
        }
    }

    public BubbleBlowerBehaviour()
    {
        this.maxNumOfBubbles = 10;
        this.intervalTime = 1f;
        this.minVelocity = 100;
        this.maxVelocity = 150;
        this.isBlowing = true;
    }

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public partial class BubbleBlowerBehaviourLeft : MonoBehaviour
{
    public GameObject bubble;
    //var maxNumOfBubbles: int = 10;
    public float intervalTime;
    public int minVelocity;
    public int maxVelocity;
    public int lifeTime;
    public static int curNumOfBubbles;
    private List<GameObject> bubblesArray;
    private bool isBlowing;
    private int count;
    public virtual IEnumerator Start()
    {
        bubblesArray = new List<GameObject>();
        yield return new WaitForSeconds(0.5f);
        //Screen.showCursor = false;
        //Screen.lockCursor = true;
        while (this.enabled)
        {
            GameObject clone = Instantiate(this.bubble, this.transform.position, Quaternion.identity);
            clone.transform.parent = this.transform;
            clone.transform.Rotate(new Vector3(0, 0, 0));
            ((BubbleBlow) clone.GetComponent(typeof(BubbleBlow))).setLifeTime(this.lifeTime);
            print("td ok");
            print(clone);
            bubblesArray.Add(clone);
            int i = 0;
            while (i < (bubblesArray.Count - 1))
            {
                if (!(bubblesArray[i] == null))
                {
                    //Physics.IgnoreCollision(this.bubblesArray[i].collider, clone.GetComponent<Collider>());
                }
                i++;
            }
            ((Rigidbody) clone.GetComponent(typeof(Rigidbody))).AddForce(Random.Range(this.minVelocity, this.maxVelocity), Random.Range(this.minVelocity, this.maxVelocity), Random.Range(this.minVelocity, this.maxVelocity));
            curNumOfBubbles++;
            this.count++;
            yield return new WaitForSeconds(this.intervalTime);
        }
        this.isBlowing = false;
        //StartCoroutine("BlowBubbles");	
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //Screen.showCursor = true;
        //Screen.lockCursor = false;
    }

    /*function BlowBubbles() {
	Debug.Log("ENTROU NO BLOW BUBBLES");
	while (curNumOfBubbles < maxNumOfBubbles) {
		var clone = Instantiate(bubble, this.transform.position, Quaternion.identity);
		clone.transform.parent = this.transform;
		clone.transform.Rotate(Vector3(0,180,180));
		clone.GetComponent(BubbleBlow).setLifeTime(lifeTime);
		bubblesArray.push(clone);
		for (var i: int = 0; i < bubblesArray.length - 1; i++) {
			if ( bubblesArray[i] != null )
			Physics.IgnoreCollision(bubblesArray[i].collider, clone.collider);
		}
		clone.GetComponent(Rigidbody).AddForce(Random.Range(minVelocity,maxVelocity), Random.Range(minVelocity,maxVelocity), Random.Range(minVelocity,maxVelocity));
		curNumOfBubbles++;
		count++;
		yield WaitForSeconds(intervalTime);	
	}	
	isBlowing = false;	
}*/
    public BubbleBlowerBehaviourLeft()
    {
        this.intervalTime = 1f;
        this.minVelocity = 100;
        this.maxVelocity = 150;
        this.lifeTime = 10;
        this.isBlowing = true;
    }

}
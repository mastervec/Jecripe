using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public partial class BubbleBlow : MonoBehaviour
{
    //public ParticleEmitter explosionParticles;
    public List<AudioClip> explosionSound;
    public float minSpeed;
    public float maxSpeed;
    public float minScale;
    public float maxScale;
    public float lifeTime;
    private GameObject toy;
    private float elapsedTime;
    private BubbleBlowerBehaviour bubbleBlowerScript;
    public AudioSource source;
    //private var speed: float;
    public virtual void Explode()
    {
        BubbleBlowerBehaviour.curNumOfBubbles--;
        if (this.transform.childCount > 0)
        {
            BubbleBlowerBehaviour.bubblesWithToyPopped++;
        }
        //ParticleEmitter t = UnityEngine.Object.Instantiate(this.explosionParticles, this.transform.position, this.transform.rotation);
        //t.Emit();
        //var sound = Instantiate(explosionSound, this.transform.position, this.transform.rotation);
        //explosionSound[Random.Range(0,explosionSound.length)].Play();
        this.gameObject.BroadcastMessage("SetRigidbody", true, SendMessageOptions.DontRequireReceiver);
        this.transform.DetachChildren();
        UnityEngine.Object.Destroy(this.gameObject);
    }

    public virtual void setLifeTime(int t)
    {
        this.lifeTime = t;
    }

    public virtual void Start()//}
    {
        //speed = Random.Range(minSpeed, maxSpeed);	
        this.ResizeScale(Random.Range(this.minScale, this.maxScale));
        /*	print("Current Scene: "+EditorApplication.currentScene);
//	var path : String [] = EditorApplication.currentScene.Split(char.Parse("/"));
//    print("path[path.Length -1] = "+path[path.Length -1]);
/    if (path[path.Length -1] == "BolhasInterna.unity") Retirado para gerar o BUILD */
       // this.bubbleBlowerScript = (BubbleBlowerBehaviour) GameObject.Find("BubbleBlowerDevice").GetComponent("BubbleBlowerBehaviour");
    }

    public virtual void FixedUpdate()
    {
        if (this.elapsedTime < this.lifeTime)
        {
            this.elapsedTime = this.elapsedTime + Time.deltaTime;
        }
        else
        {
             //Debug.Log("Bubble parent name is :"+transform.parent.name);
            BubbleBlowerBehaviour.curNumOfBubbles--;
            if (this.transform.childCount > 0)
            {
                BubbleBlowerBehaviour.bubblesWithToyPopped++;
            }
            //ParticleEmitter t = UnityEngine.Object.Instantiate(this.explosionParticles, this.transform.position, this.transform.rotation);
            //this.explosionSound[Random.Range(0, this.explosionSound.length)].Play();
            //var sound = Instantiate(explosionSound[Random.Range(0,explosionSound.length)], this.transform.position, this.transform.rotation);
            //t.transform.parent = sound.transform;
            //t.Emit();
            //sound.transform.parent = this.transform;
            this.gameObject.BroadcastMessage("SetRigidbody", true, SendMessageOptions.DontRequireReceiver);
            this.transform.DetachChildren();
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

    public virtual void OnMouseOver()
    {
        if (Application.isPlaying)
        {
            //if (this.explosionParticles)
            //{
                BubbleBlowerBehaviour.curNumOfBubbles--;
                if (this.transform.childCount > 0)
                {
                    BubbleBlowerBehaviour.bubblesWithToyPopped++;
                }
            //    ParticleEmitter t = UnityEngine.Object.Instantiate(this.explosionParticles, this.transform.position, this.transform.rotation);
            //t.Emit();
            source.clip = explosionSound[Random.Range(0, explosionSound.Count)];
                source.Play();
                this.gameObject.BroadcastMessage("SetRigidbody", true, SendMessageOptions.DontRequireReceiver);
                this.transform.DetachChildren();
                UnityEngine.Object.Destroy(this.gameObject);
            //}
        }
    }

    //function OnTriggerExit(other : Collider) {
    //	speed *= -1;
     /*	
	if (Application.isPlaying) {
		if (explosionParticles) {
			var t : ParticleEmitter = Instantiate(explosionParticles, this.transform.position, this.transform.rotation);
			t.Emit();
		}
		Destroy(this.gameObject);
		BubbleActivitieController.curNumOfBubbles--;
	}
	*/
    //}
    /*function FixedUpdate() {
	transform.position.x += speed;
	transform.position.y += speed;
}*/
    public virtual void ResizeScale(float newScale)
    {

        {
            float _162 = this.transform.localScale.x + newScale;
            Vector3 _163 = this.transform.localScale;
            _163.x = _162;
            this.transform.localScale = _163;
        }

        {
            float _164 = this.transform.localScale.y + newScale;
            Vector3 _165 = this.transform.localScale;
            _165.y = _164;
            this.transform.localScale = _165;
        }

        {
            float _166 = this.transform.localScale.z + newScale;
            Vector3 _167 = this.transform.localScale;
            _167.z = _166;
            this.transform.localScale = _167;
        }
    }

    public BubbleBlow()
    {
        this.minScale = 1;
        this.maxScale = 1;
        this.lifeTime = 10;
    }

}
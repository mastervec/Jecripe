using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class OrganizationActivitie : MonoBehaviour
{
    public Transform toys;
    public Transform[] toysToRemove;
    public Transform[] boxes;
    public Transform[] boxCollider;
    public float smooth;
    public AudioClip caixaDeMesmaCor;
    public AudioClip passeAMaoParaPegar;
    public AudioClip[] positiveReinforcement;
    public AudioClip estourarBolhasFoiMuitoDivertido;
    private Transform oldPosition;
    private Transform newPosition;
    private int count;
    private Vector3[] target;
    private bool moveBoxes;
    private AudioSource mAudio;
    private float delay;
    public virtual IEnumerator Start()
    {
        this.MoveBoxesFromShelf();
        this.RemoveOldToys();
        this.ActivateToys();
        this.target = new Vector3[4];
        yield return new WaitForSeconds(1f);
        this.mAudio = (AudioSource) this.GetComponent(typeof(AudioSource));
        this.mAudio.clip = this.caixaDeMesmaCor;
        this.mAudio.Play();
        yield return new WaitForSeconds(this.mAudio.clip.length + this.delay);
        this.mAudio.clip = this.passeAMaoParaPegar;
        this.mAudio.Play();
        yield return new WaitForSeconds(this.mAudio.clip.length + this.delay);
        GameObject cam = GameObject.Find("Main Camera");
        ((DragOn2D) cam.GetComponent(typeof(DragOn2D))).enabled = true;
    }

    public virtual Vector3 GetFallingPosition(int i)
    {
        switch (i)
        {
            case 1:
                return GameObject.Find("FallingPosition1").transform.position;
            case 2:
                return GameObject.Find("FallingPosition2").transform.position;
            case 3:
                return GameObject.Find("FallingPosition3").transform.position;
            case 4:
                return GameObject.Find("FallingPosition4").transform.position;
            default:
                return Vector3.zero;
        }
    }

    public virtual void ActivateToys()
    {
        this.toys.gameObject.SetActiveRecursively(true);
        Component[] colliders = this.toys.gameObject.GetComponentsInChildren(typeof(Collider));
        foreach (Collider col in colliders)
        {
            col.isTrigger = false;
            col.gameObject.AddComponent(typeof(Rigidbody));
            col.GetComponent<Rigidbody>().drag = 5f;
        }
    }

    public virtual void MakeBoxesIgnoreRaycast()
    {
        int i = 0;
        while (i < this.boxCollider.Length)
        {
            this.boxCollider[i].gameObject.layer = 2;
            i++;
        }
    }

    public virtual void MakeBoxesDetectRaycast()
    {
        int i = 0;
        while (i < this.boxCollider.Length)
        {
            this.boxCollider[i].gameObject.layer = 0;
            i++;
        }
    }

    public virtual void RemoveOldToys()
    {
        int i = 0;
        while (i < this.toysToRemove.Length)
        {
            UnityEngine.Object.Destroy(this.toysToRemove[i].gameObject);
            i++;
        }
    }

    public virtual void MoveBoxesFromShelf()//boxes[i].position.x = target[i].position.x;
    {
        int i = 0;
        while (i < this.boxes.Length)
        {

            {
                float _150 = //Debug.Log("boxes["+i+"].position = "+ boxes[i].position);
                //Debug.Log("target["+i+"] = "+ target[i]);
                //target[i] = boxes[i].position;
                //target[i].x -= 2.0;
                this.boxes[i].position.x - 2f;
                Vector3 _151 = this.boxes[i].position;
                _151.x = _150;
                this.boxes[i].position = _151;
            }
            i++;
        }
    }

    /*function Update() {
	if (moveBoxes) {
		for (var i : int = 0; i < boxes.length; i++) {
			boxes[i].position = Vector3.Lerp(boxes[i].position, target[i], Time.deltaTime * smooth);
		}		
	}	
}*/
    public Transform backToMapaButton;
    public virtual IEnumerator IncreaseCount()
    {
        this.count++;
        Debug.Log("count: " + this.count);
        this.mAudio.clip = this.positiveReinforcement[Random.Range(0, this.positiveReinforcement.Length)];
        this.mAudio.Play();
        //yield WaitForSeconds(mAudio.clip.length+delay);
        if (this.count == (this.boxes.Length * 2))
        {
            yield return new WaitForSeconds(1f);
            GameObject cam = GameObject.Find("Main Camera");
            ((SplineController) cam.GetComponent(typeof(SplineController))).SplineParent = GameObject.Find("CameraPosAfterOrganization");
            ((SplineController) cam.GetComponent(typeof(SplineController))).Start();
            ((SplineController) cam.GetComponent(typeof(SplineController))).FollowSpline();
            yield return new WaitForSeconds(1f);
            yield return new WaitForSeconds(((SplineController) cam.GetComponent(typeof(SplineController))).Duration);
            this.mAudio.clip = this.estourarBolhasFoiMuitoDivertido;
            this.mAudio.Play();
            yield return new WaitForSeconds(this.mAudio.clip.length + this.delay);
            ((AudioSource) GameObject.Find("BubbleActivitieBGSound").GetComponent(typeof(AudioSource))).Stop();
            Debug.Log("FIM DA ATIVIDADE - VOLTAR AO MENU");
            //sucess.Play();
            //yield WaitForSeconds(sucess.clip.length);
            //BRUNO
            // Avisar o GameController que ja fez a atividade
            GameObject.Find("GameController").GetComponent<GameController>().CasaBolhasCompleta = true;
            //Esperar narra�ao final e voltar para o mapa
            this.backToMapaButton.GetComponent<BackToMapButton>().OnMouseDown();
        }
    }

    public OrganizationActivitie()
    {
        this.smooth = 5f;
        this.delay = 0.5f;
    }

}
using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Grabber : MonoBehaviour
{
    private Ray ray;
    private Vector3 InitialPosition;
    private float distance;
    private bool WaterWasPlayed;
    private bool SoapWasPlayed;
    private bool LastPieceWasPlayed;
    //private var grabberActive:boolean = false;
    /*function MakeGrabberActive(_state:boolean)
{
	grabberActive = _state;
}*/
    public virtual void Start()
    {
        this.InitialPosition = this.transform.localPosition;
    }

    public virtual void Update()//Debug.DrawRay(ray.origin,ray.direction*4.5, Color.green);	
    {
        if (BBPiecesController.isDraggingWater)
        {
            if (this.tag == "WaterBottle")
            {
                this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                this.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(this.distance);

                {
                    float _144 = this.transform.localPosition.y - 0.4f;
                    Vector3 _145 = this.transform.localPosition;
                    _145.y = _144;
                    this.transform.localPosition = _145;
                }
            }
        }
        if (BBPiecesController.isDraggingSoap)
        {
            if (this.tag == "SoapBottle")
            {
                this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                this.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(this.distance);

                {
                    float _146 = this.transform.localPosition.y - 0.3f;
                    Vector3 _147 = this.transform.localPosition;
                    _147.y = _146;
                    this.transform.localPosition = _147;
                }
            }
        }
        if (BBPiecesController.isDraggingLastPiece)
        {
            if (this.tag == "LastPiece")
            {
                this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                this.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(this.distance);

                {
                    float _148 = this.transform.localPosition.y + 0.05f;
                    Vector3 _149 = this.transform.localPosition;
                    _149.y = _148;
                    this.transform.localPosition = _149;
                }
            }
        }
    }

    public virtual void OnMouseOver()
    {
        if (this.enabled)
        {
            if (this.tag == "WaterBottle")
            {
                BBPiecesController.isDraggingWater = true;
                if (!((AudioSource) this.GetComponent(typeof(AudioSource))).isPlaying && !this.WaterWasPlayed)
                {
                    ((AudioSource) this.GetComponent(typeof(AudioSource))).Play();
                    this.WaterWasPlayed = true;
                }
            }
            Debug.Log("grabber");
            Debug.Log(!BBPiecesController.isDraggingWater);
            Debug.Log(BBPiecesController.canDragSoapBottle);
            if (!BBPiecesController.isDraggingWater && BBPiecesController.canDragSoapBottle)
            {
                if (this.tag == "SoapBottle")
                {
                    BBPiecesController.isDraggingSoap = true;
                    if (!((AudioSource) this.GetComponent(typeof(AudioSource))).isPlaying && !this.SoapWasPlayed)
                    {
                        ((AudioSource) this.GetComponent(typeof(AudioSource))).Play();
                        this.SoapWasPlayed = true;
                    }
                }
                else
                {
                    if ((this.tag == "LastPiece") && BBPiecesController.canDragLastPiece)
                    {
                        BBPiecesController.isDraggingLastPiece = true;
                        if (!((AudioSource) this.GetComponent(typeof(AudioSource))).isPlaying && !this.LastPieceWasPlayed)
                        {
                            ((AudioSource) this.GetComponent(typeof(AudioSource))).Play();
                            this.LastPieceWasPlayed = true;
                        }
                    }
                }
            }
        }
    }

    /*function OnMouseDown()
{
	if (grabberActive)
	{
		//if ( ac.ObjetoDaVez == this.name )
		//{
			//ac.setCurrentDragingObject(this.name);
			
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			this.transform.localPosition = Camera.main.ScreenPointToRay (Input.mousePosition).GetPoint(3.8);
			
			switch ( this.name )
			{
				case "Mamadeira":
				this.transform.localPosition.x -= 0.5;
				break;
				case "Chocalho":
				this.transform.localPosition.x += 1;
				break;
				case "Chupeta":
				break;
				case "Papinha":
				break;
				
			}
			this.transform.localPosition.x += 0.5;
			this.transform.localPosition.y -= 0.3;
	//		Debug.Log(ray);
		//}
	}
}
function OnMouseDrag()
{
	if (grabberActive)
	{
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		this.transform.localPosition = Camera.main.ScreenPointToRay (Input.mousePosition).GetPoint(3.8);
		switch ( this.name )
		{
			case "Mamadeira":
			this.transform.localPosition.x -= 0.5;
			break;
			case "Chocalho":
			this.transform.localPosition.x += 1;
			break;
			case "Chupeta":
			break;
			case "Papinha":
			break;
			
		}
		this.transform.localPosition.x += 0.5;
		this.transform.localPosition.y -= 0.3;
	}
}

function OnMouseUp()
{
	if (grabberActive)
	{
		//if ( ac.ObjetoDaVez == this.name )
		//{
			//this.transform.localPosition.z = -3.5;
			
			this.transform.localPosition = InitialPosition;
			var hit : RaycastHit;
			if (Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition).origin,Camera.main.ScreenPointToRay(Input.mousePosition).direction*10, hit)) 
			{
				if (hit.transform.name == "Bebe")
				{
					Debug.Log("Soltou no bebe");
					//SoltouCerto();
				}
			}
			
		//}
	}
}

/*function SoltouCerto()
{
	if (grabberActive)
	{
		// Avisa para atividade controller q soltou certo objeto
		// AtividadeCrecheController faz:
			// Checa se terminou a atividade
			// Chama Animacao correta do bebe
			// Muda o objeto a ser pego
			// Starta a anima�ao de apontar denovo se a atividade nao tiver completa
		//ac.ObjectDropped();	
			
		// Faz o Objeto sumir e aparecer em cima da mesa
		dummyOnChair.SetActiveRecursively(true);
		Destroy(gameObject);
	}
}*/
    public Grabber()
    {
        this.distance = 1.2f;
    }

}
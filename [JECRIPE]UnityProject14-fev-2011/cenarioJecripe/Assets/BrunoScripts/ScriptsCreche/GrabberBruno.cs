using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GrabberBruno : MonoBehaviour
{
    public AtividadeCrecheController ac;
    public GameObject dummyOnChair;
    private Vector3 InitialPosition;
    private bool grabberActive;
    public virtual void Start()
    {
        this.InitialPosition = this.transform.localPosition;
    }

    public Ray ray;
    public virtual void OnMouseDown()
    {
        Debug.Log("mousedown");
        if (this.grabberActive)
        {
            if (AtividadeCrecheController.ObjetoDaVez == this.name)
            {
                this.ac.IsDragging(true);
                //ac.setCurrentDragingObject(this.name);
                this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                this.transform.localPosition = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(3.8f);
                switch (this.name)
                {
                    case "Mamadeira":

                        {
                            float _126 = this.transform.localPosition.x - 0.5f;
                            Vector3 _127 = this.transform.localPosition;
                            _127.x = _126;
                            this.transform.localPosition = _127;
                        }
                        break;
                    case "Chocalho":

                        {
                            float _128 = this.transform.localPosition.x + 1;
                            Vector3 _129 = this.transform.localPosition;
                            _129.x = _128;
                            this.transform.localPosition = _129;
                        }
                        break;
                    case "Chupeta":
                        break;
                    case "Papinha":
                        break;
                }

                {
                    float _130 = this.transform.localPosition.x + 0.5f;
                    Vector3 _131 = this.transform.localPosition;
                    _131.x = _130;
                    this.transform.localPosition = _131;
                }

                {
                    float _132 = this.transform.localPosition.y - 0.3f;
                    Vector3 _133 = this.transform.localPosition;
                    _133.y = _132;
                    this.transform.localPosition = _133;
                }
            }
            else
            {
                //		Debug.Log(ray);
                 // Se nao eh objeto da vez tocar anima�ao de contrariedade e som...
                this.StartCoroutine(this.ac.ActivateDindtLikedAnimation());
            }
        }
    }

    public virtual void OnMouseDrag()
    {
        if (this.grabberActive)
        {
            if (AtividadeCrecheController.ObjetoDaVez == this.name)
            {
                this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                this.transform.localPosition = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(3.8f);
                switch (this.name)
                {
                    case "Mamadeira":

                        {
                            float _134 = this.transform.localPosition.x - 0.5f;
                            Vector3 _135 = this.transform.localPosition;
                            _135.x = _134;
                            this.transform.localPosition = _135;
                        }
                        break;
                    case "Chocalho":

                        {
                            float _136 = this.transform.localPosition.x + 1;
                            Vector3 _137 = this.transform.localPosition;
                            _137.x = _136;
                            this.transform.localPosition = _137;
                        }
                        break;
                    case "Chupeta":
                        break;
                    case "Papinha":
                        break;
                }

                {
                    float _138 = this.transform.localPosition.x + 0.5f;
                    Vector3 _139 = this.transform.localPosition;
                    _139.x = _138;
                    this.transform.localPosition = _139;
                }

                {
                    float _140 = this.transform.localPosition.y - 0.3f;
                    Vector3 _141 = this.transform.localPosition;
                    _141.y = _140;
                    this.transform.localPosition = _141;
                }
            }
        }
    }

    public virtual void OnMouseUp()
    {
        RaycastHit hit = default(RaycastHit);
        if (this.grabberActive)
        {
            if (AtividadeCrecheController.ObjetoDaVez == this.name)
            {
                this.ac.IsDragging(false);
                this.transform.localPosition = this.InitialPosition;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction * 10, out hit))
                {
                    if (hit.transform.name == "Bebe")
                    {
                        Debug.Log("SoltouCerto");
                        this.StartCoroutine(this.SoltouCerto());
                    }
                }
            }
        }
    }

    public virtual IEnumerator SoltouCerto()
    {
        if (this.grabberActive)
        {
             // Avisa para atividade controller q soltou certo objeto
             // AtividadeCrecheController faz:
             // Checa se terminou a atividade
             // Chama Animacao correta do bebe
             // Muda o objeto a ser pego
             // Starta a anima�ao de apontar denovo se a atividade nao tiver completa
             //DESATIVAR A RENDERIZA��O E COLIS�O ANTES DO YEILD PARA QUE O ULTIMO OBJETO N�O FIQUE EM POSI��O
             //GetComponent.<Renderer>().enable = false;
             // Faz o Objeto sumir e aparecer em cima da mesa
            this.dummyOnChair.SetActiveRecursively(true);

            {
                float _142 = this.transform.localPosition.x + 50;
                Vector3 _143 = this.transform.localPosition;
                _143.x = _142;
                this.transform.localPosition = _143;
            }
            yield return this.StartCoroutine(this.ac.ObjectDropped());
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

    public virtual void MakeGrabberActive(bool _state)
    {
        this.grabberActive = _state;
    }

    public virtual void Update()
    {
        //	Debug.Log("Mouse postition(x , y , z ): "+ Input.mousePosition);
        Debug.DrawRay(this.ray.origin, this.ray.direction * 4.5f, Color.green);
    }

}
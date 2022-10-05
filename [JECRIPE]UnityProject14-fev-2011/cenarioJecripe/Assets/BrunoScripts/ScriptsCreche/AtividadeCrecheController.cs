using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public partial class AtividadeCrecheController : MonoBehaviour
{
    // Controla toda a atividade a ser realizada na creche
    // Criaremos um vetor com os 4 objetos na ordem a serem realizados
    private List<int> ordemObjetos;
    // Definiremos os objetos da seguinte forma:
    // Chocalho = 0 ; Papinha = 1; Chupeta = 2; Mamadeira = 3;
    //Z ORIGINAL= -3,5
    //CLICOU NO OBJETO VAI PRO Z = 0.8
    public Transform cam;
    public Transform wayPointFinal;
    public Transform bebeRef;
    public Transform bebeColRef;
    public Transform Chocalho;
    public Transform Chupeta;
    public Transform Papinha;
    public Transform Mamadeira;
    public Transform backToMapaButton;
    private NarradorCrecheSound sound;
    private bool activityStarted;
    public static string ObjetoDaVez;
    public virtual void Start()
    {
        this.sound = (NarradorCrecheSound) this.GetComponent("NarradorCrecheSound");
        if (GameObject.Find("GameController"))
        {
            GameObject.Find("GameController").GetComponent<AudioSource>().Stop();
        }
        this.ordemObjetos = new List<int>(0);
        int ind = 0;
        while (ind < 4)
        {
            this.ordemObjetos.Add(ind);
            ind++;
        }
        this.ShuffleOrder();
        this.StartCoroutine(this.CheckToBegin());
    }

    public virtual IEnumerator CheckToBegin()
    {
         //CHECAGEM PARA VER SE A CAMERA JA TA NA POSICAO CORRETA PARA COMECAR A ATIVIDADE
         // Habilita os cliques nos objetos e inicia a atividade efetivamente
        while ((this.cam.position - this.wayPointFinal.position).sqrMagnitude > 0.3f)
        {
            yield return null;
        }
        //ATIVAR SOM CORRESPONDENTE
        this.StartCoroutine(this.sound.PlayInicioAtividade());
        yield return new WaitForSeconds(10);
        this.StartActivity(); // Esperar o tempo necessario para o narrador narrar a atividade e depois come�a-la
    }

    public virtual void StartActivity()
    {
        Debug.Log("start");
        this.activityStarted = true;
        this.Chocalho.GetComponent<GrabberBruno>().MakeGrabberActive(true);
        this.Chupeta.GetComponent<GrabberBruno>().MakeGrabberActive(true);
        this.Papinha.GetComponent<GrabberBruno>().MakeGrabberActive(true);
        this.Mamadeira.GetComponent<GrabberBruno>().MakeGrabberActive(true);
        Debug.Log("pegou");
        switch (this.ordemObjetos[ordemObjetos.Count-1])
        {
            case 3:
                AtividadeCrecheController.ObjetoDaVez = "Mamadeira";
                this.bebeRef.GetComponent<Animation>().CrossFade("apontando_LD"); // Apontar pro objeto escolhido
                this.currentAnimation = "apontando_LD";
                break;
            case 0:
                AtividadeCrecheController.ObjetoDaVez = "Chocalho";
                this.bebeRef.GetComponent<Animation>().CrossFade("apontando_RU");
                this.currentAnimation = "apontando_RU";
                break;
            case 2:
                AtividadeCrecheController.ObjetoDaVez = "Chupeta";
                this.bebeRef.GetComponent<Animation>().CrossFade("apontando_LU");
                this.currentAnimation = "apontando_LU";
                break;
            case 1:
                AtividadeCrecheController.ObjetoDaVez = "Papinha";
                this.bebeRef.GetComponent<Animation>().CrossFade("apontando_RD");
                this.currentAnimation = "apontando_RD";
                break;
        }
        ordemObjetos.RemoveAt(ordemObjetos.Count - 1);
        Debug.Log(AtividadeCrecheController.ObjetoDaVez);
        //ATIVAR SOM CORRESPONDENTE
        this.bebeRef.GetComponent<BebeSoundController>().ChangeToBalbuciando();
    }

    public virtual void ShuffleOrder() // Embaralha o vetor que define a ordem dos objetos a serem pegos
    {
        // Fazer aqui com que o OrdemDeObjetos seja embaralhado
        List<int> arrayAux = new List<int>(0);
        int i = 0;
        while (i < 4)
        {
            arrayAux.Add(i);
            i++;
        }
        int ind = 0;
        while (ind < 3)
        {
            int rand = Random.Range(0, 4 - ind);
            //Debug.Log(rand);
            this.ordemObjetos[ind] = arrayAux[rand];
            int temp = (int) arrayAux[(arrayAux.Count - 1) - ind];
            arrayAux[(arrayAux.Count - 1) - ind] = arrayAux[rand];
            arrayAux[rand] = temp;
            ind++;
        }
        this.ordemObjetos[3] = arrayAux[0];
    }

    public virtual IEnumerator ObjectDropped()// Chamada qnd soltou o objeto
    {
         // Checa se terminou a atividade   /// SE TERMINOU MANDAR AO GAME CONTROLLER QUE CONCLUIU COM SUCESSO
         // Muda o objeto a ser pego
         // Starta a anima�ao de apontar denovo se a atividade nao tiver completa
         //Se nao acabou atividade play beijo e aponta ao proximo.... se acabou play palmas
        if (this.ordemObjetos.Count > 0)
        {
            if (AtividadeCrecheController.ObjetoDaVez == "Papinha")
            {
                this.bebeRef.GetComponent<Animation>().CrossFade("lambendo beico");
                //ATIVAR SOM CORRESPONDENTE
                this.bebeRef.GetComponent<BebeSoundController>().ChangeToLambendo();
            }
            else
            {
                this.bebeRef.GetComponent<Animation>().CrossFade("beijo");
                //ATIVAR SOM CORRESPONDENTE
                this.bebeRef.GetComponent<BebeSoundController>().ChangeToBeijo();
            }
            //Assim que colocar no bebe e ele for fazer a anima�ao desabilitar o drag
            if (this.Chocalho)
            {
                this.Chocalho.GetComponent<GrabberBruno>().MakeGrabberActive(false);
            }
            if (this.Chupeta)
            {
                this.Chupeta.GetComponent<GrabberBruno>().MakeGrabberActive(false);
            }
            if (this.Papinha)
            {
                this.Papinha.GetComponent<GrabberBruno>().MakeGrabberActive(false);
            }
            if (this.Mamadeira)
            {
                this.Mamadeira.GetComponent<GrabberBruno>().MakeGrabberActive(false);
            }
            this.StartCoroutine(this.NextObject());
        }
        else
        {
            this.bebeRef.GetComponent<Animation>().CrossFade("Palmas");
            //ATIVAR SOM CORRESPONDENTE
            this.activityStarted = false;
            this.bebeRef.GetComponent<BebeSoundController>().ChangeToPalmas();
            //ATIVAR NARRADOR FIM
            yield return new WaitForSeconds(1);
            this.StartCoroutine(this.sound.PlayFimAtividade());
            yield return new WaitForSeconds(10);
            // Avisar o GameController que ja fez a atividade
            GameObject.Find("GameController").GetComponent<GameController>().CrecheVovoCompleta = true;
            //Esperar narra�ao final e voltar para o mapa
            this.backToMapaButton.GetComponent<BackToMapButton>().OnMouseDown();
        }
    }

    public virtual IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    public virtual void ChangeCurrentObject(string _nome)
    {
        AtividadeCrecheController.ObjetoDaVez = _nome;
    }

    private bool isDragging;
    private string currentAnimation;
    public virtual void IsDragging(bool _state)
    {
        this.isDragging = _state;
        if (this.isDragging)
        {
            this.bebeRef.GetComponent<Animation>().CrossFade("apontando");
            this.bebeColRef.GetComponent<Look>().LookOn(true);
            switch (AtividadeCrecheController.ObjetoDaVez)
            {
                case "Mamadeira":
                    this.bebeColRef.GetComponent<Look>().SetTarget(this.Mamadeira);
                    break;
                case "Chocalho":
                    this.bebeColRef.GetComponent<Look>().SetTarget(this.Chocalho);
                    break;
                case "Chupeta":
                    this.bebeColRef.GetComponent<Look>().SetTarget(this.Chupeta);
                    break;
                case "Papinha":
                    this.bebeColRef.GetComponent<Look>().SetTarget(this.Papinha);
                    break;
            }
        }
        else
        {
            this.bebeRef.GetComponent<Animation>().CrossFade(this.currentAnimation);
            this.bebeColRef.GetComponent<Look>().LookOn(false);
        }
    }

    public virtual IEnumerator ActivateDindtLikedAnimation()
    {
        this.bebeRef.GetComponent<Animation>().CrossFade("Contrariedade");
        /// ATIVAR SOM CORRESPONDENTE
        this.bebeRef.GetComponent<BebeSoundController>().ChangeToContrariedade();
        if (this.Chocalho)
        {
            this.Chocalho.GetComponent<GrabberBruno>().MakeGrabberActive(false);
        }
        if (this.Chupeta)
        {
            this.Chupeta.GetComponent<GrabberBruno>().MakeGrabberActive(false);
        }
        if (this.Papinha)
        {
            this.Papinha.GetComponent<GrabberBruno>().MakeGrabberActive(false);
        }
        if (this.Mamadeira)
        {
            this.Mamadeira.GetComponent<GrabberBruno>().MakeGrabberActive(false);
        }
        yield return new WaitForSeconds(this.bebeRef.GetComponent<Animation>()["Contrariedade"].length - 0.3f);
        //if( bebeRef.animation.IsPlaying( "Contrariedade" ) ) bebeRef.animation.CrossFade( currentAnimation );
        this.bebeRef.GetComponent<Animation>().CrossFade(this.currentAnimation);
        //ATIVAR SOM CORRESPONDENTE
        this.bebeRef.GetComponent<BebeSoundController>().ChangeToBalbuciando();
        yield return new WaitForSeconds(0.3f);
        if (this.Chocalho) // PARA CORRIGIR O BUG DE TRAVAR A ANIMACAO QUANDO CLICA NO OBJETO ERRADO LOGO ANTES DE TERMINAR A ANIMACAO DE CONTRARIEDADE
        {
            this.Chocalho.GetComponent<GrabberBruno>().MakeGrabberActive(true);
        }
        if (this.Chupeta)
        {
            this.Chupeta.GetComponent<GrabberBruno>().MakeGrabberActive(true);
        }
        if (this.Papinha)
        {
            this.Papinha.GetComponent<GrabberBruno>().MakeGrabberActive(true);
        }
        if (this.Mamadeira)
        {
            this.Mamadeira.GetComponent<GrabberBruno>().MakeGrabberActive(true);
        }
    }

    public virtual IEnumerator NextObject()
    {
        while (this.bebeRef.GetComponent<Animation>().IsPlaying("beijo") || this.bebeRef.GetComponent<Animation>().IsPlaying("lambendo beico"))
        {
            yield return new WaitForSeconds(0.05f);
        }
        this.bebeRef.GetComponent<Animation>().Play("beijo");
        //Assim que for mudar para a animacao de apontando permitir clicar denovo
        if (this.Chocalho)
        {
            this.Chocalho.GetComponent<GrabberBruno>().MakeGrabberActive(true);
        }
        if (this.Chupeta)
        {
            this.Chupeta.GetComponent<GrabberBruno>().MakeGrabberActive(true);
        }
        if (this.Papinha)
        {
            this.Papinha.GetComponent<GrabberBruno>().MakeGrabberActive(true);
        }
        if (this.Mamadeira)
        {
            this.Mamadeira.GetComponent<GrabberBruno>().MakeGrabberActive(true);
        }
        switch (ordemObjetos[ordemObjetos.Count - 1])
        {
            case 3:
                //ObjetoDaVez = "Mamadeira";
                this.bebeRef.GetComponent<Animation>().CrossFade("apontando_LD"); // Apontar pro objeto escolhido
                this.currentAnimation = "apontando_LD";
                break;
            case 0:
                //ObjetoDaVez = "Chocalho";
                this.bebeRef.GetComponent<Animation>().CrossFade("apontando_RU");
                this.currentAnimation = "apontando_RU";
                break;
            case 2:
                //ObjetoDaVez = "Chupeta";
                this.bebeRef.GetComponent<Animation>().CrossFade("apontando_LU");
                this.currentAnimation = "apontando_LU";
                break;
            case 1:
                //ObjetoDaVez = "Papinha";
                this.bebeRef.GetComponent<Animation>().CrossFade("apontando_RD");
                this.currentAnimation = "apontando_RD";
                break;
        }
        ordemObjetos.RemoveAt(ordemObjetos.Count - 1);
        //ATIVAR SOM CORRESPONDENTE
        this.bebeRef.GetComponent<BebeSoundController>().ChangeToBalbuciando();
    }

    private float timeTotal;
    private float counting;
    public virtual void Update()
    {
        if (this.activityStarted)
        {
            this.counting = this.counting - Time.deltaTime;
            if (this.counting <= 0)
            {
                this.counting = this.timeTotal;
                //Play a narrator sound
                if (!this.bebeRef.GetComponent<Animation>().IsPlaying("beijo") && !this.bebeRef.GetComponent<Animation>().IsPlaying("lambendo beico"))
                {
                    switch (AtividadeCrecheController.ObjetoDaVez)
                    {
                        case "Mamadeira":
                            this.sound.PlayMamadeira();
                            break;
                        case "Chocalho":
                            this.sound.PlayChocalho();
                            break;
                        case "Chupeta":
                            this.sound.PlayChupeta();
                            break;
                        case "Papinha":
                            this.sound.PlayPapinha();
                            break;
                    }
                }
            }
        }
    }

    public AtividadeCrecheController()/// PARA A VERSAO FULL REFATORAR ESSES YIELDS POGS QUE GERAM MILHOES DE ERROS COLATERAIS COM EVENTOS DISPARADOS PELAS ANIMA�OES
    {
        this.currentAnimation = "";
        this.timeTotal = 10;
        this.counting = 2;
    }

    static AtividadeCrecheController()
    {
        AtividadeCrecheController.ObjetoDaVez = "";
    }

}
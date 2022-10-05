using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MusicaInsideController : MonoBehaviour
{
    public SplineControllerBruno sc;
    public AudioClip danceIgual;
    public AudioClip dancaramBem;
    public AudioClip final1;
    public AudioClip final2;
    public AudioClip narracaoFinal;
    public AudioClip volteSempre;
    public JanelaButton jb1;
    public JanelaButton jb2;
    public JanelaButton jb3;
    public JanelaButton jb4;
    public JanelaButton jb5;
    public JanelaButton jb6;
    public AudioClip Musica1;
    public AudioClip Musica2;
    public AudioClip Musica3;
    public AudioClip Musica4;
    public AudioClip Musica5;
    public AudioClip Musica6;
    public GameObject jTravelIda1;
    public GameObject jTravelVolta1;
    public GameObject jTravelIda2;
    public GameObject jTravelVolta2;
    public GameObject jTravelIda3;
    public GameObject jTravelVolta3;
    public GameObject jTravelIda4;
    public GameObject jTravelVolta4;
    public GameObject jTravelIda5;
    public GameObject jTravelVolta5;
    public GameObject jTravelIda6;
    public GameObject jTravelVolta6;
    public Windows windowsController;
    public Animator animator1;
    public Animator animator2;
    public Animator animator3;
    public Animator animator4;
    public Animator animator5;
    public Animator animator6;
    /*private var janela1Feita:boolean = false;
private var janela2Feita:boolean = false;
private var janela3Feita:boolean = false;
private var janela4Feita:boolean = false;
private var janela5Feita:boolean = false;
private var janela6Feita:boolean = false;*/
    public bool janela1Feita;
    public bool janela2Feita;
    public bool janela3Feita;
    public bool janela4Feita;
    public bool janela5Feita;
    public bool janela6Feita;
    private GameObject gc;
    public virtual void Start()
    {
        gc = GameObject.Find("GameController");
        if (gc)
        {
            if (!gc.GetComponent<AudioSource>().isPlaying)
            {
                gc.GetComponent<AudioSource>().Play();
            }
        }
    }

    public virtual void CampainhaFinished()
    {
        if (gc)
        {
            if (gc.GetComponent<AudioSource>().isPlaying)
            {
                gc.GetComponent<AudioSource>().Stop();
            }
        }
        //Nesse Momento entra a trilha sonora da casa da musica quer sera parada sempre que entrar em alguma musica
        sc.PlayIt();
        //Isso dever� ser abilitado na verdade depois do fim do spline apos a narra�ao
        StartCoroutine(Wait(5));
        JanelasButtonState(true);
    }

    public virtual IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    public virtual void JanelasButtonState(bool _state)
    {
        jb1.EnableButton(_state);
        jb2.EnableButton(_state);
        jb3.EnableButton(_state);
        jb4.EnableButton(_state);
        jb5.EnableButton(_state);
        jb6.EnableButton(_state);
    }

    public void completaJanela(int numero)
    {
        switch (numero)
        {
            case 1:
                janela1Feita = true;
                break;
            case 2:
                janela2Feita = true;
                break;
            case 3:
                janela3Feita = true;
                break;
            case 4:
                janela4Feita = true;
                break;
            case 5:
                janela5Feita = true;
                break;
            case 6:
                janela6Feita = true;
                break;
        }
    }

    public virtual IEnumerator JanelaNClicked(
        GameObject janelaTravelIda,
        GameObject janelaTravelVolta,
        int number,
        Animator animator,
        string animationName,
        AudioClip music
        )
    {
        sc.changePath(janelaTravelIda);
        sc.PlayIt();
        GetComponent<AudioSource>().clip = danceIgual; /// Isso � feito para tocar o som "Agora dance igual ao betinho" enquanto � dado o travel ate a janela
        GetComponent<AudioSource>().Play();
        JanelasButtonState(false);
        // Abrir janela e depois startar anima�ao de musica. Quando acabar anima�ao dizer ao gamecontroller que fez atividade e fechar janela e abilitar o clique denovo depois de um tempo de travel
        windowsController.Open(number);
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length - 0.2f); // esse tempo devera ser o tempo de travel
        //Startar anima�ao e musica correspondente junto
        animator.SetBool(animationName, true);
        GetComponent<AudioSource>().clip = music;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length - 0.5f);
        animator.SetBool(animationName, false);
        yield return new WaitForSeconds(1);
        // Indicar a booleana correspondente a essa anima�ao q ela foi feita
        completaJanela(number);
        if (gc)
        {
            gc.GetComponent<GameController>().CasaMusicaCompleta = true;
        }
        windowsController.Close(number);
        sc.changePath(janelaTravelVolta);
        sc.PlayIt();
        GetComponent<AudioSource>().clip = dancaramBem; /// Isso � feito para tocar o som "Parabens vc e o betinho dancaram mto bem" enquanto � dado o travel de volta janela
        GetComponent<AudioSource>().Play();
        GetComponent<MusicaAudioController>().PositionCheck();
        yield return new WaitForSeconds(7);
        //Conferir apos chegar na posicao de camera inicial se todas as musicas foram cantadas, se sim pular a funcao de habilitar os botoes e narrar o fim da atividade e voltar ao mapa. //Esse deve ser o tempo de travel para habilitar os botoes so depois
        StartCoroutine(checkIfFinished());
        if (!finished)
        {
            JanelasButtonState(true);
        }
    }

    public virtual IEnumerator Janela1Clicked()
    {
        return JanelaNClicked(jTravelIda1, jTravelVolta1, 1, animator1, "saisai", Musica1);
    }

    public virtual IEnumerator Janela2Clicked()
    {
        return JanelaNClicked(jTravelIda2, jTravelVolta2, 2, animator2, "janelinha", Musica2);
    }

    public virtual IEnumerator Janela3Clicked()
    {
        return JanelaNClicked(jTravelIda3, jTravelVolta3, 3, animator3, "chove", Musica3);
    }

    public virtual IEnumerator Janela4Clicked()
    {
        return JanelaNClicked(jTravelIda4, jTravelVolta4, 4, animator4, "robozinho", Musica4);
    }

    public virtual IEnumerator Janela5Clicked()
    {
        return JanelaNClicked(jTravelIda5, jTravelVolta5, 5, animator5, "campainha", Musica5);
    }

    public virtual IEnumerator Janela6Clicked()
    {
        return JanelaNClicked(jTravelIda6, jTravelVolta6, 6, animator6, "lojadomestre", Musica6);
    }

    private bool finished;
    public virtual IEnumerator checkIfFinished()
    {
        if (janela1Feita && janela2Feita && janela3Feita && janela4Feita && janela5Feita && janela6Feita)
        {
            finished = true; // tem er no inicio pois senao o yield a seguir conflita com o codigo abaixo de onde a funcao eh chamada sendo executado
            GetComponent<MusicaAudioController>().ResetAndStopPlay();
            while (GetComponent<AudioSource>().isPlaying)
            {
                yield return new WaitForSeconds(0.2f);
            }
            GetComponent<AudioSource>().clip = narracaoFinal;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
            GetComponent<AudioSource>().clip = final1;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
            GetComponent<AudioSource>().clip = final2;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
            GetComponent<AudioSource>().clip = volteSempre;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
            if (gc)
            {
                //gc.GetComponent("GUIFader").GUIFaderIn(0.3f, 1);
            }
            StartCoroutine(LoadMenu());
        }
    }

    public virtual IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(1.1f);
        Application.LoadLevel("Mapa");
    }

}
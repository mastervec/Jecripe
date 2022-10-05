using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GameController : MonoBehaviour
{
    public bool CasaMusicaCompleta;
    public bool CrecheVovoCompleta;
    public bool CasaBolhasCompleta;
    private bool firstLoad;
    private bool firstLoadMap;
    public virtual void Awake()
    {
        UnityEngine.Object.DontDestroyOnLoad(this);
    }

    public virtual void firstLoadOff()
    {
        this.firstLoad = false;
    }

    public virtual void firstLoadMapOff()
    {
        this.firstLoadMap = false;
    }

    public virtual void firstLoadMapOn()
    {
        this.firstLoadMap = true;
    }

    public virtual bool checkFirstLoad()
    {
        return this.firstLoad;
    }

    public virtual bool checkFirstLoadMap()
    {
        return this.firstLoadMap;
    }

    public GameController()
    {
        this.firstLoad = true;
        this.firstLoadMap = true;
    }

}
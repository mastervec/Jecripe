using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateItemList_Creche : MonoBehaviour
{
    private string objetoDaVez;
    private SpawnTutorialHelper script;
    private int objetos_count;

    // Start is called before the first frame update
    void Start()
    {
        script = gameObject.GetComponent<SpawnTutorialHelper>();
        objetos_count = GameObject.Find("ObjetosPegaveis").transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(objetos_count > GameObject.Find("ObjetosPegaveis").transform.childCount)
        {
            objetos_count = GameObject.Find("ObjetosPegaveis").transform.childCount;
            script.waypoints.Clear();
        }
        if (objetoDaVez != AtividadeCrecheController.ObjetoDaVez)
        {
            objetoDaVez = AtividadeCrecheController.ObjetoDaVez;
            script.waypoints.Clear();
            switch (objetoDaVez)
            {
                case "Mamadeira":
                    script.waypoints.Add(GameObject.Find("MamadeiraPos"));
                    script.waypoints.Add(GameObject.Find("BebePos"));
                    break;
                case "Chocalho":
                    script.waypoints.Add(GameObject.Find("ChocalhoPos"));
                    script.waypoints.Add(GameObject.Find("BebePos"));
                    break;
                case "Chupeta":
                    script.waypoints.Add(GameObject.Find("ChupetaPos"));
                    script.waypoints.Add(GameObject.Find("BebePos"));
                    break;
                case "Papinha":
                    script.waypoints.Add(GameObject.Find("PapinhaPos"));
                    script.waypoints.Add(GameObject.Find("BebePos"));
                    break;
            }
        }

    }
}

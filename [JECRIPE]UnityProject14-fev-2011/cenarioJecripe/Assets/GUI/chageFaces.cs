using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class chageFaces : MonoBehaviour
{
    public Image image;
    public List<Sprite> sprites;
    private GameObject gc;
    private int concluded;
    // Start is called before the first frame update
    void Start()
    {
        this.gc = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (gc)
        {
            concluded = Convert.ToInt32(gc.GetComponent<GameController>().CasaBolhasCompleta)+
                Convert.ToInt32(gc.GetComponent<GameController>().CasaMusicaCompleta) +
                Convert.ToInt32(gc.GetComponent<GameController>().CrecheVovoCompleta);
            ImageChange(concluded);
           
        }
    }

    public void ImageChange(int number)
    {
        image.sprite = sprites[number];
    }
}

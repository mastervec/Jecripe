using UnityEngine;
using System.Collections;

public  class BackToMenuButton : MonoBehaviour
{

    public void onMouseDown()
    {
        Application.LoadLevel("JecripeMenu");
    }

}
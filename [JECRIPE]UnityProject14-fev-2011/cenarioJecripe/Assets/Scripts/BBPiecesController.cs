using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BBPiecesController : MonoBehaviour
{
    public bool isDraggingWater;
    public bool isDraggingSoap;
    public bool isDraggingLastPiece;
    public bool canDragLastPiece;
    public bool canDragSoapBottle;
    public virtual void Start()
    {
        isDraggingWater = false;
        isDraggingSoap = false;
        isDraggingLastPiece = false;
        canDragLastPiece = false;
        canDragSoapBottle = false;
    }

    /*function OnGUI() {
	GUI.Label(Rect(10,130,200,150),"canDragSoapBottle == "+canDragSoapBottle);
	GUI.Label(Rect(10,150,200,180),"canDragLastPiece == "+canDragLastPiece);
}*/
}
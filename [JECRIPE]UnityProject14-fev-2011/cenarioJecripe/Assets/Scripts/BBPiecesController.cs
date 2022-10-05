using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BBPiecesController : MonoBehaviour
{
    public static bool isDraggingWater;
    public static bool isDraggingSoap;
    public static bool isDraggingLastPiece;
    public static bool canDragLastPiece;
    public static bool canDragSoapBottle;
    public virtual void Start()
    {
        BBPiecesController.isDraggingWater = false;
        BBPiecesController.isDraggingSoap = false;
        BBPiecesController.isDraggingLastPiece = false;
        BBPiecesController.canDragLastPiece = false;
        BBPiecesController.canDragSoapBottle = false;
    }

    /*function OnGUI() {
	GUI.Label(Rect(10,130,200,150),"canDragSoapBottle == "+canDragSoapBottle);
	GUI.Label(Rect(10,150,200,180),"canDragLastPiece == "+canDragLastPiece);
}*/
}
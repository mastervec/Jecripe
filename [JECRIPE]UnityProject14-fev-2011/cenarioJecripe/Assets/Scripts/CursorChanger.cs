using UnityEngine;
using System.Collections;

public class CursorChanger : MonoBehaviour
{
    public Texture2D cursorTextureUp;
    public Texture2D cursorTextureDown;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public virtual void Awake()
    {
        UnityEngine.Object.DontDestroyOnLoad(this);
    }
    

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Cursor.SetCursor(cursorTextureDown, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(cursorTextureUp, hotSpot, cursorMode);
        }
        
    }

}
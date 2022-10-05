using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class MouseCursor : MonoBehaviour
{
    public Texture2D normalCursor; // The texture for when the cursor isn't near a screen edge
    public Texture2D leftCursor; // The texture for the cursor when it's at the left edge
    public Texture2D rightCursor; // Ditto, right edge
    public Texture2D upCursor; // Top edge
    public Texture2D downCursor; // ...And bottom edge
    public float nativeRatio; // Aspect ratio of the monitor used to set up GUI elements
    private Vector3 lastPosition; // Where the mouse position was last
    public float normalAlpha; // Normal alpha value of the cursor ... .5 is full
    public float fadeTo; // The alpha value the cursor fades to if not moved
    public float fadeRate; // The rate at which the cursor fades
    private bool cursorIsFading; // Whether we should fade the cursor
    private float fadeValue;
    // Scale the cursor so it should look right in any aspect ratio, and turn off the OS mouse pointer
    public virtual void Start()
    {
        // Slightly weird but necessary way of forcing float evaluation
        float currentRatio = (0f + Screen.width) / Screen.height;

        {
            float _152 = this.transform.localScale.x * (this.nativeRatio / currentRatio);
            Vector3 _153 = this.transform.localScale;
            _153.x = _152;
            this.transform.localScale = _153;
        }
        Cursor.visible = false;
        this.fadeValue = this.normalAlpha;
        this.lastPosition = Input.mousePosition;
        UnityEngine.Object.DontDestroyOnLoad(this);
    }

    public virtual void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        // If the mouse has moved since the last update
        if (mousePos != this.lastPosition)
        {
            this.lastPosition = mousePos;
            // Get mouse X and Y position as a percentage of screen width and height
            this.MoveMouse(mousePos.x / Screen.width, mousePos.y / Screen.height);
        }
        // Fade the alpha of the cursor
        if (this.cursorIsFading)
        {

            //{
            //    float _154 = this.fadeValue;
            //    Color _155 = this.GetComponent<GUITexture>().color;
            //    _155.a = _154;
            //    this.GetComponent<GUITexture>().color = _155;
            //}
            this.fadeValue = this.fadeValue - (this.fadeRate * Time.deltaTime);
            if (this.fadeValue < this.fadeTo)
            {
                this.fadeValue = this.fadeTo;
                this.cursorIsFading = false;
            }
        }
        //this.GetComponent<GUITexture>().texture = this.normalCursor;
        //if (Input.GetMouseButton(0))
        //{
        //    this.GetComponent<GUITexture>().texture = this.downCursor;
        //}
        //else
        //{
        //    this.GetComponent<GUITexture>().texture = this.normalCursor;
        //}
    }

    /*function OnMouseDown() {
	var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	if (Physics.Raycast (ray, 100)) {
		print ("Hit "+ray.ToString());
	} 
	
	guiTexture.texture = downCursor;
	yield WaitForSeconds(0.1);
	guiTexture.texture = normalCursor;
}*/
    public virtual void MoveMouse(float mousePosX, float mousePosY)
    {

        //{
        //    float _156 = // Make the cursor solid, and set fading to start in case mouse movement stops
        //    this.fadeValue = this.normalAlpha;
        //    Color _157 = this.GetComponent<GUITexture>().color;
        //    _157.a = _156;
        //    this.GetComponent<GUITexture>().color = _157;
        //}
        //this.GetComponent<GUITexture>().texture = this.normalCursor;
        this.cursorIsFading = true;
        // If the mouse is on a screen edge, first make sure the cursor doesn't go off the screen, then give it the appropriate cursor
        if (mousePosX < 0.005f)
        {
            mousePosX = 0.005f;
            //this.GetComponent<GUITexture>().texture = this.leftCursor;
        }
        if (mousePosX > 0.995f)
        {
            mousePosX = 0.995f;
            //this.GetComponent<GUITexture>().texture = this.rightCursor;
        }
        if (mousePosY < 0.005f)
        {
            mousePosY = 0.005f;
        }
        // guiTexture.texture = downCursor;
        if (mousePosY > 0.995f)
        {
            mousePosY = 0.995f;
            //this.GetComponent<GUITexture>().texture = this.upCursor;
        }

        {
            float _158 = mousePosX;
            Vector3 _159 = this.transform.position;
            _159.x = _158;
            this.transform.position = _159;
        }

        {
            float _160 = mousePosY;
            Vector3 _161 = this.transform.position;
            _161.y = _160;
            this.transform.position = _161;
        }
    }

    public MouseCursor()
    {
        this.nativeRatio = 1.3333333333333f;
        this.normalAlpha = 0.5f;
        this.fadeTo = 0.2f;
        this.fadeRate = 0.22f;
        this.cursorIsFading = true;
    }

}
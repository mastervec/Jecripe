using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Windows : MonoBehaviour
{
    //////////////// EXPOSED VARIABLES ////////////////
    public int openingSpeed;
    public int closingSpeed;
    public Transform window1L;
    public Transform window1R;
    public Transform window2L;
    public Transform window2R;
    public Transform window3L;
    public Transform window3R;
    public Transform window4L;
    public Transform window4R;
    public Transform window5L;
    public Transform window5R;
    public Transform window6L;
    public Transform window6R;
    public float openLowerAngle;
    public float openHigherAngle;
    public float closeLowerAngle;
    public float closeHigherAngle;
    ////////////// PRIVATE ///////////////////////////
    private bool openWindow1;
    private bool openWindow2;
    private bool openWindow3;
    private bool openWindow4;
    private bool openWindow5;
    private bool openWindow6;
    private bool closeWindow1;
    private bool closeWindow2;
    private bool closeWindow3;
    private bool closeWindow4;
    private bool closeWindow5;
    private bool closeWindow6;
    private bool window1;
    private bool window2;
    private bool window3;
    private bool window4;
    private bool window5;
    private bool window6;
    private Quaternion window1LInitialRotation;
    private Quaternion window1RInitialRotation;
    private Quaternion window2LInitialRotation;
    private Quaternion window2RInitialRotation;
    private Quaternion window3LInitialRotation;
    private Quaternion window3RInitialRotation;
    private Quaternion window4LInitialRotation;
    private Quaternion window4RInitialRotation;
    private Quaternion window5LInitialRotation;
    private Quaternion window5RInitialRotation;
    private Quaternion window6LInitialRotation;
    private Quaternion window6RInitialRotation;
    public virtual void Start()//Open(6);
    {
        this.window1LInitialRotation = this.window1L.rotation;
        this.window1RInitialRotation = this.window1R.rotation;
        this.window2LInitialRotation = this.window2L.rotation;
        this.window2RInitialRotation = this.window2R.rotation;
        this.window3LInitialRotation = this.window3L.rotation;
        this.window3RInitialRotation = this.window3R.rotation;
        this.window4LInitialRotation = this.window4L.rotation;
        this.window4RInitialRotation = this.window4R.rotation;
        this.window5LInitialRotation = this.window5L.rotation;
        this.window5RInitialRotation = this.window5R.rotation;
        this.window6LInitialRotation = this.window6L.rotation;
        this.window6RInitialRotation = this.window6R.rotation;
    }

    public virtual void Open(int _window)
    {
        switch (_window)
        {
            case 1:
                this.openWindow1 = true;
                break;
            case 2:
                this.openWindow2 = true;
                break;
            case 3:
                this.openWindow3 = true;
                break;
            case 4:
                this.openWindow4 = true;
                break;
            case 5:
                this.openWindow5 = true;
                break;
            case 6:
                this.openWindow6 = true;
                break;
        }
    }

    public virtual void Close(int _window)
    {
        switch (_window)
        {
            case 1:
                this.closeWindow1 = true;
                break;
            case 2:
                this.closeWindow2 = true;
                break;
            case 3:
                this.closeWindow3 = true;
                break;
            case 4:
                this.closeWindow4 = true;
                break;
            case 5:
                this.closeWindow5 = true;
                break;
            case 6:
                this.closeWindow6 = true;
                break;
        }
    }

    public virtual void Update()//Open(6);
    {
        if (this.openWindow1)
        {
            this.window1L.Rotate(0, 0, -Time.deltaTime * this.openingSpeed);
            this.window1R.Rotate(0, 0, -Time.deltaTime * this.openingSpeed);
            if (((this.window1L.eulerAngles.z >= this.openLowerAngle) && (this.window1L.eulerAngles.z <= this.openHigherAngle)) && ((this.window1R.eulerAngles.z >= this.openLowerAngle) && (this.window1R.eulerAngles.z <= this.openHigherAngle)))
            {
                this.openWindow1 = false;
            }
        }
        //Close(1);
        if (this.openWindow2)
        {
            this.window2L.Rotate(0, 0, -Time.deltaTime * this.openingSpeed);
            this.window2R.Rotate(0, 0, -Time.deltaTime * this.openingSpeed);
            if (((this.window2L.eulerAngles.z >= this.openLowerAngle) && (this.window2L.eulerAngles.z <= this.openHigherAngle)) && ((this.window2R.eulerAngles.z >= this.openLowerAngle) && (this.window2R.eulerAngles.z <= this.openHigherAngle)))
            {
                this.openWindow2 = false;
            }
        }
        //Close(2);			
        if (this.openWindow3)
        {
            this.window3L.Rotate(0, 0, -Time.deltaTime * this.openingSpeed);
            this.window3R.Rotate(0, 0, -Time.deltaTime * this.openingSpeed);
            if (((this.window3L.eulerAngles.z >= this.openLowerAngle) && (this.window3L.eulerAngles.z <= this.openHigherAngle)) && ((this.window3R.eulerAngles.z >= this.openLowerAngle) && (this.window3R.eulerAngles.z <= this.openHigherAngle)))
            {
                this.openWindow3 = false;
            }
        }
        //Close(3);		
        if (this.openWindow4)
        {
            this.window4L.Rotate(0, 0, -Time.deltaTime * this.openingSpeed);
            this.window4R.Rotate(0, 0, -Time.deltaTime * this.openingSpeed);
            if (((this.window4L.eulerAngles.z >= this.openLowerAngle) && (this.window4L.eulerAngles.z <= this.openHigherAngle)) && ((this.window4R.eulerAngles.z >= this.openLowerAngle) && (this.window4R.eulerAngles.z <= this.openHigherAngle)))
            {
                this.openWindow4 = false;
            }
        }
        //Close(4);
        if (this.openWindow5)
        {
            this.window5L.Rotate(0, 0, -Time.deltaTime * this.openingSpeed);
            this.window5R.Rotate(0, 0, -Time.deltaTime * this.openingSpeed);
            if (((this.window5L.eulerAngles.z >= this.openLowerAngle) && (this.window5L.eulerAngles.z <= this.openHigherAngle)) && ((this.window5R.eulerAngles.z >= this.openLowerAngle) && (this.window5R.eulerAngles.z <= this.openHigherAngle)))
            {
                this.openWindow5 = false;
            }
        }
        //Close(5);	
        if (this.openWindow6)
        {
            this.window6L.Rotate(0, 0, -Time.deltaTime * this.openingSpeed);
            this.window6R.Rotate(0, 0, -Time.deltaTime * this.openingSpeed);
            if (((this.window6L.eulerAngles.z >= this.openLowerAngle) && (this.window6L.eulerAngles.z <= this.openHigherAngle)) && ((this.window6R.eulerAngles.z >= this.openLowerAngle) && (this.window6R.eulerAngles.z <= this.openHigherAngle)))
            {
                this.openWindow6 = false;
            }
        }
        //Close(6);
        if (this.closeWindow1)
        {
            this.window1L.Rotate(0, 0, Time.deltaTime * this.closingSpeed);
            this.window1R.Rotate(0, 0, Time.deltaTime * this.closingSpeed);
            if (((this.window1L.eulerAngles.z >= this.closeLowerAngle) && (this.window1L.eulerAngles.z <= this.closeHigherAngle)) && ((this.window1R.eulerAngles.z >= this.closeLowerAngle) && (this.window1R.eulerAngles.z <= this.closeHigherAngle)))
            {
                this.closeWindow1 = false;
                this.Reset(1);
            }
        }
        //Open(1);
        if (this.closeWindow2)
        {
            this.window2L.Rotate(0, 0, Time.deltaTime * this.closingSpeed);
            this.window2R.Rotate(0, 0, Time.deltaTime * this.closingSpeed);
            if (((this.window2L.eulerAngles.z >= this.closeLowerAngle) && (this.window2L.eulerAngles.z <= this.closeHigherAngle)) && ((this.window2R.eulerAngles.z >= this.closeLowerAngle) && (this.window2R.eulerAngles.z <= this.closeHigherAngle)))
            {
                this.closeWindow2 = false;
                this.Reset(2);
            }
        }
        //Open(2);
        if (this.closeWindow3)
        {
            this.window3L.Rotate(0, 0, Time.deltaTime * this.closingSpeed);
            this.window3R.Rotate(0, 0, Time.deltaTime * this.closingSpeed);
            if (((this.window3L.eulerAngles.z >= this.closeLowerAngle) && (this.window3L.eulerAngles.z <= this.closeHigherAngle)) && ((this.window3R.eulerAngles.z >= this.closeLowerAngle) && (this.window3R.eulerAngles.z <= this.closeHigherAngle)))
            {
                this.closeWindow3 = false;
                this.Reset(3);
            }
        }
        //Open(3);
        if (this.closeWindow4)
        {
            this.window4L.Rotate(0, 0, Time.deltaTime * this.closingSpeed);
            this.window4R.Rotate(0, 0, Time.deltaTime * this.closingSpeed);
            if (((this.window4L.eulerAngles.z >= this.closeLowerAngle) && (this.window4L.eulerAngles.z <= this.closeHigherAngle)) && ((this.window4R.eulerAngles.z >= this.closeLowerAngle) && (this.window4R.eulerAngles.z <= this.closeHigherAngle)))
            {
                this.closeWindow4 = false;
                this.Reset(4);
            }
        }
        //Open(4);
        if (this.closeWindow5)
        {
            this.window5L.Rotate(0, 0, Time.deltaTime * this.closingSpeed);
            this.window5R.Rotate(0, 0, Time.deltaTime * this.closingSpeed);
            if (((this.window5L.eulerAngles.z >= this.closeLowerAngle) && (this.window5L.eulerAngles.z <= this.closeHigherAngle)) && ((this.window5R.eulerAngles.z >= this.closeLowerAngle) && (this.window5R.eulerAngles.z <= this.closeHigherAngle)))
            {
                this.closeWindow5 = false;
                this.Reset(5);
            }
        }
        //Open(5);
        if (this.closeWindow6)
        {
            this.window6L.Rotate(0, 0, Time.deltaTime * this.closingSpeed);
            this.window6R.Rotate(0, 0, Time.deltaTime * this.closingSpeed);
            if (((this.window6L.eulerAngles.z >= this.closeLowerAngle) && (this.window6L.eulerAngles.z <= this.closeHigherAngle)) && ((this.window6R.eulerAngles.z >= this.closeLowerAngle) && (this.window6R.eulerAngles.z <= this.closeHigherAngle)))
            {
                this.closeWindow6 = false;
                this.Reset(6);
            }
        }
    }

    

    public virtual void Reset(int _window)
    {
        switch (_window)
        {
            case 1:
                this.window1L.rotation = this.window1LInitialRotation;
                this.window1R.rotation = this.window1RInitialRotation;
                window1 = false;
                break;
            case 2:
                this.window2L.rotation = this.window2LInitialRotation;
                this.window2R.rotation = this.window2RInitialRotation;
                window2 = false;
                break;
            case 3:
                this.window3L.rotation = this.window3LInitialRotation;
                this.window3R.rotation = this.window3RInitialRotation;
                window3 = false;
                break;
            case 4:
                this.window4L.rotation = this.window4LInitialRotation;
                this.window4R.rotation = this.window4RInitialRotation;
                window4 = false;
                break;
            case 5:
                this.window5L.rotation = this.window5LInitialRotation;
                this.window5R.rotation = this.window5RInitialRotation;
                window5 = false;
                break;
            case 6:
                this.window6L.rotation = this.window6LInitialRotation;
                this.window6R.rotation = this.window6RInitialRotation;
                window6 = false;
                break;
        }
    }

    public virtual void Reset()
    {
        this.window1L.rotation = this.window1LInitialRotation;
        this.window1R.rotation = this.window1RInitialRotation;
        window1 = false;
        this.window2L.rotation = this.window2LInitialRotation;
        this.window2R.rotation = this.window2RInitialRotation;
        window2 = false;
        this.window3L.rotation = this.window3LInitialRotation;
        this.window3R.rotation = this.window3RInitialRotation;
        window3 = false;
        this.window4L.rotation = this.window4LInitialRotation;
        this.window4R.rotation = this.window4RInitialRotation;
        window4 = false;
        this.window5L.rotation = this.window5LInitialRotation;
        this.window5R.rotation = this.window5RInitialRotation;
        window5 = false;
        this.window6L.rotation = this.window6LInitialRotation;
        this.window6R.rotation = this.window6RInitialRotation;
        window6 = false;
    }

    public Windows()
    {
        this.openingSpeed = 10;
        this.closingSpeed = 10;
        this.openLowerAngle = 250;
        this.openHigherAngle = 320;
        this.closeLowerAngle = 88;
        this.closeHigherAngle = 92;
    }

}
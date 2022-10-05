using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GUIFader : MonoBehaviour
{
    private float fadeInTime;
    private float fadeOutTime;
    private float guiTime;
    private float allGuiTimeAux;
    private float fadeInAuxTime;
    private float fadeOutAuxTime;
    private bool fadingIn;
    private bool fadingOut;
    private bool GUIFaderInCalled;
    private bool GUIFaderOutCalled;
    public virtual void GUIFaderIn(float _guiTime, float _fadeIn)//}
    {
         //Setting the parameters to the global variables
         //if (_gui!=null)
         //{
         //gui = _gui;
        this.guiTime = _guiTime;
        this.fadeInTime = _fadeIn;
        this.fadeOutTime = 0;
        this.allGuiTimeAux = _guiTime + _fadeIn;
        this.GUIFaderInCalled = true;
        this.GUIFaderOutCalled = false;
        this.fadingIn = true;
        this.fadingOut = false;
        this.ShowGUI();
    }

    public virtual void GUIFaderOut(float _guiTime, float _fadeOut)//}
    {
         //Setting the parameters to the global variables
         //if (_gui!=null)
         //{
         //	gui = _gui;
        this.guiTime = _guiTime;
        this.fadeInTime = 0;
        this.fadeOutTime = _fadeOut;
        this.allGuiTimeAux = _guiTime + _fadeOut;
        this.GUIFaderInCalled = false;
        this.GUIFaderOutCalled = true;
        this.fadingIn = false;
        this.fadingOut = false;
        this.ShowGUI();
    }

    public virtual void ShowGUI()
    {
        this.fadeInAuxTime = this.fadeInTime;
        this.fadeOutAuxTime = this.fadeOutTime;
        //this.gameObject.GetComponent<GUITexture>().enabled = true;
    }

    public virtual void FixedUpdate()
    {
        if (this.GUIFaderInCalled)
        {
            if (this.allGuiTimeAux > 0)
            {
                this.allGuiTimeAux = this.allGuiTimeAux - Time.deltaTime;
                if (this.fadingIn)
                {
                    if (this.fadeInAuxTime > 0)
                    {

                        //{
                        //    float _118 = 1 - (this.fadeInAuxTime / this.fadeInTime);
                        //    Color _119 = this.gameObject.GetComponent<GUITexture>().color;
                        //    _119.a = _118;
                        //    this.gameObject.GetComponent<GUITexture>().color = _119;
                        //}
                    }
                    else
                    {
                        this.fadingIn = false;
                    }
                    this.fadeInAuxTime = this.fadeInAuxTime - Time.deltaTime;
                }
                else
                {
                    //if (this.gameObject.GetComponent<GUITexture>().enabled)
                    //{

                    //    {
                    //        int _120 = 1;
                    //        Color _121 = this.gameObject.GetComponent<GUITexture>().color;
                    //        _121.a = _120;
                    //        this.gameObject.GetComponent<GUITexture>().color = _121;
                    //    }
                    //}
                }
            }
            else
            {
                this.GUIFaderInCalled = false;
                //this.gameObject.GetComponent<GUITexture>().enabled = false;
            }
        }
        if (this.GUIFaderOutCalled)
        {
            if (this.allGuiTimeAux > 0)
            {
                this.allGuiTimeAux = this.allGuiTimeAux - Time.deltaTime;
                if (this.fadingOut)
                {
                    if (this.fadeOutAuxTime > 0)
                    {

                        {
                            //float _122 = this.fadeOutAuxTime / this.fadeOutTime;
                            //Color _123 = this.gameObject.GetComponent<GUITexture>().color;
                            //_123.a = _122;
                            //this.gameObject.GetComponent<GUITexture>().color = _123;
                        }
                    }
                    else
                    {
                        this.fadingOut = false;
                        //this.gameObject.GetComponent<GUITexture>().enabled = false;
                    }
                    this.fadeOutAuxTime = this.fadeOutAuxTime - Time.deltaTime;
                }
                else
                {
                    //if (((this.allGuiTimeAux - this.fadeOutTime) > this.guiTime) && this.gameObject.GetComponent<GUITexture>().enabled)
                    //{

                    //    //{
                    //    //    int _124 = 0;
                    //    //    Color _125 = this.gameObject.GetComponent<GUITexture>().color;
                    //    //    _125.a = _124;
                    //    //    this.gameObject.GetComponent<GUITexture>().color = _125;
                    //    //}
                    //}
                    //else
                    //{
                    //    this.fadingOut = true;
                    //}
                }
            }
            else
            {
                this.GUIFaderOutCalled = false;
                //this.gameObject.GetComponent<GUITexture>().enabled = false;
            }
        }
    }

    public GUIFader()
    {
        this.fadeInTime = 1;
        this.fadeOutTime = 1;
        this.guiTime = 1;
        this.allGuiTimeAux = this.guiTime;
        this.fadeInAuxTime = this.fadeInTime;
        this.fadeOutAuxTime = this.fadeOutTime;
    }

}
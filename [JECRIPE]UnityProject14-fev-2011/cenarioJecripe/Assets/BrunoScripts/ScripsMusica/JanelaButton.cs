using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class JanelaButton : MonoBehaviour
{
    public MusicaInsideController mc;
    public MusicaAudioController mac;
    private bool enabledButton;
    public virtual void OnMouseDown()
    {
        if (this.enabledButton)
        {
            this.mac.ResetAndStopPlay();
            switch (this.name)
            {
                case "Janela1Button":
                    this.StartCoroutine(this.mc.Janela1Clicked());
                    break;
                case "Janela2Button":
                    this.StartCoroutine(this.mc.Janela2Clicked());
                    break;
                case "Janela3Button":
                    this.StartCoroutine(this.mc.Janela3Clicked());
                    break;
                case "Janela4Button":
                    this.StartCoroutine(this.mc.Janela4Clicked());
                    break;
                case "Janela5Button":
                    this.StartCoroutine(this.mc.Janela5Clicked());
                    break;
                case "Janela6Button":
                    this.StartCoroutine(this.mc.Janela6Clicked());
                    break;
            }
        }
    }

    public virtual void EnableButton(bool _state)
    {
        this.enabledButton = _state;
    }

}
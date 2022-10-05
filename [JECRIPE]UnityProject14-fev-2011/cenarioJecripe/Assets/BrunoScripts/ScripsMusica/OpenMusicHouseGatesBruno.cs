using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class OpenMusicHouseGatesBruno : MonoBehaviour
{
    public float rotationSpeed;
    public Transform leftGate;
    public Transform rightGate;
    public virtual void Update()
    {
        this.leftGate.Rotate(0, -Time.deltaTime * this.rotationSpeed, 0);
        this.rightGate.Rotate(0, Time.deltaTime * this.rotationSpeed, 0);
        if ((this.leftGate.localEulerAngles.y <= -90) && (this.rightGate.localEulerAngles.y >= 90))
        {
            this.enabled = false;
        }
    }

    public OpenMusicHouseGatesBruno()
    {
        this.rotationSpeed = 1;
    }

}
using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class OpenMusicHouseGates : MonoBehaviour
{
    public float rotationSpeed;
    public Transform leftGate;
    public Transform rightGate;
    private bool isAllowedToRotate;
    public virtual void Start()
    {
        this.leftGate.rotation = Quaternion.identity;
        this.rightGate.rotation = Quaternion.identity;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.isAllowedToRotate = true;
        }
    }

    public virtual void Update()
    {
        this.leftGate.Rotate(0, -Time.deltaTime * this.rotationSpeed, 0);
        this.rightGate.Rotate(0, Time.deltaTime * this.rotationSpeed, 0);
        if ((this.leftGate.eulerAngles.y <= 270) && (this.rightGate.eulerAngles.y >= 90))
        {
            this.enabled = false;
        }
    }

    public virtual void Reset()
    {
        this.leftGate.rotation = Quaternion.identity;
        this.rightGate.rotation = Quaternion.identity;
        this.enabled = true;
    }

    public OpenMusicHouseGates()
    {
        this.rotationSpeed = 1;
    }

}
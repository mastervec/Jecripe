using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BetinhoWalkToBolhas : MonoBehaviour
{
    public float speed;
    public virtual void FixedUpdate()
    {

        {
            float _110 = this.transform.localPosition.x + (this.speed * Time.deltaTime);
            Vector3 _111 = this.transform.localPosition;
            _111.x = _110;
            this.transform.localPosition = _111;
        }

        {
            float _112 = this.transform.localPosition.z - (this.speed * Time.deltaTime);
            Vector3 _113 = this.transform.localPosition;
            _113.z = _112;
            this.transform.localPosition = _113;
        }
    }

    public BetinhoWalkToBolhas()
    {
        this.speed = 2;
    }

}
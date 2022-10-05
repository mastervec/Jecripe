using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BetinhoWalkToMusica : MonoBehaviour
{
    public float speed;
    public virtual void FixedUpdate()
    {

        {
            float _114 = this.transform.localPosition.x + (this.speed * Time.deltaTime);
            Vector3 _115 = this.transform.localPosition;
            _115.x = _114;
            this.transform.localPosition = _115;
        }

        {
            float _116 = this.transform.localPosition.z + ((this.speed / 4) * Time.deltaTime);
            Vector3 _117 = this.transform.localPosition;
            _117.z = _116;
            this.transform.localPosition = _117;
        }
    }

    public BetinhoWalkToMusica()
    {
        this.speed = 2;
    }

}
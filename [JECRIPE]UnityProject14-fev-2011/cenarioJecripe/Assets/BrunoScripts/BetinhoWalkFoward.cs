using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class BetinhoWalkFoward : MonoBehaviour
{
    public float speed;
    public virtual void FixedUpdate()
    {

        {
            float _108 = this.transform.localPosition.x + (this.speed * Time.deltaTime);
            Vector3 _109 = this.transform.localPosition;
            _109.x = _108;
            this.transform.localPosition = _109;
        }
    }

    public BetinhoWalkFoward()
    {
        this.speed = 2;
    }

}
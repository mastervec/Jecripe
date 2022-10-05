using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class IgnoreCollisionBetweenObjects : MonoBehaviour
{
    public GameObject[] objs;
    public virtual void Start()
    {
        int i = 0;
        while (this.objs!=null && i < (this.objs.Length - 1))
        {
            int j = i + 1;
            while (j < this.objs.Length)
            {
                Physics.IgnoreCollision(this.objs[i].GetComponent<Collider>(), this.objs[j].GetComponent<Collider>());
                j++;
            }
            i++;
        }
    }

}
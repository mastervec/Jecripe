using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class ToyBehaviour : MonoBehaviour
{
    public virtual IEnumerator SetRigidbody(bool b)
    {
        if (this.GetComponent<Rigidbody>() == null)
        {
            this.gameObject.AddComponent(typeof(Rigidbody));
        }
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().useGravity = b;
        //this.collider.isTrigger = false;
        yield return new WaitForSeconds(2f);
        //this.collider.isTrigger = true;
        UnityEngine.Object.Destroy(this.gameObject);
    }

    public virtual void ResizeScale(float newScale)
    {

        {
            float _168 = this.transform.localScale.x + newScale;
            Vector3 _169 = this.transform.localScale;
            _169.x = _168;
            this.transform.localScale = _169;
        }

        {
            float _170 = this.transform.localScale.y + newScale;
            Vector3 _171 = this.transform.localScale;
            _171.y = _170;
            this.transform.localScale = _171;
        }

        {
            float _172 = this.transform.localScale.z + newScale;
            Vector3 _173 = this.transform.localScale;
            _173.z = _172;
            this.transform.localScale = _173;
        }
    }

}
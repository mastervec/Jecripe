using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class CreditsButtonHelper : MonoBehaviour
{
    public Transform creditsTranform;
    public virtual void OnMouseDown()
    {
        this.creditsTranform.GetComponent<CreditosButton>().OnMouseDown();
    }

    public virtual void OnMouseEnter()
    {
        this.creditsTranform.GetComponent<CreditosButton>().OnMouseEnter();
    }

    public virtual void OnMouseExit()
    {
        this.creditsTranform.GetComponent<CreditosButton>().OnMouseExit();
    }

}
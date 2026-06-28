using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCredits : MonoBehaviour
{

    public Transform startPosition;
    private Vector3 endPosition;

    public void Start()
    {
        endPosition = startPosition.position;
        endPosition.z -= 24;
        StartCoroutine(MoveOverSeconds(this.gameObject, endPosition , 42.5f));
        
    }

     public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        // speed should be 1 unit per second
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        Debug.Log(objectToMove.transform.position);
        Debug.Log(end);
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        Debug.Log(elapsedTime);
        Debug.Log(seconds);
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
        objectToMove.transform.position = startingPos;
        StartCoroutine(MoveOverSeconds(objectToMove, end, seconds));
    }
}

using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bezier : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject splineParent;
    private List<Transform> mTransforms;
    public bool closedLoop = true;
    public Transform[] waypoints;
    void Start()
    {
        if (waypoints.Length > 0)
        {
            // Create a new bezier path from the waypoints.
            BezierPath bezierPath = new BezierPath(waypoints, closedLoop, PathSpace.xyz);
            GetComponent<PathCreator>().bezierPath = bezierPath;
        }
        //int count = splineParent.childCount;
        //for (int i = 0; i < count; i++)
        //{
        //  mTransforms.Add( splineParent.GetChild(i));
        // ...
        //}
    }

    //VertexPath GeneratePath(Vector3[] points, bool closedPath)
    //{
        // Create a closed, 2D bezier path from the supplied points array
        // These points are treated as anchors, which the path will pass through
        // The control points for the path will be generated automatically
      //  BezierPath bezierPath = new BezierPath(points, closedPath, PathSpace.xy);
        // Then create a vertex path from the bezier path, to be used for movement etc
        //return new VertexPath(bezierPath);
    //}



    // Update is called once per frame
    void Update()
    {
        
    }
}

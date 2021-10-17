using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenRay : MonoBehaviour
{
    // Start is called before the first frame update
    LineRenderer line;
    EdgeCollider2D col;
    public List<Vector2> linePoints = new List<Vector2>();
    void Start()
    {
        line = GetComponent<LineRenderer>();
        col = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        linePoints[0] = line.GetPosition(0);
        linePoints[1] = line.GetPosition(1);
        col.SetPoints(linePoints);
    }
}

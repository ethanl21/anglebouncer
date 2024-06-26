using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour, ILine
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

    List<Vector2> points;

    public void UpdateLine(Vector2 position) {
        if(points == null) {
            points = new List<Vector2>();
            SetPoint(position);
        }

        if (Vector2.Distance(points.Last(), position) > 0.1f) {
            SetPoint(position);
        }
    }

    public void SetPoint(Vector2 point) {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        edgeCollider.points = points.ToArray();
    }
}

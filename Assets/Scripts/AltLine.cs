using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AltLine : MonoBehaviour, ILine
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public float addedVelocity = 5.0f;

    private List<Vector2> _points;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void UpdateLine(Vector2 position)
    {
        if (_points == null)
        {
            _points = new List<Vector2>();
            SetPoint(position);
        }

        if (Vector2.Distance(_points.Last(), position) > 0.1f)
        {
            SetPoint(position);
        }
    }

    public void SetPoint(Vector2 point)
    {
        _points.Add(point);

        lineRenderer.positionCount = _points.Count;
        lineRenderer.SetPosition(_points.Count - 1, point);

        edgeCollider.points = _points.ToArray();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("PlayerBall"))
        {
            Debug.Log("Player collided with line");
            // Check if the colliding object has a Rigidbody2D component
            var rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if (collision.relativeVelocity.magnitude >= 0.5)
                {
                    audioSource.Play();
                }



            }
        }

    }
}

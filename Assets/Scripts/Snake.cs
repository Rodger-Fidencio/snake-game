using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _diraction = Vector2.right;
    private Vector2 _input;

    private List<Transform> _segments = new List<Transform>();
    public Transform snakeSegmentPrefab;
    public int initialSize = 4;

    private void Start()
    {
        ResetStage();
    }

    private void Update()
    {
        if (_diraction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                _input = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                _input = Vector2.down;
            }
        }
        else if (_diraction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                _input = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _input = Vector2.left;
            }
        }

    }

    private void FixedUpdate()
    {
        if (_input != Vector2.zero)
        {
            _diraction = _input;
        }

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        float x = Mathf.Round(transform.position.x) + _diraction.x;
        float y = Mathf.Round(transform.position.y) + _diraction.y;

        transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if(other.tag == "Obstacle")
        {
            ResetStage();
        }
    }

    private void ResetStage()
    {
        _diraction = Vector2.right;
        transform.position = Vector3.zero;

        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(transform);

        for (int i = 0; i < initialSize - 1; i++)
        {
            Grow();
        }

    }

    private void Grow()
    {
        Transform segment = Instantiate(snakeSegmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment); ;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float positionX = Random.Range(bounds.min.x, bounds.max.x);
        float positionY = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(positionX), Mathf.Round(positionY), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomizePosition();
        }
    }
}

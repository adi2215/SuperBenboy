using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private GameObject wayPoint;
    [SerializeField] private float speed = 2f;
    bool platformMove = false;

    private void Update()
    {
        if (Vector2.Distance(wayPoint.transform.position, transform.position) < 0.1f)
        {
            return;
        }

        if (platformMove)
            transform.position = Vector2.MoveTowards(transform.position, wayPoint.transform.position, Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
            platformMove = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
            platformMove = false;
        }
    }
}

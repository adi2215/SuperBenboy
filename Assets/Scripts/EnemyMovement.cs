using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 direction = Vector2.left;

    [SerializeField] private GameObject[] wayPoints;
    private int currentWayPoints = 0;
    private new Rigidbody2D rigidbody;
    private CapsuleCollider2D _capEnemy;
    private Vector2 velocity;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        _capEnemy = GetComponent<CapsuleCollider2D>();
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        rigidbody.WakeUp();
    }

    private void OnDisable()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.Sleep();
    }

    private void FixedUpdate()
    {
        velocity.x = direction.x * speed;
        velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;

        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);

        if (Vector2.Distance(wayPoints[currentWayPoints].transform.position, transform.position) < 0.1f) 
        {
            currentWayPoints++;
            direction = -direction;
            if (currentWayPoints >= wayPoints.Length)
            {
                currentWayPoints = 0;
            }
        }

        if (rigidbody.Raycast(Vector2.down, _capEnemy)) {
            velocity.y = Mathf.Max(velocity.y, 0f);
        }

        if (direction.x > 0f)
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        else if (direction.x < 0f)
            transform.localEulerAngles = Vector3.zero;
    }
}


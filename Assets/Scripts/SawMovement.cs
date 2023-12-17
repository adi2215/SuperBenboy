using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    private int currentpoint = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(wayPoints[currentpoint].transform.position, transform.position) < 0.1f)
        {
            currentpoint++;
            if (currentpoint >= wayPoints.Length)
                currentpoint = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentpoint].transform.position, Time.deltaTime * speed);
    }
}

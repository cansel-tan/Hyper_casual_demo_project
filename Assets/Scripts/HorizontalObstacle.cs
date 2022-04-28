using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HorizontalObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;


    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .001f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}

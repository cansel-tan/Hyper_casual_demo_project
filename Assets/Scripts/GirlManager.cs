using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using UnityEngine.SceneManagement;

public class GirlManager : MonoBehaviour
{
    private Vector3 startPosition;
    public Transform finish;
    void Start()
    {
        startPosition = transform.position;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(finish.position);
        //agent.updatePosition = false;
        //agent.updateRotation = false;
        //agent.updateUpAxis = false;

    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.collider.CompareTag("StaticObstacle"))
        {

            transform.position = startPosition;

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

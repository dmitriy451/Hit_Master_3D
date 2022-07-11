using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        //MoveToWaypoint(_waypoints[1]);
        //MoveToWaypoint(_waypoints[2]);
    }
    void MoveToWaypoint (Transform waypoint)
    {
        _agent.SetDestination(waypoint.transform.position);
    }
}

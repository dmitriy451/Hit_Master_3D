using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Level[] _levels;
    private NavMeshAgent _agent;

    private void Start()
    {
        transform.position = _waypoints[0].position;

        _agent = GetComponent<NavMeshAgent>();

    }
    private void OnEnable()
    {
        foreach (var level in _levels)
        {
            level.levelPassed += OnLevelPassed;
        }
    }

    private void OnDisable()
    {
        foreach (var level in _levels)
        {
            level.levelPassed -= OnLevelPassed;
        }
    }

    private void OnLevelPassed(int level)
    {
        if (level== _levels.Length-1)
        {
            //рестарт сцены
        }
        MoveToNextLevel(level + 1);
    }
    public void GoToFirstLevel()
    {
        MoveToNextLevel(1);
    }
    private void MoveToNextLevel (int nextLevel)
    {
        _agent.SetDestination(_waypoints[nextLevel].transform.position);
    }
}

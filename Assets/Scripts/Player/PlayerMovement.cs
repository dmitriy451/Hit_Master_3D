using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerWin))]
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Level[] _levels;
    [SerializeField] private float _stopDistance;
    [SerializeField] private Animator _animator;

    private PlayerWin _playerWin;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _playerWin = GetComponent<PlayerWin>();

        _agent.stoppingDistance = _stopDistance;
        transform.position = _waypoints[0].position;
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
            _playerWin.Win();
        }
        MoveToNextLevel(level + 1);
    }
    public void GoToFirstLevel()
    {
        MoveToNextLevel(1);
    }
    private void Update()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _animator.SetBool("Running", false);
        }
        else
        {
        _animator.SetBool("Running", true);
            _animator.transform.localPosition = new Vector3(0,0,0);
            _animator.transform.localRotation = new Quaternion(0,0,0,0);
        }

    }
    private void MoveToNextLevel (int nextLevel)
    {
        _agent.SetDestination(_waypoints[nextLevel].transform.position);
    }
}

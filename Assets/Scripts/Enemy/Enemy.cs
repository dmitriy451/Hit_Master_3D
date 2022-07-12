using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Rigidbody[] _ragdollRigidbodies;
    
    public event UnityAction<int> DamageTaken;
    
    private Animator _animator;
    private Camera _mainCamera;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _mainCamera = Camera.main;

        foreach (var rigibody in _ragdollRigidbodies)
        {
            rigibody.isKinematic = true;
        }
    }
    private void Update()
    {
        transform.LookAt(_mainCamera.transform);
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        DamageTaken?.Invoke(_health);
        if (_health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        _animator.enabled = false;
        foreach (var rigibody in _ragdollRigidbodies)
        {
            rigibody.isKinematic = false;
        }
        RemoveEnemyFromPassingList();
    }

    private void RemoveEnemyFromPassingList()
    {
        GetComponentInParent<Level>().EnemyKilled(this);
    }
}

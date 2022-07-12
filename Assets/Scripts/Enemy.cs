using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    public event UnityAction<int> DamageTaken;
    
    private Camera _mainCamera;
    
    void Start()
    {
        _mainCamera = Camera.main;
        //поставить анимацию стояния
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
        RemoveEnemyFromPassingList();
        Destroy(gameObject);
    }

    private void RemoveEnemyFromPassingList()
    {
        GetComponentInParent<Level>().EnemyKilled(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    void Start()
    {
        //поставить анимацию стояния
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
        RemoveEnemyFromPassingList();
    }

    private void RemoveEnemyFromPassingList()
    {
        GetComponentInParent<Level>().EnemyKilled(this);
    }
}

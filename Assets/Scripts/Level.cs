using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private int _level;
    public event UnityAction<int> levelPassed;
    public void EnemyKilled(Enemy enemy)
    {
        _enemies.Remove(enemy);
        CheckLevelPass();
    }
    public bool CheckLevelPass()
    {
        if (_enemies.Count == 0)
        {
            levelPassed?.Invoke(_level);
            return true;
        }
        else
        {
            return false;
        }
    }
}

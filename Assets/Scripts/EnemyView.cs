using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnDamageTaken(int health)
    {
        _text = "HP: " + health;
    }
}

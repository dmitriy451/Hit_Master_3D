using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
[RequireComponent(typeof(Enemy))]
public class EnemyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _fillingTime;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }
    private void OnEnable()
    {
        _enemy.DamageTaken += OnDamageTaken;
    }
    private void OnDisable()
    {
        _enemy.DamageTaken -= OnDamageTaken;
    }
    private void OnDamageTaken(int health)
    {
        _slider.DOValue(health, _fillingTime);
        _text.text = "HP " + health;
    }
}

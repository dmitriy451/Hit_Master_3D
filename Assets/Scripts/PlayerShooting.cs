using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _shootingPoint;
    [Header("Pool Settings")]
    [SerializeField] private int _poolCount;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private Bullet _bulletPrefab;

    private Pool<Bullet> _pool;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;

        _pool = new Pool<Bullet>(_bulletPrefab, _autoExpand, _poolCount, this.transform);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 point = ray.GetPoint(100);
            if (Physics.Raycast(ray,out RaycastHit hit))
            {
                point = hit.point;
            }
            Shoot(point);
        }
    }

    private void Shoot(Vector3 target)
    {
        Bullet bullet = _pool.GetFreeElement();
        bullet.transform.position = _shootingPoint.position;
        bullet.SetTarget(target);
    }
}

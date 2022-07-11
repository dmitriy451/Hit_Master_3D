using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _lifetime;

    private Vector3 _target;

    private void OnEnable()
    {
        StartCoroutine("LifeTime");
    }
    private void OnDisable()
    {
        StopCoroutine("LifeTime");
    }
    private IEnumerator LifeTime()
    {
        yield return new WaitForSecondsRealtime(_lifetime);
        gameObject.SetActive(false);
    }
    public void SetTarget(Vector3 target)
    {
        _target = target;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.fixedDeltaTime);
        transform.LookAt(_target);
        transform.Rotate(new Vector3(90, 0, 0));
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
    
}

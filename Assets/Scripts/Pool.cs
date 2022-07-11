using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    public T _prefab { get; }
    public bool _autoExpand { get; set; }
    public Transform _container { get; }

    private List<T> _pool;

    public Pool(T prefab, bool autoExpand, int count)
    {
        _prefab = prefab;
        _autoExpand = autoExpand;

        CreatePool(count);
    }
    public Pool(T prefab, bool autoExpand, int count, Transform container)
    {
        _prefab = prefab;
        _autoExpand = autoExpand;
        _container = container;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        T createdObject = UnityEngine.Object.Instantiate(_prefab,_container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        this._pool.Add(createdObject);
        return createdObject;
    }
    public bool HasFreeElement(out T element)
    {
        foreach (var mono in _pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;

    }
    public T GetFreeElement()
    {
        if (HasFreeElement(out T element))
        {
            return element;
        }
        if (_autoExpand)
        {
            return this.CreateObject(true);
        }

        throw new Exception("This pool has not free elements");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerMovement.GoToFirstLevel();
            gameObject.SetActive(false);
        }
    }
}

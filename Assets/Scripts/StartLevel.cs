using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    public bool LevelStarted { get; private set; }

    private void Start()
    {
        LevelStarted = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerMovement.GoToFirstLevel();
            LevelStarted = true;
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{
    public void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;

    public void OnEnable()
    {
        Enemy.OnPlayerDeath += EnableGameOverMenu;
    }
    
    public void OnDisable()
    {
        Enemy.OnPlayerDeath -= EnableGameOverMenu;
    }
    
    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
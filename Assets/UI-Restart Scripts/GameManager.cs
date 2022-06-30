using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static event Action OnEnemyDeath;
    public GameObject GameEndMenu;


    [SerializeField] TextMeshProUGUI enemiesLeftText; 
    List<Enemy> enemies = new List<Enemy>();



    private void OnEnable()
    {
        Enemy.OnEnemyKilled += HandleEnemyDefeated;

    }

    private void OnDisable()
    {
        Enemy.OnEnemyKilled -= HandleEnemyDefeated;
    }

    private void Winner(){
        if(enemies.Count == 0){
            OnEnemyDeath?.Invoke();
        }
    }

    private void Awake()
    {
        enemies = GameObject.FindObjectsOfType<Enemy>().ToList();
        UpdateEnemiesLeftText();
    }

    void HandleEnemyDefeated(Enemy enemy)
    {
        if (enemies.Remove(enemy))
        { 
            UpdateEnemiesLeftText();
            if(enemies.Count == 0)
            {
                Winner();
                GameEndMenu.SetActive(true);
                
            }
            
        }
    }
    void UpdateEnemiesLeftText()
    {
        enemiesLeftText.text = $"Enemies Left: {enemies.Count}";
    }
}
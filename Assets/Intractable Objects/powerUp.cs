using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public PowerupEffect PowerupEffect;
    
    public Animator animator;
    
    private void OnEnable()
    {
        Enemy.OnPlayerDeath += DisableAnimation;
        GameManager.OnEnemyDeath += DisableAnimation;
    }
    
    private void OnDisable()
    {
        Enemy.OnPlayerDeath -= DisableAnimation;
        GameManager.OnEnemyDeath -= DisableAnimation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<Enemy>())
        {
            Destroy(gameObject);
        }
        PowerupEffect.Apply(collision.gameObject);
    }

    private void DisableAnimation()
    {
        animator.enabled = false;
    }
}

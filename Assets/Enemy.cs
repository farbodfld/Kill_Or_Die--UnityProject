using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem explosion;
    
    public static event Action OnPlayerDeath;
    public static event Action<Enemy> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 3f;

    [SerializeField] private float moveSpeed = 5f; 
    Rigidbody2D rb; 
    Transform target;
    Vector2 moveDirection;

    private void OnEnable()
    { 
        OnPlayerDeath += DisableEnemyMovement;
    }

    private void OnDisable()
    {
        OnPlayerDeath -= DisableEnemyMovement;

    }
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        EnableEnemyMovement();
        health = maxHealth;
        target = PlayerController.Instance.transform;
        //gameObject.GetComponent<ParticleSystem>().Pause();
        //gameObject.GetComponent<ParticleSystem>().Stop (true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    private void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
    
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
            if (!explosion.isPlaying)
            {
                explosion.Play();
            }
            OnEnemyKilled?.Invoke(this);
            //explosion.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            Debug.Log("mordii olaghhh");
            OnPlayerDeath?.Invoke();
        }
    }
    
    
    private void DisableEnemyMovement()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }
    
    private void EnableEnemyMovement()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
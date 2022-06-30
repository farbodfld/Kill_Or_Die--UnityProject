using Unity;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        // THIS IS WHERE YOU CHECK IF YOUR HITTING ENEMY
        // DAMAGE ENEMY
        if (col.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }
        gameObject.SetActive(false);
    }
}

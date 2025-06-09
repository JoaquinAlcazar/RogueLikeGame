using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : AProjectile
{
    public int damage = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Debug.Log($"EnemyProjectile dealt {damage} damage to Player.");
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Destroy(gameObject, 5f);
    }
}

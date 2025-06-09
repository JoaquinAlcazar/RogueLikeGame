using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    public int timeAlive;
    public Vector3 launchDirection;
    public float speed;
    public int bulletDamage = 40; 

    void Start()
    {
        gameObject.transform.SetParent(null);

        Collider2D playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        Collider2D bulletCollider = GetComponent<Collider2D>();

        if (playerCollider != null && bulletCollider != null)
        {
            Physics2D.IgnoreCollision(playerCollider, bulletCollider);
        }

        Debug.Log("Bullet creado");
        StartCoroutine(autodestruction());

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        launchDirection = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(launchDirection.y, launchDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }


    void Update()
    {
        transform.position += new Vector3(launchDirection.x * speed, launchDirection.y * speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyHitbox hitbox = collision.collider.GetComponent<EnemyHitbox>();
        if (hitbox != null && hitbox.owner != null)
        {
            hitbox.owner.TakeDamage(bulletDamage);
            Debug.Log($"Bullet dealt {bulletDamage} damage to {hitbox.owner.gameObject.name}.");
        }

        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHitbox hitbox = collision.GetComponent<EnemyHitbox>();
        if (hitbox != null && hitbox.owner != null)
        {
            hitbox.owner.TakeDamage(bulletDamage);
            Debug.Log($"Bullet dealt {bulletDamage} damage to {hitbox.owner.gameObject.name}.");
        }

        Destroy(gameObject);
    }


    IEnumerator autodestruction()
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(gameObject);
    }
}

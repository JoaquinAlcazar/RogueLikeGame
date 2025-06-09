using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : AEnemy
{
    public float moveSpeed = 2f;
    public float turretActivationDistance = 5f;
    public float fireCooldown = 1.5f;

    public GameObject projectilePrefab;
    public Transform firePoint;

    private State currentState = State.Moving;
    private Transform player;
    private float lastFireTime = 0f;

    private enum State
    {
        Moving,
        Turret
    }

    void Start()
    {
        // Buscamos al jugador
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        switch (currentState)
        {
            case State.Moving:
                MoveTowardsPlayer();

                // Cambiar a modo torreta si está suficientemente cerca
                if (distanceToPlayer <= turretActivationDistance)
                {
                    currentState = State.Turret;
                }
                break;

            case State.Turret:
                // Disparar hacia el jugador
                FireAtPlayer();

                // Opcional: volver a moverse si el jugador se aleja
                if (distanceToPlayer > turretActivationDistance + 1f)
                {
                    currentState = State.Moving;
                }
                break;
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }

    private void FireAtPlayer()
    {
        if (Time.time - lastFireTime >= fireCooldown)
        {
            lastFireTime = Time.time;

            // Instanciar proyectil
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            // Calcular dirección hacia el jugador
            Vector3 direction = (player.position - firePoint.position).normalized;

            // Configurar la velocidad de la bala (asumimos que el prefab tiene un Rigidbody2D y un script AProjectile o similar)
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float projectileSpeed = 7f; // puedes hacer pública esta variable si quieres
                rb.velocity = direction * projectileSpeed;
            }

            Debug.Log("TurretEnemy fired at player.");
        }
    }
}

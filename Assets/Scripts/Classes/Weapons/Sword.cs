using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public float distanceFromCharacter = 1.5f;
    private SpriteRenderer spriteRenderer;

    public float pushForce = 5f;
    public int swordDamage = 25;
    public float damageCooldown = 0.2f; // Tiempo mínimo entre golpes al mismo enemigo

    // Diccionario para guardar enemigos golpeados y el tiempo del último golpe
    private Dictionary<ACharacter, float> hitEnemiesCooldown = new Dictionary<ACharacter, float>();

    void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // La espada necesita hacer override para agregar un desplazamiento hacia adelante constantemente para darle el efecto que quería darle.
    protected override void rotate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.parent.position).normalized;
        transform.position = transform.parent.position + direction * distanceFromCharacter;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (angle > 90 || angle < -90)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }

    private void Update()
    {
        // Limpiar enemigos cuyo cooldown ya expiró
        List<ACharacter> toRemove = new List<ACharacter>();
        foreach (var entry in hitEnemiesCooldown)
        {
            if (Time.time - entry.Value > damageCooldown)
            {
                toRemove.Add(entry.Key);
            }
        }
        foreach (var enemy in toRemove)
        {
            hitEnemiesCooldown.Remove(enemy);
        }
        rotate();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHitbox hitbox = other.GetComponent<EnemyHitbox>();
        if (hitbox != null && hitbox.owner != null)
        {
            ACharacter enemy = hitbox.owner;

            // Verificar cooldown para no hacer daño repetido en poco tiempo
            if (hitEnemiesCooldown.ContainsKey(enemy))
                return;

            // Aplicar fuerza de empuje
            Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                Vector2 pushDirection = (hitbox.transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            }

            // Aplicar daño
            enemy.TakeDamage(swordDamage);
            Debug.Log($"Sword dealt {swordDamage} damage to {enemy.gameObject.name}.");

            // Registrar el golpe con tiempo actual
            hitEnemiesCooldown[enemy] = Time.time;
        }
    }
}

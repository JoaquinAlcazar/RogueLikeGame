using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    private float dmgCD;
    private bool inCD;
    private CapsuleCollider2D collider;

    public int flameDamage = 10; // Daño por tick

    void Start()
    {
        dmgCD = 0.5f;
        inCD = false;
        collider = GetComponent<CapsuleCollider2D>();
        collider.isTrigger = true;
        collider.enabled = false;
    }

    void Update()
    {
        // Solo se activa el collider si no está en cooldown.
        if (!inCD)
        {
            collider.enabled = true;
        }
    }

    IEnumerator Cooldown()
    {
        inCD = true;
        collider.enabled = false;
        yield return new WaitForSeconds(dmgCD);
        inCD = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHitbox hitbox = collision.GetComponent<EnemyHitbox>();
        if (hitbox != null && hitbox.owner != null)
        {
            Debug.Log("Flames hit enemy: " + hitbox.owner.gameObject.name);

            // Aplicar daño
            hitbox.owner.TakeDamage(flameDamage);
            Debug.Log($"Flames dealt {flameDamage} damage to {hitbox.owner.gameObject.name}.");

            // Iniciar cooldown después de hacer daño
            StartCoroutine(Cooldown());
        }
    }
}

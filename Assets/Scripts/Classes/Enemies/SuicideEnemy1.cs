using System.Collections;
using UnityEngine;

public class SuicideEnemy : AEnemy
{
    [Header("Suicide Enemy Settings")]
    public float moveSpeed = 3f;
    public float explodeRange = 2f;
    public float explodeDelay = 2f;
    public GameObject explosionEffectPrefab;

    [Header("Explosion Damage")]
    public float explosionRadius = 2.5f;
    public int explosionDamage = 50;
    public LayerMask playerLayer;

    private Transform player;
    private bool isPreparingToExplode = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (!isPreparingToExplode)
        {
            if (distanceToPlayer > explodeRange)
            {
                // Move towards player
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
            }
            else
            {
                // Inside explode range  start explosion countdown
                StartCoroutine(ExplodeSequence());
            }
        }
    }

    private IEnumerator ExplodeSequence()
    {
        isPreparingToExplode = true;

        // (Optional) Visual feedback  cambiar color, activar animación, escalar el sprite...
        Debug.Log("Preparing to explode!");

        yield return new WaitForSeconds(explodeDelay);

        Explode();
    }

    private void Explode()
    {
        // Instantiate explosion effect
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }

        // Damage to player if in range
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, playerLayer);

        foreach (var hit in hits)
        {
            ACharacter character = hit.GetComponent<ACharacter>();
            if (character != null)
            {
                Debug.Log($"Dealing {explosionDamage} damage to {hit.gameObject.name}.");
                character.TakeDamage(explosionDamage);
            }
        }

        // Drop gold and exp
        Drop();

        // Destroy self
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize explosion radius in editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}

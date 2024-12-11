using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : AProjectile
{
    public float explosionRange;
    public CircleCollider2D circleCollider;
    public Animator animator;
    public AnimationClip clip;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public float launchForce;

    private Vector2 launchDirection;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        circleCollider.isTrigger = true;
        circleCollider.enabled = false;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Asegúrate de que Z sea 0 para 2D
        launchDirection = (mousePosition - transform.position).normalized;

        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.magnitude < 0.1f && launchDirection != Vector2.zero)
        {
            rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
            launchDirection = Vector2.zero; // Evitar que la fuerza se aplique nuevamente
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(3);
        spriteRenderer.sprite = null;
        circleCollider.enabled = false;
        PlayExplosionClip();
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }

    void PlayExplosionClip()
    {
        animator.SetTrigger("Explode");
    }

}

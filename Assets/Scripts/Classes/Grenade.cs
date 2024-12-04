using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : AProjectile
{
    public float explosionRange;
    public CircleCollider2D circleCollider;
    private Animator animator;
    public AnimationClip clip;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.isTrigger = true;
        circleCollider.enabled = false;
        new StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Explode()
    {
        new WaitForSeconds(3);
        spriteRenderer.enabled = false;
        circleCollider.enabled = false;
        return null;
    }

    void PlayExplosionClip()
    {
        animator.Play("GrenadeExplosion");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : AProjectile
{
    public float explosionRange;
    public CircleCollider2D circleCollider;
    private Animation animator;
    public AnimationClip clip;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animation>();
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.isTrigger = true;
        circleCollider.enabled = false;
        animator.AddClip(clip, clip.name);
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(3);
        spriteRenderer.enabled = false;
        circleCollider.enabled = false;
        PlayExplosionClip();
        yield return new WaitForSeconds(clip.length);
        Destroy(gameObject);
    }

    void PlayExplosionClip()
    {
        animator.Play(clip.name);
    }
}

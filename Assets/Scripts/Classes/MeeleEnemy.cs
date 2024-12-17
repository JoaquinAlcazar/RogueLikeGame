using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MeeleEnemy : AEnemy
{
    public float explosionRange;
    public float speed;
    private float initialSpeed;
    private Transform playerPos;
    private Vector3 direction;
    private CircleCollider2D explosionCollider;
    private RaycastHit hit;
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        initialSpeed = speed;
        explosionCollider = GetComponent<CircleCollider2D>();
        explosionCollider.radius = explosionRange;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (HP < 1) Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, Time.deltaTime * speed);
        direction = (playerPos.position - transform.position).normalized;
        Vector3 rayOrigin = transform.position + direction * 1f;

        Debug.DrawRay(rayOrigin, direction * explosionRange, Color.green);
        if (Physics.Raycast(rayOrigin, direction * explosionRange, out hit, explosionRange)) Debug.Log(hit.transform.tag);
    }

    IEnumerator Explode()
    {
        speed = 0;
        new WaitForSeconds(2);
        explosionCollider.enabled = true;
        yield return StartCoroutine(explosionAnimation());
        Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile") HP -= 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile") HP -= 1;
    }

    IEnumerator explosionAnimation()
    {
        //reproducir animacíón de explosión
        return null;
    }
}

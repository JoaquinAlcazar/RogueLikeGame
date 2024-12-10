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

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        initialSpeed = speed;
        explosionCollider = GetComponent<CircleCollider2D>();
        explosionCollider.radius = explosionRange;
        explosionCollider.enabled = false;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, Time.deltaTime * speed);
        direction = (playerPos.position - transform.position).normalized;
        RaycastHit hit;

        Debug.DrawRay(transform.position, direction * explosionRange, Color.green);
        Physics.Raycast(transform.position, direction, out hit, explosionRange);
             
        if (hit.transform == playerPos)
        {
            Debug.Log("Hit");
            speed = 0;
            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        new WaitForSeconds(2);
        explosionCollider.enabled = true;
        yield return StartCoroutine(explosionAnimation());
        Destroy(gameObject);

    }

    IEnumerator explosionAnimation()
    {
        //reproducir animacíón de explosión
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleEnemy : AEnemy
{
    public float explosionRange;
    public float speed;
    private float initialSpeed;
    private Transform playerPos;
    private Ray ray;
    private RaycastHit hit;
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
        ray = new Ray(transform.position, playerPos.position);

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log("Hit");
            if (hit.transform.tag == "Player")
            {
                speed = 0;
                StartCoroutine(Explode());
            }
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

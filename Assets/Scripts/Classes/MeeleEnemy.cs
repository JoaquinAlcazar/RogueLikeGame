using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleEnemy : AEnemy
{
    private float explosionRange;
    public float speed;
    private float initialSpeed;
    private Transform playerPos;
    private Ray ray;
    private RaycastHit hit;
    public float rayDistance;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        initialSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, Time.deltaTime * speed);
        ray = new Ray(transform.position, playerPos.position);
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.transform.tag == "Player") speed = 0;
            else speed = initialSpeed;
        }

    }

    void Explode()
    {

    }
}

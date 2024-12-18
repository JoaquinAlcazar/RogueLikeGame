using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    public int timeAlive;
    public Vector3 launchDirection;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.SetParent(null);
        Debug.Log("Bullet creado");
        StartCoroutine(autodestruction());
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        launchDirection = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(launchDirection.y, launchDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3((launchDirection.x*speed), (launchDirection.y * speed), 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }


    IEnumerator autodestruction()
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(gameObject);
    }
}

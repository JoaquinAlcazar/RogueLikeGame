using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Weapon
{
    public Bullet bullet;
    private Bullet instancia;
    private SpriteRenderer spriteRenderer;
    private bool inCD;
    public int cdTime;
    // Start is called before the first frame update
    void Start()
    {
        inCD = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
        if (Input.GetMouseButtonDown(0))
        {
            if (inCD == false)
            {
                Attack();
                inCD = true;
                StartCoroutine(Cooldown());
            }
        }
    }

    void rotate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Mathf.Abs(angle) > 90)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }

        
    }

    IEnumerator Cooldown()
    {
        Debug.Log("CD Enter");
        yield return new WaitForSeconds(cdTime);
        Debug.Log("CD Exit");
        inCD = false;
    }

    void Attack()
    {
        instancia = Instantiate(bullet, gameObject.transform);
        instancia.transform.localScale = new Vector3(2, 2, 1);
    }
}

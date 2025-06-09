using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Weapon
{
    public Grenade grenade;
    private Grenade instancia;
    private SpriteRenderer spriteRenderer;
    private bool inCD;
    void Start()
    {
        inCD = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
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

        if (Input.GetMouseButtonDown(0))
        {
            if (inCD == false) { 
                Attack(); 
                inCD = true;
                StartCoroutine(Cooldown());
            }
        }
    }

    void Attack ()
    {
        instancia = Instantiate(grenade, gameObject.transform);
        instancia.transform.localScale = new Vector3(1,1,1);
        gameObject.GetComponent<AudioSource>().Play();
    }

    IEnumerator Cooldown ()
    {
        Debug.Log("CD Enter");
        yield return new WaitForSeconds(1);
        Debug.Log("CD Exit");
        inCD = false;
    }
}

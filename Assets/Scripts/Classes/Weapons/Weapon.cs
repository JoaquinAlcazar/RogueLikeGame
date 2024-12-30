using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    protected float useSpeed;
    protected SpriteRenderer spriteRenderer;
    protected bool inCD;

    protected void Start()
    {

    }


    protected void Update()
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

    protected void rotate()
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

    protected void Attack()
    {

    }

    protected void Updgrade()
    {

    }

    protected IEnumerator Cooldown()
    {
        Debug.Log("CD Enter");
        yield return new WaitForSeconds(1);
        Debug.Log("CD Exit");
        inCD = false;
    }
}

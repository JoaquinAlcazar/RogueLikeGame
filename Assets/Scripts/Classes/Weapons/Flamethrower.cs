using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{
    private GameObject flames;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        flames = GameObject.Find("Flames");
        flames.SetActive(false);
        Debug.Log(flames);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (Input.GetMouseButton(0))
        {
            flames.SetActive(true);
        }
        else
        {
            flames.SetActive(false);
        }
    }

    void Attack()
    {
        Debug.Log("Flamethrower");
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f);
    }
}

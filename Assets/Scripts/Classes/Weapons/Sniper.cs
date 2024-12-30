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
        base.Update();
    }

    void Attack()
    {
        instancia = Instantiate(bullet, gameObject.transform);
        instancia.transform.localScale = new Vector3(2, 2, 1);
    }
}

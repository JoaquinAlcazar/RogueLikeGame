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
    public float bulletOffset = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        inCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        Vector3 playerPosition = transform.parent.position; // El arma está en WeaponHolder hijo del player
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = (mousePosition - playerPosition).normalized;

        Vector3 spawnPosition = playerPosition + direction * bulletOffset;

        // Instancia el proyectil en la posición calculada
        instancia = Instantiate(bullet, spawnPosition, Quaternion.LookRotation(Vector3.forward, direction));

        // Ajusta la escala del proyectil si es necesario
        instancia.transform.localScale = new Vector3(5, 5, 1);

        gameObject.GetComponent<AudioSource>().Play();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    private float dmgCD;
    private bool inCD;
    private CapsuleCollider2D collider;
    // Start is called before the first frame update

    void Start()
    {
        dmgCD = 0.5f;
        inCD = false;
        collider = GetComponent<CapsuleCollider2D>();
        collider.isTrigger = true;
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Solo se activa el collider si no está en cooldown.
        if (!inCD)
        {
            collider.enabled = true;
        }
    }

    IEnumerator Cooldown()
    {
        inCD = true;
        collider.enabled = false;
        yield return new WaitForSeconds(dmgCD);
        inCD = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Flames hit enemy: " + collision.gameObject.name);
            StartCoroutine(Cooldown());
        }
    }

}

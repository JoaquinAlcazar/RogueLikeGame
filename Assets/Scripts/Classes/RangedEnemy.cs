using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : AEnemy
{
    public bool turretMode;
    // Start is called before the first frame update
    void Start()
    {
        turretMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 raycastDir = GameObject.FindWithTag("Player").transform.position - transform.position;
        Physics.Raycast(transform.position, raycastDir, out hit);

        if (hit.transform.gameObject.tag == "Player")
        {           
            ToogleTurretMode();
        }
    }

    void ToogleTurretMode() 
    {
        
    }

    void Shoot()
    {

    }
}

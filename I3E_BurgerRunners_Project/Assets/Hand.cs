using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public int gunDamage;
    public Camera cam;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Debug.Log("We hit" + hit.transform.name);

            EnemyHPScript enemyHealth = hit.transform.GetComponent<EnemyHPScript>();
            if(enemyHealth != null)
            {
                enemyHealth.DeductHealth(gunDamage);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public int gunDamage;
    public Camera cam;
    public Transform leafSpawnPoint;
    public GameObject leafPrefab;
    public float leafSpeed = 10;
    public GameObject wizardHand;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            var bullet = Instantiate(leafPrefab, cam.transform.position, cam.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = cam.transform.forward * leafSpeed;
            wizardHand.GetComponent<Animator>().Play("WizardHand");

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

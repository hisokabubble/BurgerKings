using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPScript : MonoBehaviour
{
    public float enemyHealth = 100f;

    public void DeductHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;
        if(enemyHealth <= 0)
        {
            EnemyDead();
        }
    }

    void EnemyDead()
    {
        Destroy(this.gameObject);
    }
}

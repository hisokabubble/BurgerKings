using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPScript : MonoBehaviour
{
    public float enemyHealth = 100f;
    public float maxHealth = 100f;
    public GameObject winScreen;

    [SerializeField] private Healthbar healthBar;

    public void DeductHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;
        healthBar.UpdateHealthBar(maxHealth, enemyHealth);
        if(enemyHealth <= 0)
        {
            EnemyDead();
        }
    }

   
    void EnemyDead()
    {
        Destroy(this.gameObject);
        winScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}

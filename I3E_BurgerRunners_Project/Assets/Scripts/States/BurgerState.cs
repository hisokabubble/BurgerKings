using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BurgerState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;
    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if (shotTimer > enemy.fireRate)
            {
                Shoot();
            }
            if (moveTimer > Random.Range(3, 9))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 10)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public void Shoot()
    {
        Transform gunbarrel = enemy.gunBarrel;
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Eclipse_VFX") as GameObject, gunbarrel.position, enemy.transform.rotation);
        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-2f, 2f), Vector3.up) * shootDirection * 40;
        Debug.Log("Shoot");
        shotTimer = 0;
    }


}

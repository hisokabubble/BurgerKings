using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    public string currentState;
    public string nextState;

    public float idleTime;

    private NavMeshAgent agent;

    private Transform playerToChase;

    public GameObject monsterObject;

    public Transform[] checkpoints;

    private int currentCheckpointIndex;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = "Idle";
        nextState = currentState;
        SwitchState();
        
    }

    private void Update()
    {
        if(currentState != nextState)
        {
            currentState = nextState;
        }
    }

    public void SeePlayer(Transform player)
    {
        playerToChase = player;
        nextState = "Chase";
    }
    void SwitchState()
    {
        StartCoroutine(currentState);
    }

    IEnumerator Idle()
    {
        while(currentState == "Idle")
        {
            yield return new WaitForSeconds(idleTime);

            nextState = "Patrol";
            
        }
        SwitchState();
    }

    IEnumerator Patrol()
    {

        agent.SetDestination(checkpoints[currentCheckpointIndex].position);
        bool hasReached = false;
        

        while (currentState == "Patrol")
        {
           

            yield return null;
            if (!hasReached)
            {
                monsterObject.GetComponent<Animator>().Play("Walking");

                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    hasReached = true;
                    
                    nextState = "Idle";
                    monsterObject.GetComponent<Animator>().Play("Zombie Scratch Idle");

                    ++currentCheckpointIndex;

                    if(currentCheckpointIndex >= checkpoints.Length)
                    {
                        currentCheckpointIndex = 0;
                    }
                }
            }
        }

        SwitchState();
    }
    IEnumerator Chase()
    {
        while(currentState == "Chase")
        {
            yield return null;
            if(playerToChase != null)
            {
                agent.SetDestination(playerToChase.position);
                monsterObject.GetComponent<Animator>().Play("Walking");
            }
            else
            {
                nextState = "Idle";
                monsterObject.GetComponent<Animator>().Play("Zombie Scratch Idle");
            }
        }
        SwitchState();
    }
}

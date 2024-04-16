using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

public class Bot : Character
{
    // Start is called before the first frame update

    public NavMeshAgent agent;
    private float patrolTime =2f;
    private float sphereRadius = 50f;
    private Vector3 randomPosMove;
    private float idleTime, idleTimeCounter;
    private Bounds bounds;
    private Indicator waypointIndicator;
    public Indicator characterUI;
    private Vector3 destination;


    

    public override void Move()
    {
        if (!isMoving)
        {
            idleTime = 0.01f;
        }
        //print(idleTimeCounter);
        idleTimeCounter += Time.deltaTime;
        if (idleTimeCounter > idleTime)
        {
            ChangeState(new PatrolState());
            idleTimeCounter = 0;
        }

        idleTime = Random.Range(1f, 2f);
        isMoving = true;
    }
    public override void Patrol()
    {
        agent.isStopped = false;
        agent.SetDestination(randomPosMove);
        ResetPatrol();
    }
    public override void FindPosition()
    {
        randomPosMove = LevelManager.Ins.level.RandomPos();
    }
    public override void StopPatrol()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
    }
    public override void ResetPatrol()
    {
        patrolTime -= Time.deltaTime;
        //print("patrolTime :" + patrolTime);
        if (patrolTime < 0)
        {
            ChangeState(new IdleState());
            patrolTime = Random.Range(2f, 3f);
        }
    }
  

    public void SetUpIndicator()
    {
        waypointIndicator = Instantiate(characterUI, transform.position, Quaternion.identity);
        waypointIndicator.OnInit(this, transform);
    }
    //public void Setdestination(Vector3 point)
    //{
    //    destination = point;
    //    agent.enabled = true;
    //    agent.SetDestination(destination);
    //}
}

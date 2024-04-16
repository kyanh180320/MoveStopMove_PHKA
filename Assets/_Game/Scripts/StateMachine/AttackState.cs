using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{

    public void OnEnter(Character t)
    {
        if (t.isAttack)
        {
            t.Attack();
        }
    }

    public void OnExecute(Character t)
    {
        t.StopPatrol();
        t.Move();

    }

    public void OnExit(Character t)
    {
        //t.ResetAttack();

    }

}

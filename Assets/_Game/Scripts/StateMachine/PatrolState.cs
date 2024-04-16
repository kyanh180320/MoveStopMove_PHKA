using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    public void OnEnter(Character t)
    {
        t.ChangeAnim(Constans.ANIM_RUN);
        t.FindPosition();
    }

    public void OnExecute(Character t)
    {
        if (!t.isAttack)
        {
            t.Patrol();
        }
        else
        {
            t.ChangeState(new IdleState());
        }
    }

    public void OnExit(Character t)
    {
        t.StopPatrol();
    }

    // Start is called before the first frame update
}

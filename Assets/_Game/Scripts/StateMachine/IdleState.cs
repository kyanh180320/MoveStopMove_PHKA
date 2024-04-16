using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private float timer = 0;
    public void OnEnter(Character t)
    {
        t.ChangeAnim(Constans.ANIM_IDLE);
    }
    public void OnExecute(Character t)
    {
        if (!t.isAttack)
        {
            t.Move();
        }
        else
        {
            timer+= Time.deltaTime;
            if (timer > 0.5f)
            {
                t.ChangeState(new AttackState());
            }
        }
    }

    public void OnExit(Character t)
    {

    }

}

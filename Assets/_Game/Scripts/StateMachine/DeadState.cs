using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    public void OnEnter(Character t)
    {
        t.ChangeAnim(Constans.ANIM_DEAD);
    }

    public void OnExecute(Character t)
    {
    }

    public void OnExit(Character t)
    {
    }

    // Start is called before the first frame update

}

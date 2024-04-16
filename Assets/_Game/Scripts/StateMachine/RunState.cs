using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState
{
    public void OnEnter(Character t)
    {
        t.ChangeAnim(Constans.ANIM_RUN);
    }

    public void OnExecute(Character t)
    {
      
    }

    public void OnExit(Character t)
    {

    }

}

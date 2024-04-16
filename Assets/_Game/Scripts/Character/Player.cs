using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Player : Character
{
    // Start is called before the first frame update
    public FloatingJoystick joystick;
    //public Transform spawnBulletPos;
    public Vector3 movement;
    public float timerDelayAnim = 0;
    private bool checkDelayAttack = false;



    protected override void Update()
    {
        if (!isDead)
        {
            if (Input.GetMouseButton(0))
            {
                checkDelayAttack = false;
                ChangeAnim(Constans.ANIM_RUN);
                Moving();
                timerDelayAnim = 0;
                timerCountDelayAttack = 0;


            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (throwCoroutine != null)
                {
                    StopCoroutine(throwCoroutine);
                    throwCoroutine = null;
                }
                checkDelayAttack = true;
                if (!isAttack)
                {
                    ChangeAnim(Constans.ANIM_IDLE);
                }
            
            }
            else if (checkDelayAttack) // delay idle -> attack 
            {
                if (isAttack)
                {
                    ChangeAnim(Constans.ANIM_IDLE);
                    timerDelayAnim += Time.deltaTime;
                    if (timerDelayAnim > 0.2f)
                    {
                        Attack();
                    }
                }
            }
        }
        else
        {
            ChangeAnim(Constans.ANIM_DEAD);
        }




    }

 
  

    public void Moving()
    {
        HandleMovementInput();
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.deltaTime);
    }

    public void HandleMovementInput()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        movement = new Vector3(horizontal, 0, vertical);


        if (horizontal != 0 || vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

    }
}


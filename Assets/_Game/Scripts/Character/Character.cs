using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Unity.VisualScripting;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public float moveSpeed;
    public Animator animator;
    private string currentAnimName;
    public List<Character> targets = new List<Character>();
    public Vector3 targetPos;
    public GameObject weaponHolder;
    public GameObject circleOutline;
    public Transform spawnProjectilePos;
    // boolState;
    public IState currentState;
    public bool isAttack;
    public bool isMoving;
    public bool isDead;
    public Character currentTarget;
    public Vector3 directionTarget;
    public float timerDelayWeaponHolderTrue;
    public float timerDelayWeaponHolderFalse;
    public float timerDelayAttack;
    public float timerCountDelayAttack = 0;

    //public ChangeWeaponTypeData changeWeaponTypeData;
    public WeaponManager currentWeaponManager;
    public List<WeaponData> weaponDatas = new List<WeaponData>();
    public WeaponType currentWeaponType;

    public Coroutine throwCoroutine;
    private void Start()
    {
        OnInit();
    }
    public void OnInit()
    {
        currentState = new IdleState();
        ChangeWeapon(currentWeaponType);
    }

    public virtual void Patrol() { }
    public virtual void Move() { }
    public virtual void FindPosition() { }
    public virtual void StopPatrol() { }
    public virtual void ResetPatrol() { }

    public void Attack()
    {
        ChangeAnim(Constans.ANIM_ATTACK);
        LookTarget();
        if (targets.Count > 0)
        {
            DelayThrow();
            DelayActiveWeaponHolder();

        }
        isAttack = false;
    }

    public IEnumerator DelayThrowCoroutine()
    {
        while (true)
        {
            yield return null;

            timerCountDelayAttack += Time.deltaTime;

            if (timerCountDelayAttack > timerDelayAttack)
            {
                currentWeaponManager.Throw(this);
                timerCountDelayAttack = 0f;
                break;
            }
        }
    }

    public void DelayThrow()
    {
       throwCoroutine = StartCoroutine(DelayThrowCoroutine());
    }
   

    public void LookTarget()
    {
        if (targets.Count > 0)
        {
            directionTarget = targets[0].gameObject.transform.position - transform.position;
            directionTarget.y = 0;
            transform.rotation = Quaternion.LookRotation(directionTarget);
        }
    }


    public void DelayActiveWeaponHolder()
    {
        StartCoroutine(DelayActiveWeaponHolderCoroutine());
    }
    IEnumerator DelayActiveWeaponHolderCoroutine()
    {
        yield return new WaitForSeconds(timerDelayWeaponHolderFalse);
        weaponHolder.SetActive(false);
        yield return new WaitForSeconds(timerDelayWeaponHolderTrue);
        weaponHolder.SetActive(true);
    }



  



    public void DelayAttackAnim()
    {
        StartCoroutine(DelayAttackAnimCouroutine());
    }
    IEnumerator DelayAttackAnimCouroutine()
    {
        ChangeAnim(Constans.ANIM_IDLE);
        yield return new WaitForSeconds(0.2f);
        ChangeAnim(Constans.ANIM_ATTACK);

    }

    public void ChangeWeapon(WeaponType weaponType)
    {
        this.currentWeaponType = weaponType;
        if (currentWeaponManager != null)
        {
            Destroy(currentWeaponManager);
        }
        currentWeaponManager = Instantiate(GetWeaponManager(weaponType), weaponHolder.transform);


    }
    public WeaponManager GetWeaponManager(WeaponType weaponType)
    {
        return weaponDatas[(int)weaponType].weaponManager;
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            animator.ResetTrigger(animName);
            currentAnimName = animName;
            animator.SetTrigger(currentAnimName);
        }
    }
    public void ChangeState(IState state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    protected virtual void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }


    public virtual void Die(Character owner, Character target)
    {
        isDead = true;
        circleOutline.SetActive(false);
        ChangeState(new DeadState());
        owner.targets.Remove(target);
        DelayDead(target);

    }
    public void DelayDead( Character target)
    {
        print("Delay dead");
        StartCoroutine(DelayDeadCoroutine(target));
    }
    IEnumerator DelayDeadCoroutine(Character target)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(target.gameObject);
    }




}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCircle : MonoBehaviour
{
    // Start is called before the first frame update
    public Character characterOwner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constans.TAG_CHARACTER))
        {
            Character target = Cache.GetCharacter(other);
            if (target != characterOwner && !target.isDead)
            {
                characterOwner.targets.Add(target);
                characterOwner.isAttack = true;
                if (characterOwner is Player && target is Bot)
                {
                    target.circleOutline.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Constans.TAG_CHARACTER))
        {
            Character target = Cache.GetCharacter(other);
            if(target != characterOwner && !target.isDead)
            {
                if (characterOwner.targets.Contains(target))
                {
                    characterOwner.targets.Remove(target);
                    characterOwner.isAttack = false;
                    if (characterOwner is Player && target is Bot)
                    {
                        target.circleOutline.SetActive(false);
                    }
                }
            }
            
        }
    }
}

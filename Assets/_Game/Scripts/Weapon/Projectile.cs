using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    public GameObject imageProjectile;
    public Vector3 directionTarget;
    private float distance = 0;
    private WeaponData weaponData;
    private Character owner;
 
    void Update()
    {
        if(weaponData.weaponType == WeaponType.Axe)
        {
            RotateProjectile();
            OnDespawnProjectile();
        }
        else if(weaponData.weaponType == WeaponType.Knife)
        {
            RotateProjectileToTarget();
            OnDespawnProjectile();
        }
        else if(weaponData.weaponType == WeaponType.Boomerang)
        {
            RotateProjectile();
            ComeBackProjectile();
        }
        Fly();
    }
    public void OnInit(Character owner, Vector3 directionTarget, WeaponData weaponData)
    {
        this.owner = owner;
        this.directionTarget = directionTarget;
        this.weaponData = weaponData;
    }
    private void Fly()
    {
        transform.Translate(directionTarget * weaponData.speedFly * Time.deltaTime);
    }
    private void RotateProjectileToTarget()
    {
        imageProjectile.transform.rotation = Quaternion.LookRotation(directionTarget);
    }
    private void OnDespawnProjectile()
    {
        
        distance += weaponData.speedFly * Time.deltaTime;
        if (distance > weaponData.range)
        {
            Destroy(gameObject);
        }
    }

    private void RotateProjectile()
    {
        imageProjectile.transform.Rotate(Vector3.up * weaponData.rotateSpeed * Time.deltaTime);
    }
    private void ComeBackProjectile()
    {
        distance += weaponData.speedFly * Time.deltaTime;
        if (distance > weaponData.range)
        {
            transform.position = Vector3.MoveTowards(transform.position, owner.transform.position, weaponData.speedFly *2 * Time.deltaTime);
            if (Vector3.Distance(transform.position, owner.transform.position) < 1f)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constans.TAG_CHARACTER))
        {
            Character otherCharacter = Cache.GetCharacter(other);
            if (otherCharacter != owner)
            {
                otherCharacter.Die(owner, otherCharacter);
            }
        }
    }
 


}

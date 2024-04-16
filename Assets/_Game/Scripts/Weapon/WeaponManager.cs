using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Start is called before the first frame update
    //public WeaponData weaponData;
    public WeaponData weaponData;

 
    public void Throw(Character owner)
    {
        Projectile projectileClone = Instantiate(weaponData.modelProjectile, owner.spawnProjectilePos.position, Quaternion.identity);
        //Projectile projectileClone = SimplePool.Spawn<Projectile>(weaponData.modelProjectile, owner.spawnProjectilePos.position, Quaternion.identity);
        projectileClone.OnInit(owner, owner.directionTarget.normalized, weaponData);
    }
  
}

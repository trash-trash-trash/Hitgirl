using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    
    public HitgirlPlayerStats _PlayerStats;

    //declares NPCBase for stats
    public WeaponsBase _Base;

    //holds the Weapon's name. used for Inventory descriptions and possibly equip logic
    string myName;

    string weaponType;

    int maxAmmo;
    int currentAmmo;

    int damage;

    float fireRate;

    float reloadTime;

    //determines if the Player is holding the weapon
    //add Guard logic to this as well?
    bool isEquipped;

    //determines if the Weapon is holstered or active
    bool holstered;

    //determines if the Weapon is currently firing to prevent shooting from stacking
    //Weapons fire as fast as fireRate
    bool canShoot;

    private void Awake()
    {
        _PlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<HitgirlPlayerStats>();

        myName = _Base.Name;

        maxAmmo = _Base.MaxAmmo;
        currentAmmo = maxAmmo;

        weaponType = _Base.WeaponType;

        damage = _Base.Damage;

        fireRate = _Base.FireRate;

        reloadTime = _Base.ReloadTime;

        isEquipped = true;

        canShoot = true;

        holstered = true;
    }

    private void Update()
    {
        if (isEquipped)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Shoot());
            }

            if (Input.GetButtonDown("Fire2"))
            {
                //Aim
            }

            if (Input.GetKeyDown("r"))
            {
                StartCoroutine(Reload());
            }

            if (Input.GetKeyDown("h"))
            {
                Holster();
            }
        }

    }

    private IEnumerator Shoot()
    {
        if (holstered)
            Holster();

        else if ((!holstered) && (canShoot))
        {
            //if the current ammo equals zero, play click SFX
            if (currentAmmo == 0)
            {
                Debug.Log("Click!");
            }

            //else decrease ammo by one
            //flip isFiring to true and waits seconds times fireRate before flipping it back off
            //play recoil animation, SFX, shoot projectile
            else
            {
                _PlayerStats.ChangeState("Shooting");
                Debug.Log("Bang!");
                currentAmmo = (currentAmmo - 1);
                canShoot = false;
                yield return new WaitForSeconds(1f * (fireRate));
                _PlayerStats.ChangeState("Neutral");
                canShoot = true;

                //PlaySFX
                //PlayAnimation
                //ShootProjectile
            }
        }

    }

    //coroutine Reload
    //sets canShoot to false until the completion of the act
    private IEnumerator Reload()
    {
        Debug.Log("Reloading!");
        _PlayerStats.ChangeState("Reloading");
        canShoot = false;
        yield return new WaitForSeconds(1f * (reloadTime));

        //play SFX
        //play Animation

        currentAmmo = maxAmmo;
        canShoot = true;
        Debug.Log("Reloaded!");
        _PlayerStats.ChangeState("Neutral");
    }

    private void Holster()
    {
        if (canShoot)
        {
            //cancels the Reload Coroutine and immediately puts gun away
            StopAllCoroutines();
            holstered = !holstered;
            if (holstered)
            {
                _PlayerStats.ChangeState("Neutral");
                Debug.Log("Put gun away!");
            }

            else if (!holstered)
            {
                _PlayerStats.ChangeWeapon(weaponType);
                _PlayerStats.ChangeState("Armed");
                Debug.Log("Took gun out!");
            }
        }
    }


    }

using UnityEngine;

//this is the script for the Weapon Scriptable Object
//WeaponBase holds a weapon's Stats, such as its name, Ammo, Attack Power, etc
[CreateAssetMenu(fileName = "Hitgirl Weapon", menuName = "Create New Weapon")]

public class WeaponsBase : ScriptableObject
{
    //Weapon Name
    [SerializeField] string myName;

    [SerializeField] string weaponType;

    [SerializeField] int maxAmmo;

    [SerializeField] int damage;

    [SerializeField] float fireRate;

    [SerializeField] float reloadTime;

    [SerializeField] string description;

    [SerializeField] bool[] melee;

    public string Name
    {
        get { return myName; }
    }

    public string WeaponType
    {
        get { return weaponType; }
    }

    public int MaxAmmo
    {
        get { return maxAmmo; }
    }

    public int Damage
    {
        get { return damage; }
    }

    public float FireRate
    {
        get { return fireRate; }
    }

    public float ReloadTime
    {
        get { return reloadTime; }
    }

    public string WeaponDescription
    {
        get { return description; }
    }

    public bool[] Melee 
    {
        get { return melee; }
    }
}
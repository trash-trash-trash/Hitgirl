using UnityEngine;

//this is the script for the NPC Scriptable Object
//NPCBase holds a NPC's Stats, such as its name, Health Points, Attack Power, etc
//this class is also used by the Player. When these notes reference Character, it's in reference to something that applies to both NPC and the Player
[CreateAssetMenu(fileName = "Hitgirl Character", menuName = "Create New Character")]

public class StatsBase : ScriptableObject
{
    //NPC Name
    [SerializeField] string myName;

    //determines Character's Health Points (HP) 
    [SerializeField] int maxHP;

    //determines a Character's Suspicion Level
    [SerializeField] float susLevel;

    //determines a Character's status depending on their Suspicion Level
    //different Characters will act differently depending on their current Status
    //does this need to be here?
    [SerializeField] enum charStatus { Neutral, Suspicious, Alert, Aggressive, Fleeing };

    //determines what weapon a Character is holding
    [SerializeField] string weapon;

    //determines a Character's Class
    //
    //  Target
    //  Targets are the objective of each level and thus highly important. Each Target is unique and behaves differently from other classes
    //
    //  Enemy
    //  Enemy class guard levels and are the primary obstacle. There are different Types of Enemy that may act uniquely.
    //  They patrol the levels and will notice if the Player is acting suspiciously and will respond with aggression if Alerted.
    //
    //  Neutral
    //  Neutral Characters living out their lives. They are docile but will notice if the Player is acting suspiciously or aggressively and Alert Enemies
    [SerializeField] string charClass;

    //determines a Character's Clothes
    //wearing different Clothes will change how different Characters react to you
    //expect this list to grow with additional levels
    [SerializeField] string charClothes;

    //determines Character's movement speed
    [SerializeField] float moveSpeed;

    //gets private stats and declares them publicly upon request from scripts
    public string Name
    {
        get { return myName; }
    }

    public int MaxHP
    {
        get { return maxHP; }
    }

    public string Weapon
    {
        get { return weapon; }
    }

    public string CharClass
    {
        get { return charClass; }
    }

    public string CharClothes
    {
        get { return charClothes; }
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }
    }


}

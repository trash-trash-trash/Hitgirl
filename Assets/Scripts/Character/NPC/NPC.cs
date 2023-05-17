using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    
    //declares NPCBase for stats
    public StatsBase _Stats;

    //holds the Character's Name. Names may be referenced through out the world or in dialogue with other Characters.
    string myName;

    //determines current HP level. When a Character is out of HP, they die.
    int maxHP;
    int currentHP;

    //Characters can only act if they are conscious
    bool canMove=true;
    //Characters can only act when they are Alive
    bool isAlive=true;

    //if the Player is acting suspiciously, a Character's Suspicion Level increases. Different Characters act differently depending on their current susLevel
    float susLevel=0;

    //determines a Character's movement speed. Movement speed is effected by susLevel
    float moveSpeed;

    //determines a Character's Class. Characters will act differently depending on what Class they are
    string charClass;

    //determines which clothes a Character is wearing
    string charclothes;

    //determines what Weapon a Character is currently carrying. Different Weapons have different uses and attack types and damage values
    string weapon;

    //determines the State the AI is in. AI acts differently according to which State it is in
    private enum AIStatus { Neutral, Suss, Alert};

    private void Awake()
    {
        //fetches stats from StatsBase.cs
        maxHP = _Stats.MaxHP;
        currentHP = maxHP;

        charClass = _Stats.CharClass;

        charclothes = _Stats.CharClothes;

        weapon = _Stats.Weapon;

    }

   


}

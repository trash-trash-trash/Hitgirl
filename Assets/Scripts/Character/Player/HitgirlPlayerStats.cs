using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitgirlPlayerStats : MonoBehaviour
{
    //declares NPCBase for stats
    public StatsBase _Stats;

    //holds the Character's Name. Names may be referenced through out the world or in dialogue with other Characters.
    string myName;

    //determines current HP level. When a Character is out of HP, they die.
    int maxHP;
    int currentHP;

    //determines how suspicious a Player is acting
    //certain actions increase your sus levels, making your more susceptible to Alerting enemies to your prescence
    private float susLevel;

    //Characters can only act if they are conscious
    bool canMove = true;
    //Characters can only act when they are Alive
    bool isAlive = true;

    //determines a Character's movement speed. Movement speed is 
    float moveSpeed;

    //determines what State the Player is in while traversing the world
    //seperate animations and moveSpeeds for different movement Status (no crouch / crouch movement)
    //Climbing refers to vertical traversal of ladders, pipes, trees, etc
    //Upstairs / Downstairs refers to if the Player is walking up or down stairs
    public enum myStatus { Neutral, Armed, Idling, Walking, Running, Climbing, Upstairs, Downstairs, Shooting, Reloading, Throwing, Melee };
    public myStatus Status;

    //enum for which weapon a Player has equipped
    public enum myWeapon { Unarmed, LethalMelee, Melee, Firearm, Sidearm, Item};
    public myWeapon Weapon;

    //determines if the Player is running
    bool isRun=false;

    //determines a Character's Class. Characters will act differently depending on what Class they are
    string charClass;

    //determines which clothes a Character is wearing
    string charclothes;

    //determines what Weapon a Character is currently carrying. Different Weapons have different uses and attack types and damage values
    string weapon;

    //determines if the Player is visibly armed
    bool armed;


    private void Awake()
    {
        myName = _Stats.Name;

        //fetches stats from StatsBase.cs
        maxHP = _Stats.MaxHP;
        currentHP = maxHP;

        charClass = _Stats.CharClass;

        charclothes = _Stats.CharClothes;

        weapon = _Stats.Weapon;

        moveSpeed = _Stats.MoveSpeed;

        susLevel = 5;

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Run();
        }
        Debug.Log(Status);

        WhatsMySus();

    }

    private void WhatsMySus()
    {
        switch (Status)
        {
            //Neutral, Idling, Walking, Running, Climbing, Upstairs, Downstairs, Shooting, Reloading, Throwing 
            case (myStatus.Neutral):
                susLevel += 0;
                break;

            case (myStatus.Idling):
                susLevel -= 5;
                break;

            case (myStatus.Running):
                susLevel += 5;
                break;

            case (myStatus.Shooting):
                susLevel += 75;
                break;

            case (myStatus.Reloading):
                susLevel += 50;
                break;

            case (myStatus.Throwing):
                susLevel += 25;
                break;
        }

        switch (Weapon)
        {
            //Unarmed, LethalMelee, Melee, Firearm, Sidearm, Item 
            case (myWeapon.Unarmed):
                susLevel += 0;
                break;
            case (myWeapon.Melee):
                susLevel += 25;
                break;
            case (myWeapon.Firearm):
                susLevel += 55;
                break;
            case (myWeapon.Sidearm):
                susLevel += 25;
                break;
            case (myWeapon.Item):
                susLevel += 0;
                break;
        }
        //Debug.Log(susLevel);
    }

    //turns running on/off
    private void Run()
    {
        isRun = !isRun;

        if (isRun)
        {
            moveSpeed += 5f;
            susLevel += 5;
        }

        if (!isRun)
            moveSpeed -= 5f;
    }

    //changes Player State
    public void ChangeState(string playerState)
    {
        switch (playerState)
        {
            case "Neutral":
                Status = myStatus.Neutral;
                break;
            case "Armed":
                Status = myStatus.Armed;
                break;
            case "Shooting":
                Status = myStatus.Shooting;
                break;
            case "Reloading":
                Status = myStatus.Reloading;
                break;
            case "Running":
                Status = myStatus.Running;
                break;
        }
    }

    //changes Weapon the Player has equipped
    public void ChangeWeapon(string equippedWeapon)
    {
        //Unarmed, LethalMelee, Melee, Firearm, Sidearm, Item
        switch (equippedWeapon)
        {
            case "Unarmed":
                Weapon = myWeapon.Unarmed;
                break;
            case "LethalMelee":
                Weapon = myWeapon.LethalMelee;
                break;
            case "Melee":
                Weapon = myWeapon.Melee;
                break;
            case "Firearm":
                Weapon = myWeapon.Firearm;
                break;
            case "Sidearm":
                Weapon = myWeapon.Sidearm;
                break;
            case "Item":
                Weapon = myWeapon.Item;
                break;
        }
        Debug.Log("Player is holding " +Weapon);
    }
}

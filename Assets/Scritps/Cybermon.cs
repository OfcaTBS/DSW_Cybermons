using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using CMType;

public class Cybermon : MonoBehaviour
{
    [Header("Main variables")]
    public string cmName; //name of Cybermon
    public int level; //current level of Cybermon
    public int experience; //the whole amount of gainded experience points
    public int speed; //0-infinity
    public int attack; //0-infinity
    public int specialAttack; //0-infinity
    public int defense; //0-infinity
    public int specialDefense; //0-infinity
    [Range(0,100)] public int accecuracy; //0-100
    public int currentHealth; //0-infinity
    public int maxHealth; //0-infinity
    public bool isKnockedOut;
    public bool isShiny; //flag of being shiny or not
    
    public bool isBurned;
    public bool isSleeping;
    public bool isParalyzed;
    public bool isPoisoned;
    public bool isFrozen;
    
    public TypeOfCybermon typeOfCybermon; //type of Cybermon
    public bool isOwnerAPlayer;
    

    [Header("Moves")]
    public List<Move> alreadyKnownMovesList;
    public List<Move> movesToLearnList;

    [Header("Model")]
    public Material material;
    public GameObject headPosition; //gameObject-child that's handle head's position for UI

    [Header("Events")]
    public UnityEvent OnBeingHealedByItem;
    public UnityEvent OnBeingKilled;
    public UnityEvent OnGainLevel;
    public UnityEvent OnGainExperience;
    public UnityEvent OnTypeChange;
    public UnityEvent OnMoveUse;
    public UnityEvent OnStatusAddBurn;
    public UnityEvent OnStatusAddSleep;
    public UnityEvent OnStatusAddParalyzed;
    public UnityEvent OnStatusAddPoisoned;
    public UnityEvent OnStatusAddFrozen;
    public UnityEvent OnStatusRemoveBurn;
    public UnityEvent OnStatusRemoveSleep;
    public UnityEvent OnStatusRemoveParalyzed;
    public UnityEvent OnStatusRemovePoisoned;
    public UnityEvent OnStatusRemoveFrozen;
    public UnityEvent OnAnyStatusAdd;
    public UnityEvent OnAnyStatusRemove;
    public UnityEvent OnBeingKnockedOut;
    public UnityEvent OnTakeDamage;
    public UnityEvent OnGainHealth;

    public bool CheckIfItsKnockedOut()
    {
        if (currentHealth <= 0)
        {
            isKnockedOut = true;
        }
        else
        {
            isKnockedOut = false;
        }

        return isKnockedOut;
    }

    public void AddHealth(int healthAmmountToAdd)
    {
        if (currentHealth < maxHealth && healthAmmountToAdd >= 0)
        {
            currentHealth += healthAmmountToAdd;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            OnGainHealth.Invoke();
        }
    }

    public void TakeDamage(int healthAmmountToReduce)
    {
        if (currentHealth > 0 && healthAmmountToReduce >= 0)
        {
            currentHealth -= healthAmmountToReduce;
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
            OnTakeDamage.Invoke();
        }
    }

    public void OnBurn()
    {
        TakeDamage((int)(0.1*maxHealth));
    }

    public void OnPoison()
    {
        TakeDamage((int)(0.15*maxHealth));
    }



    public void AddStatusBurn()
    {
        if (!isBurned)
        {
            isBurned = true;
            OnAnyStatusAdd.Invoke();
            OnStatusAddBurn.Invoke();
        }
    }

    public void RemoveStatusBurn()
    {
        if(isBurned)
        {
            isBurned = false;
            OnAnyStatusRemove.Invoke();
            OnStatusRemoveBurn.Invoke();
        }
    }

    public void AddStatusSleep()
    {
        if (!isSleeping)
        {
            isBurned = true;
            OnAnyStatusAdd.Invoke();
            OnStatusAddSleep.Invoke();
        }
    }

    public void RemoveStatusSleep()
    {
        if (isSleeping)
        {
            isBurned = false;
            OnAnyStatusRemove.Invoke();
            OnStatusRemoveSleep.Invoke();
        }
    }

    public void AddStatusParalyzed()
    {
        if (!isParalyzed)
        {
            isParalyzed = true;
            OnAnyStatusAdd.Invoke();
            OnStatusAddParalyzed.Invoke();
        }
    }

    public void RemoveStatusParalyzed()
    {
        if (isParalyzed)
        {
            isParalyzed = false;
            OnAnyStatusRemove.Invoke();
            OnStatusRemoveParalyzed.Invoke();
        }
    }

    public void AddStatusPoisoned()
    {
        if (!isPoisoned)
        {
            isPoisoned = true;
            OnAnyStatusAdd.Invoke();
            OnStatusAddPoisoned.Invoke();
        }
    }

    public void RemoveStatusPoisoned()
    {
        if (isPoisoned)
        {
            isPoisoned = false;
            OnAnyStatusRemove.Invoke();
            OnStatusRemovePoisoned.Invoke();
        }
    }

    public void AddStatusFrozen()
    {
        if (!isPoisoned)
        {
            isFrozen = true;
            OnAnyStatusAdd.Invoke();
            OnStatusAddFrozen.Invoke();
        }
    }

    public void RemoveStatusFrozen()
    {
        if (isFrozen)
        {
            isFrozen = false;
            OnAnyStatusRemove.Invoke();
            OnStatusRemoveFrozen.Invoke();
        }
    }

    public void RemoveAllStatuses()
    {
        
    }

    public void CheckIfNameIsNull()
    {
        if (cmName == "")
        {
            cmName = gameObject.name;
        }
    }

    public bool HasAnyStatuses()
    {
        if (isBurned || isFrozen || isParalyzed || isPoisoned || isSleeping)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeType(TypeOfCybermon _typeOfCybermon)
    {
        typeOfCybermon = _typeOfCybermon;
        OnTypeChange.Invoke();
    }

    public void AddMovesToAlreadyKnownMovesList()
    {
        //alreadyKnownMovesList.AddRange(this.GetComponents<Move>());
        foreach (Transform child in transform.GetChild(1).transform)
        {
            alreadyKnownMovesList.AddRange(child.GetComponents<Move>());
        }
        if(isOwnerAPlayer)
        {
            foreach(Move move in alreadyKnownMovesList)
            {
                var panel = Instantiate(Resources.Load("Prefabs/MovePanel") as GameObject, GameObject.Find("MovesPanel").transform);
                panel.GetComponent<MovePanelScript>().DoAfterInstantiate(move);
            }
        }
    }

    public Move GetRandomMove()
    {
        var random = new System.Random();
        int index = random.Next(alreadyKnownMovesList.Count);
        return alreadyKnownMovesList[index];
    }


    void Start()
    {
        headPosition = transform.GetChild(0).gameObject; // Find("CybermonHead");
        CheckIfNameIsNull();
        AddMovesToAlreadyKnownMovesList();
    }

    


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            AddHealth(10);
        }
    }
}

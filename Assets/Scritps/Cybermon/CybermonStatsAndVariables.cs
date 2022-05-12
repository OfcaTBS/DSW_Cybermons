using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMType;

[RequireComponent(typeof(Cybermon))]
public class CybermonStatsAndVariables : MonoBehaviour
{
    [Header("Main variables")]
    [SerializeField] private string cybermonName; //name of Cybermon
    [SerializeField] private string trainerName; //name of trainer
    [Range(1, 100)] [SerializeField] private int level; //current level of Cybermon //1-100
    [SerializeField] private int experience; //the whole amount of gainded experience points
    [SerializeField] private int speed; //0-infinity
    [SerializeField] private int attack; //0-infinity
    [SerializeField] private int specialAttack; //0-infinity
    [SerializeField] private int defense; //0-infinity
    [SerializeField] private int specialDefense; //0-infinity
    [Range(0, 100)] [SerializeField] private int accecuracy; //0-100
    [SerializeField] private int currentHealth; //0-infinity
    [SerializeField] private int maxHealth; //0-infinity
    [SerializeField] private bool knockedOutStatus;
    [SerializeField] private bool shinyStatus; //flag of being shiny or not
    [SerializeField] private bool burnStatus;
    [SerializeField] private bool sleepStatus;
    [SerializeField] private bool paralyzedStatus;
    [SerializeField] private bool poisonedStatus;
    [SerializeField] private bool frozenStatus;
    [SerializeField] private TypeOfCybermon typeOfCybermon; //type of Cybermon
    [SerializeField] private bool playerOwner;
    [SerializeField] private GameObject headGameObject;
    [SerializeField] private Cybermon cybermon;
    [SerializeField] private string cybermonID;

    private string GenerateCybermonID()
    {
        if (cybermonID == null || cybermonID == "")
        {
            cybermonID = Random.Range(1000000, 9999999).ToString();
        }
        return cybermonID;
    }

    public string GetCybermonID()
    {
        if (cybermonID == null || cybermonID == "")
        {
            GenerateCybermonID();
        }
        return cybermonID;
    }
    public Vector3 GetHeadPosition()
    {
        return headGameObject.transform.position;
    }
    public string GetCybermonName()
    {
        return cybermonName;
    }
    public void SetCybermonName(string _cybermonName)
    {
        cybermonName = _cybermonName;
    }

    public string GetTrainerName()
    {
        return trainerName;
    }

    public void SetTrainerName(string _trainerName)
    {
        trainerName = _trainerName;
    }

    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int _level)
    {
        level = _level;
        if (level < 1)
        {
            level = 1;
        }
        else if (level > 100)
        {
            level = 100;
        }
    }

    public int GetExperience()
    {
        return experience;
    }
    public void SetExperience(int _experience)
    {
        if (_experience < 0)
        {
            _experience *= -1;
        }
        experience = _experience;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(int _speed)
    {
        if (_speed < 0)
        {
            _speed *= -1;
        }
        speed = _speed;
    }

    public int GetAttack()
    {
        return attack;
    }

    public void SetAttack(int _attack)
    {
        if (_attack < 0)
        {
            _attack *= -1;
        }
        attack = _attack;
    }

    public int GetSpecialAttack()
    {
        return specialAttack;
    }

    public void SetSpecialAttack(int _specialAttack)
    {
        if (_specialAttack < 0)
        {
            _specialAttack *= -1;
        }
        specialAttack = _specialAttack;
    }

    public int GetDefense()
    {
        return defense;
    }

    public void SetDefense(int _defense)
    {
        if (_defense < 0)
        {
            _defense *= -1;
        }
        defense = _defense;
    }

    public int GetSpecialDefense()
    {
        return specialDefense;
    }

    public void SetSpecialDefense(int _specialDefense)
    {
        if (_specialDefense < 0)
        {
            _specialDefense *= -1;
        }
        specialDefense = _specialDefense;
    }

    public int GetAccecuracy()
    {
        return accecuracy;
    }

    public void SetAccecuracy(int _accecuracy)
    {
        accecuracy = _accecuracy;
        if (accecuracy < 0)
        {
            accecuracy = 0;
        }
        else if (accecuracy > 100)
        {
            accecuracy = 100;
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetCurrentHealth(int _currentHealth)
    {
        if (_currentHealth < 0)
        {
            _currentHealth *= -1;
        }
        currentHealth = _currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetMaxHealth(int _maxHealth)
    {
        if (_maxHealth < 0)
        {
            _maxHealth *= -1;
        }
        maxHealth = _maxHealth;
    }

    public bool IsPlayerAOwner()
    {
        return playerOwner;
    }

    public bool IsKnockedOut()
    {
        if (currentHealth <= 0)
        {
            knockedOutStatus = true;
        }
        else
        {
            knockedOutStatus = false;
        }

        return knockedOutStatus;
    }

    public bool IsBurned()
    {
        return burnStatus;
    }

    public bool IsParalyzed()
    {
        return paralyzedStatus;
    }

    public bool IsPoisoned()
    {
        return poisonedStatus;
    }

    public bool IsSleeping()
    {
        return sleepStatus;
    }

    public bool IsFrozen()
    {
        return frozenStatus;
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
            cybermon.cybermonEventSystem.OnGainHealth.Invoke();
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
            cybermon.cybermonEventSystem.OnTakeDamage.Invoke();
        }
    }

    public void OnBurn()
    {
        TakeDamage((int)(0.1 * maxHealth));
    }

    public void OnPoison()
    {
        TakeDamage((int)(0.15 * maxHealth));
    }

    public void AddStatusBurn()
    {
        if (!burnStatus)
        {
            burnStatus = true;
            cybermon.cybermonEventSystem.OnAnyStatusAdd.Invoke();
            cybermon.cybermonEventSystem.OnStatusAddBurn.Invoke();
        }
    }

    public void RemoveStatusBurn()
    {
        if (burnStatus)
        {
            burnStatus = false;
            cybermon.cybermonEventSystem.OnAnyStatusRemove.Invoke();
            cybermon.cybermonEventSystem.OnStatusRemoveBurn.Invoke();
        }
    }

    public void AddStatusSleep()
    {
        if (!sleepStatus)
        {
            burnStatus = true;
            cybermon.cybermonEventSystem.OnAnyStatusAdd.Invoke();
            cybermon.cybermonEventSystem.OnStatusAddSleep.Invoke();
        }
    }

    public void RemoveStatusSleep()
    {
        if (sleepStatus)
        {
            burnStatus = false;
            cybermon.cybermonEventSystem.OnAnyStatusRemove.Invoke();
            cybermon.cybermonEventSystem.OnStatusRemoveSleep.Invoke();
        }
    }

    public void AddStatusParalyzed()
    {
        if (!paralyzedStatus)
        {
            paralyzedStatus = true;
            cybermon.cybermonEventSystem.OnAnyStatusAdd.Invoke();
            cybermon.cybermonEventSystem.OnStatusAddParalyzed.Invoke();
        }
    }

    public void RemoveStatusParalyzed()
    {
        if (paralyzedStatus)
        {
            paralyzedStatus = false;
            cybermon.cybermonEventSystem.OnAnyStatusRemove.Invoke();
            cybermon.cybermonEventSystem.OnStatusRemoveParalyzed.Invoke();
        }
    }

    public void AddStatusPoisoned()
    {
        if (!poisonedStatus)
        {
            poisonedStatus = true;
            cybermon.cybermonEventSystem.OnAnyStatusAdd.Invoke();
            cybermon.cybermonEventSystem.OnStatusAddPoisoned.Invoke();
        }
    }

    public void RemoveStatusPoisoned()
    {
        if (poisonedStatus)
        {
            poisonedStatus = false;
            cybermon.cybermonEventSystem.OnAnyStatusRemove.Invoke();
            cybermon.cybermonEventSystem.OnStatusRemovePoisoned.Invoke();
        }
    }

    public void AddStatusFrozen()
    {
        if (!poisonedStatus)
        {
            frozenStatus = true;
            cybermon.cybermonEventSystem.OnAnyStatusAdd.Invoke();
            cybermon.cybermonEventSystem.OnStatusAddFrozen.Invoke();
        }
    }

    public void RemoveStatusFrozen()
    {
        if (frozenStatus)
        {
            frozenStatus = false;
            cybermon.cybermonEventSystem.OnAnyStatusRemove.Invoke();
            cybermon.cybermonEventSystem.OnStatusRemoveFrozen.Invoke();
        }
    }

    public void RemoveAllStatuses()
    {

    }

    public void CheckIfNameIsNull()
    {
        if (cybermonName == "")
        {
            cybermonName = gameObject.name;
        }
    }

    public bool HasAnyStatuses()
    {
        if (burnStatus || frozenStatus || paralyzedStatus || poisonedStatus || sleepStatus)
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
        cybermon.cybermonEventSystem.OnTypeChange.Invoke();
    }
    public TypeOfCybermon GetTypeOfCybermon()
    {
        return typeOfCybermon;
    }
    private void Awake()
    {
        cybermon = GetComponent<Cybermon>();
        headGameObject = transform.GetChild(0).gameObject;
        GenerateCybermonID();
    }

    private void FixedUpdate()
    {
        cybermon.battleUIManager.Notify(this.gameObject, "CybermonHeadStatus:updateHeadPosition", null);
    }

}

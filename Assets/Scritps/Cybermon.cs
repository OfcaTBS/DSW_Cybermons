using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] public UnityEvent OnTypeChange = new UnityEvent();
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
    public UnityEvent OnStatusAdd;
    public UnityEvent OnStatusRemove;

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

    public void ChangeTypeToFire()
    {
        typeOfCybermon = TypeOfCybermon.Fire;
    }

    public void AddMovesToAlreadyKnownMovesList()
    {
        alreadyKnownMovesList.AddRange(this.GetComponents<Move>());
    }

    /*public void FindHeadPosition()
    {
        headPosition = GameObject.Find("")
    }*/

    void Start()
    {
        headPosition = transform.GetChild(0).gameObject; // Find("CybermonHead");
        CheckIfNameIsNull();
        AddMovesToAlreadyKnownMovesList();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            OnTypeChange.Invoke();
        }
    }
}

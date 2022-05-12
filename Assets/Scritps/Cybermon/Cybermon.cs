using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using CMType;

[RequireComponent(typeof(CybermonStatsAndVariables))]
[RequireComponent(typeof(CybermonEventSystem))]
[RequireComponent(typeof(CybermonMovesManager))]
public class Cybermon : MonoBehaviour, IMediator
{
    public CybermonStatsAndVariables cybermonStatsAndVariables;
    public CybermonEventSystem cybermonEventSystem;
    public CybermonMovesManager cybermonMovesManager;
    public BattleUIManager battleUIManager;

    public void Notify(GameObject _sender, string _event, string[] _args)
    {
        throw new NotImplementedException();
    }

    void Awake()
    {
        cybermonStatsAndVariables = GetComponent<CybermonStatsAndVariables>();
        cybermonEventSystem = GetComponent<CybermonEventSystem>();
        cybermonMovesManager = GetComponent<CybermonMovesManager>();

        battleUIManager = GameObject.Find("BattleUIManager").GetComponent<BattleUIManager>();
        cybermonStatsAndVariables.CheckIfNameIsNull();
    }

    private void Start()
    {
        //cybermonMovesManager.AddMovesToAlreadyKnownMovesList();
        battleUIManager.Notify(gameObject, "CybermonHeadStatus:spawn", null);
    }
}

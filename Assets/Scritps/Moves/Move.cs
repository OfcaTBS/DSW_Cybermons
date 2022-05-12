using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMType;
using System;

public class Move : MonoBehaviour, ICommand, IMediator
{
    [SerializeField] private int maxPP;
    [SerializeField] private int currentPP;
    [TextArea]
    [SerializeField] private string moveDescription;
    [SerializeField] private string moveLog;
    [SerializeField] private TypeOfCybermon moveType;
    [SerializeField] private enum MoveTargetType { Self, ToEnemy}
    [SerializeField] private MoveTargetType myMoveTargetType;
    [SerializeField] private float moveAnimationLength;
    [SerializeField] private Cybermon moveOwnerCybermon;
    [SerializeField] private List<Cybermon> targetedCybermonsList;
    [SerializeField] private List<CybermonIDandHPContainer> cybermonIDandDamageContainerList;
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private PlayerMovesManager playerMovesManager;
    [SerializeField] private CybermonsManager cybermonsManager;
    [SerializeField] private Animator animator;

    private void CurrentPPDown()
    {
        if (currentPP > 0)
        {
            currentPP--;
        }
    }

    public int GetMaxPP()
    {
        return maxPP;
    }

    public TypeOfCybermon GetMoveType()
    {
        return moveType;
    }

    public int GetCurrentPP()
    {
        return currentPP;
    }



    private struct CybermonIDandHPContainer
    {
        string cybermondID;
        int damage;
        public CybermonIDandHPContainer(string _cybermonID, int _damage)
        {
            cybermondID = _cybermonID;
            damage = _damage;
        }
    }

    public string GetMoveDescription()
    {
        return moveDescription;
    }

    private void SetMoveOwnerCybermon(Cybermon _cybermon)
    {
        moveOwnerCybermon = _cybermon;
    }

    public Cybermon GetCybermonMoveOwner()
    {
        return moveOwnerCybermon;
    }

    public bool IsPPGreaterThanZero()
    {
        if (currentPP > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void UsePrivateMove()
    {
        Debug.Log(gameObject.name + ": My Private Move is Empty.");
    }

    private void TryToLoadAnimator()
    {
        if (gameObject.GetComponent<Animator>() != null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public virtual void Execute()
    {
        Debug.Log(gameObject.name + ": No Execute Command function created");
    }

    public virtual void Undo()
    {
        Debug.Log(gameObject.name + ": No Undo Command function created");
    }

    public void Notify(GameObject _sender, string _event, string[] _args)
    {
        if (_event == gameObject.name + ":UseMove")
        {
            if (IsPPGreaterThanZero())
            {
                GameObject moveGameObjectCopy = Instantiate(gameObject, turnManager.transform);
                Move moveCopy = moveGameObjectCopy.GetComponent<Move>();
                moveCopy.SetMoveOwnerCybermon(gameObject.transform.parent.transform.parent.gameObject.GetComponent<Cybermon>());
                moveCopy.targetedCybermonsList.Add(cybermonsManager.FindOpponentCybermon(moveCopy.GetCybermonMoveOwner()));
                turnManager.AddCommand(moveCopy);

                if (moveOwnerCybermon.cybermonStatsAndVariables.IsPlayerAOwner())
                {
                    CurrentPPDown();
                    playerMovesManager.Notify(gameObject, gameObject.name + ":PPDown", null);
                }
            }
            else
            {
                Debug.Log(gameObject.name + ": Brak wystarczajacych punktow PP.");
            }
        }
        else
        {
            Debug.Log("Unknown event. Sender: " + _sender.name + " , event: " + _event);
        }
    }
    private void Awake()
    {
        turnManager = GameObject.Find("BattleTurnManager").GetComponent<TurnManager>();
        cybermonsManager = GameObject.Find("CybermonsManager").GetComponent<CybermonsManager>();
        playerMovesManager = GameObject.Find("PlayerMovesManager").GetComponent<PlayerMovesManager>();

        if (moveOwnerCybermon == null)
        {
            moveOwnerCybermon = transform.parent.transform.parent.gameObject.GetComponent<Cybermon>();
        }
        TryToLoadAnimator();
    }

    void Start()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPanelManager : MonoBehaviour, IMediator
{
    [SerializeField] private Animator animator;
    [SerializeField] private State state;
    public enum State { noOneTurn, playerTurn, enemyTurn}

    public void Notify(GameObject _sender, string _event, string[] _args)
    {
        if (_event == "TurnPanelManager:changeToEnemyTurn")
        {
            ChangeToEnemyTurn();
        }
        else if (_event == "TurnPanelManager:changetoPlayerTurn")
        {
            ChangeToPlayerTurn();
        }
    }

    public void ChangeToEnemyTurn()
    {
        if (state != State.enemyTurn)
        {
            animator.SetTrigger("ChangeToEnemyTurn");
            state = State.enemyTurn;
        }
    }

    public void ChangeToPlayerTurn()
    {
        if (state != State.playerTurn)
        {
            animator.SetTrigger("ChangeToPlayerTurn");
            state = State.playerTurn;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        state = State.noOneTurn;
    }

}

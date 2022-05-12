using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cybermon))]
public class CybermonMovesManager : MonoBehaviour, IMediator
{
    [Header("Moves")]
    [SerializeField] private List<Move> alreadyKnownMovesList;
    [SerializeField] private List<Move> movesToLearnList;
    [SerializeField] private Cybermon cybermon;
    [SerializeField] private PlayerMovesManager playerMovesManager;

    private Move FindMoveByName(string _moveName)
    {
        foreach (Move m in alreadyKnownMovesList)
        {
            if (m.name == _moveName)
            {
                return m;
            }
        }
        return null;
    }
    public void AddMovesToAlreadyKnownMovesList()
    {
        foreach (Transform child in transform.GetChild(1).transform)
        {
            alreadyKnownMovesList.AddRange(child.GetComponents<Move>());
        }
        if (cybermon.cybermonStatsAndVariables.IsPlayerAOwner())
        {
            foreach (Move move in alreadyKnownMovesList)
            {
                playerMovesManager.CreateMovePanel(move);
            }
        }
    }

    public Move GetRandomMove()
    {
        var random = new System.Random();
        int index = random.Next(alreadyKnownMovesList.Count);
        return alreadyKnownMovesList[index];
    }

    public void Notify(GameObject _sender, string _event, string[] _args)
    {
        if (_event.Contains(":UseMove"))
        {
            FindMoveByName(_event.Replace(":UseMove", "")).Notify(_sender, _event, _args);
        }
    }

    private void Awake()
    {
        cybermon = GetComponent<Cybermon>();
        playerMovesManager = GameObject.Find("PlayerMovesManager").GetComponent<PlayerMovesManager>();
        AddMovesToAlreadyKnownMovesList();
    }
}

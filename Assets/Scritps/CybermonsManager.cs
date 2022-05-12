using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CybermonsManager : MonoBehaviour, IMediator
{
    [SerializeField] private List<Cybermon> cybermonsList;

    private void FindCybermons()
    {
        foreach (Transform child in transform)
        {
            cybermonsList.Add(child.GetComponent<Cybermon>());
        }
    }

    public Cybermon FindCybermonByID(string _ID)
    {
        foreach (Cybermon c in cybermonsList)
        {
            if (c.cybermonStatsAndVariables.GetCybermonID() == _ID)
            {
                return c;
            }
            else
            {
                continue;
            }
        }
        return null;
    }

    public Cybermon FindOpponentCybermon(Cybermon _cybermon)
    {
        foreach(Cybermon c in cybermonsList)
        {
            if (c != _cybermon)
            {
                return c;
            }
        }
        return null;
    }

    private void Awake()
    {
        FindCybermons();
    }

    public void Notify(GameObject _sender, string _event, string[] _args)
    {
        if (_event.Contains(":UseMove"))
        {
            FindCybermonByID(_sender.GetComponent<MovePanel>().GetCybermonID()).cybermonMovesManager.Notify(_sender, _event, _args);
        }
        else
        {
            Debug.Log("Unknown event. Sender: " + _sender.name + " , event: " + _event);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CybermonHeadStatusesCanvas : MonoBehaviour, IMediator
{
    [SerializeField] private List<CybermonHeadStatus> cybermonHeadStatusesList;

    private CybermonHeadStatus FindCybermonHeadStatusFromList(Cybermon _cybermon)
    {
        foreach (CybermonHeadStatus c in cybermonHeadStatusesList)
        {
            if (c.GetCybermonID() == _cybermon.cybermonStatsAndVariables.GetCybermonID())
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

    public void Notify(GameObject _sender, string _event, string[] _args)
    {
        if (_event == "CybermonHeadStatus:spawn")
        {
            cybermonHeadStatusesList.Add(CybermonHeadStatus.CreateCybermonHeadStatus(_sender.GetComponent<Cybermon>(), transform).GetComponent<CybermonHeadStatus>());
        }
        else if (_event == "CybermonHeadStatus:destroy")
        {
            var c = FindCybermonHeadStatusFromList(_sender.GetComponent<Cybermon>());
            cybermonHeadStatusesList.Remove(c);
            Destroy(c.gameObject);
        }
        else if (_event == "CybermonHeadStatus:updateHeadPosition")
        {
            FindCybermonHeadStatusFromList(_sender.GetComponent<Cybermon>()).HeadPositionUpdate(_sender.GetComponent<Cybermon>());
        }
        else if (_event == "CybermonHeadStatus:updateCurrentHealth")
        {
            FindCybermonHeadStatusFromList(_sender.GetComponent<Cybermon>()).CurrentHPUpdate(_sender.GetComponent<Cybermon>());
        }
        else if (_event == "CybermonHeadStatus:updateMaxHealth")
        {
            FindCybermonHeadStatusFromList(_sender.GetComponent<Cybermon>()).MaxHPUpdate(_sender.GetComponent<Cybermon>());
        }
        else if (_event == "CybermonHeadStatis:updateName")
        {
            FindCybermonHeadStatusFromList(_sender.GetComponent<Cybermon>()).NameUpdate(_sender.GetComponent<Cybermon>());
        }
        else if (_event == "CybermonHeadStatis:updateLevel")
        {
            FindCybermonHeadStatusFromList(_sender.GetComponent<Cybermon>()).LevelUpdate(_sender.GetComponent<Cybermon>());
        }
        else
        {
            Debug.Log("Unknown event. Sender: " + _sender.name + " , event: " + _event);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUIManager : MonoBehaviour, IMediator
{
    [SerializeField] private CybermonHeadStatusesCanvas cybermonHeadStatusesCanvas;
    [SerializeField] private TurnPanelManager turnPanelManager;

    public void Notify(GameObject _sender, string _event, string[] _args)
    {
        if (_event.Contains("CybermonHeadStatus"))
        {
            cybermonHeadStatusesCanvas.Notify(_sender, _event, _args);
        }
        else if (_event.Contains("TurnPanelManager"))
        {
            turnPanelManager.Notify(_sender, _event, _args);
        }
        else
        {
            Debug.Log(gameObject.name + ": Unknown event. Sender: " + _sender.name + " , event: " + _event);
        }
    }

    private void Awake()
    {
        cybermonHeadStatusesCanvas = GameObject.Find("BattleUIManager/BattleUI/CybermonHeadStatusesCanvas").GetComponent<CybermonHeadStatusesCanvas>();
        turnPanelManager = GameObject.Find("BattleUIManager/BattleUI/TurnPanelManager").GetComponent<TurnPanelManager>();
    }
}

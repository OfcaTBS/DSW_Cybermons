using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovesManager : MonoBehaviour, IMediator
{
    [SerializeField] private List<MovePanel> movePanelList;

    public MovePanel CreateMovePanel(Move _move)
    {
        var movePanel = MovePanel.CreateMovePanel(_move, transform).GetComponent<MovePanel>();
        movePanelList.Add(movePanel);
        return movePanel;
    }

    private MovePanel FindMovePanelByMoveName(string _name)
    {
        foreach (MovePanel m in movePanelList)
        {
            if (m.name == _name)
            {
                return m;
            }
        }
        return null;
    }

    public void Notify(GameObject _sender, string _event, string[] _args)
    {
        if (_event.Contains(":PPDown"))
        {
            FindMovePanelByMoveName(_event.Replace(":PPDown", "")).CurrentPPUpdate(_sender.GetComponent<Move>());
        }
    }


}

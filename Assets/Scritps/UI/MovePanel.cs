using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CMType;
using System;

public class MovePanel : MonoBehaviour
{
    [SerializeField] private Image panelImage;
    [SerializeField] private float colorChangeValue = 0.2F;
    [SerializeField] private Text moveNameText, PPAmmountText;
    [SerializeField] private Text moveDescriptionPanelText;
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private CybermonsManager cybermonsManager;

    [SerializeField] private string cybermonID;
    [SerializeField] private string moveName;

    [SerializeField] private string moveDescription;
    [SerializeField] private int currentPP;
    [SerializeField] private int maxPP;
    [SerializeField] private Color32 typeColor;


    private void SetMovePanelVariables(Move _move)
    {
        MoveNameUpdate(_move);
        moveDescription = _move.GetMoveDescription();
        CurrentPPUpdate(_move);
        MaxPPUpdate(_move);
        TypeColorUpdate(_move);
        cybermonID = _move.GetCybermonMoveOwner().cybermonStatsAndVariables.GetCybermonID();
    }

    public void TypeColorUpdate(Move _move)
    {
        typeColor = TypesOfCybermon.GetColorByType(_move.GetMoveType());
        PanelImageColorUpdate();
    }

    private void PanelImageColorUpdate()
    {
        panelImage.color = typeColor;
    }

    public void MoveNameUpdate(Move _move)
    {
        moveName = _move.name;
        gameObject.name = _move.name;
        MoveNameTextUpdate();
    }

    private void MoveNameTextUpdate()
    {
        moveNameText.text = moveName;
    }

    public void MaxPPUpdate(Move _move)
    {
        maxPP = _move.GetMaxPP();
        PPAmountTextUpdate();
    }

    public void CurrentPPUpdate(Move _move)
    {
        currentPP = _move.GetCurrentPP();
        PPAmountTextUpdate();
    }

    private void PPAmountTextUpdate()
    {
        PPAmmountText.text = currentPP + "/" + maxPP;
    }

    public static GameObject CreateMovePanel(Move _move, Transform _parent)
    {
        var movePanel = Instantiate(Resources.Load("Prefabs/UI/MovePanel") as GameObject, _parent);
        movePanel.GetComponent<MovePanel>().SetMovePanelVariables(_move);
        return movePanel;
    }

    public string GetCybermonID()
    {
        return cybermonID;
    }

    public void MakeColorDarker()
    {
        panelImage.color = new Color(panelImage.color.r - colorChangeValue, panelImage.color.g - colorChangeValue, panelImage.color.b - colorChangeValue);
    }

    public void DescriptionUpdate()
    {
        moveDescriptionPanelText.text = moveDescription;
    }

    public void ClearDescription()
    {
        moveDescriptionPanelText.text = "Moves' description";
    }

    public void MakeColorLighter()
    {
        panelImage.color = new Color(panelImage.color.r + colorChangeValue, panelImage.color.g + colorChangeValue, panelImage.color.b + colorChangeValue);
    }

    public void UseMove()
    {
        cybermonsManager.Notify(gameObject, moveName + ":UseMove", null);
    }

    private void Awake()
    {
        panelImage = GetComponent<Image>();
        moveDescriptionPanelText = GameObject.Find("MoveDescriptionPanelText").GetComponent<Text>();
        turnManager = GameObject.Find("BattleTurnManager").GetComponent<TurnManager>();
        cybermonsManager = GameObject.Find("CybermonsManager").GetComponent<CybermonsManager>();
    }
}

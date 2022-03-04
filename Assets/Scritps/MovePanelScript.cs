using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CMType;

public class MovePanelScript : MonoBehaviour
{
    public Image panelImage;
    public float colorChangeValue = 0.2F;
    public Move myMove;
    public Text moveNameText, PPAmmountText;
    public Text MoveDescriptionPanelText;
    public TurnManager turnManager;

    public void DoAfterInstantiate(Move _move)
    {
        myMove = _move;
        moveNameText.text = myMove.gameObject.name;
        PPAmmountText.text = myMove.currentPP + "/" + myMove.maxPP;
        panelImage.color = TypesOfCybermon.TypeColor(myMove.moveType);
    }
    // Start is called before the first frame update
    void Start()
    {
        panelImage = GetComponent<Image>();
        MoveDescriptionPanelText = GameObject.Find("MoveDescriptionPanelText").GetComponent<Text>();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    public void MakeColorDarker()
    {
        panelImage.color = new Color(panelImage.color.r - colorChangeValue, panelImage.color.g - colorChangeValue, panelImage.color.b - colorChangeValue);
    }

    public void SetDescription()
    {
        MoveDescriptionPanelText.text = myMove.moveDescription;
    }

    public void ClearDescription()
    {
        MoveDescriptionPanelText.text = "Moves' description";
    }

    public void MakeColorLighter()
    {
        panelImage.color = new Color(panelImage.color.r + colorChangeValue, panelImage.color.g + colorChangeValue, panelImage.color.b + colorChangeValue);
    }

    public void UseMove()
    {
        if (myMove.isPPGreaterThanZero())
        {
            //myMove.UseMove();
            GameObject.Find("TurnManager").GetComponent<TurnManager>().SetTurnOneMove(myMove.UseMove);
        }
    }

    private void FixedUpdate()
    {
        PPAmmountText.text = myMove.currentPP + "/" + myMove.maxPP;
    }

}

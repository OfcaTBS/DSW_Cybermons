using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public UnityEvent turnOne, turnTwo;
    public bool turnOneReady, turnTwoReady;
    public Cybermon turnOneCybermon, turnTwoCybermon;
    public Image EndBattleScreenImage;
    public Text EndBattleScreenText;

    public GameObject FreezeScreenImage;
    // Start is called before the first frame update
    public void UnfreezeScreen()
    {
        FreezeScreenImage.SetActive(false);
    }

    public void FreezeScreen()
    {
        FreezeScreenImage.SetActive(true);
    }
    
    public void CheckIfCybermonsAreReady()
    {
        if (turnOneReady && turnTwoReady)
        {
            FreezeScreen();
            turnOne.Invoke();
            turnTwo.Invoke();
            CheckIfCybermonsAreBurned();
            CheckIfCybermonsArePoisoned();
            TurnManagerRestart();
        }

    }

    public void TurnManagerRestart()
    {
        turnOne = new UnityEvent();
        turnTwo = new UnityEvent();
        turnOneReady = false;
        turnTwoReady = false;

        if (turnOneCybermon.CheckIfItsKnockedOut() && !turnTwoCybermon.CheckIfItsKnockedOut())
        {
            ShowEndBattleScreen(new Color32(188, 61, 61, 255), "You loose the battle :(");
        }
        else if (!turnOneCybermon.CheckIfItsKnockedOut() && turnTwoCybermon.CheckIfItsKnockedOut())
        {
            ShowEndBattleScreen(new Color32(123, 212, 0, 255), "You won the battle :)");
        }
        else if (turnOneCybermon.CheckIfItsKnockedOut() && turnTwoCybermon.CheckIfItsKnockedOut())
        {
            ShowEndBattleScreen(new Color32(255, 136, 0, 255), "DRAW!");
        }
        else
        {
            UnfreezeScreen();
        }
    }

    public void ShowEndBattleScreen(Color32 col, string message)
    {
        EndBattleScreenImage.gameObject.SetActive(true);
        EndBattleScreenImage.color = col;
        EndBattleScreenText.text = message;
    }

    public void TurnTwoRandomMove()
    {
        if (!turnTwoReady)
        {
            turnTwo.AddListener(turnTwoCybermon.GetRandomMove().UseMove);
            turnTwoReady = true;
        }
    }

    public void CheckIfCybermonsAreBurned()
    {
        if (turnOneCybermon.isBurned)
        {
            turnOneCybermon.OnBurn();
        }
        if (turnTwoCybermon.isBurned)
        {
            turnTwoCybermon.OnBurn();
        }
    }

    public void CheckIfCybermonsArePoisoned()
    {
        if (turnOneCybermon.isPoisoned)
        {
            turnOneCybermon.OnPoison();
        }
        if (turnTwoCybermon.isPoisoned)
        {
            turnTwoCybermon.OnPoison();
        }
    }

    public void SetTurnOneMove(UnityAction turnOneMove)
    {
        if (!turnOneReady)
        {
            turnOne.AddListener(turnOneMove);
            turnOneReady = true;
            TurnTwoRandomMove();
        }
    }

    void Start()
    {
        FreezeScreenImage = GameObject.Find("FreezeScreenImage");
        EndBattleScreenImage.gameObject.SetActive(false);
        UnfreezeScreen();
        TurnManagerRestart();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckIfCybermonsAreReady();
    }
}

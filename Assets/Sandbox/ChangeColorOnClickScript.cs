using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorOnClickScript : MonoBehaviour
{
    public Text textToChange;


    public void ChangeTextKorwin()
    {
        textToChange.text = "Jebac Korwina";
    }

    public void ChangeTextPiS()
    {
        textToChange.text = "Jebac PiS";
    }
}

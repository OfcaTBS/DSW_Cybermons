using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAdditionalEffect : MonoBehaviour
{
    public virtual void UseAdditionalEffect(Cybermon targetedCybermon)
    {
        Debug.Log("Targeted Cybermon to add effect on it: " + targetedCybermon.name + ". My AdditionalEffect is empty.");
    }

}

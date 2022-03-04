using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMType;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxPP;
    public int currentPP;
    [TextArea]
    public string moveDescription;
    public TypeOfCybermon moveType;
    public enum MoveTargetType { Self, ToEnemy}
    public MoveTargetType myMoveTargetType;
    public float moveAnimationLength;
    public Cybermon moveOwnerCybermon;

    public Cybermon userCybermon, targetedCybermon;
    public List<MoveAdditionalEffect> moveAdditionalEffectsList;

    public bool isPPGreaterThanZero()
    {
        if (currentPP > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void UsePrivateMove()
    {
        Debug.Log(gameObject.name + ": My Private Move is Empty.");
    }

    public void UseAdditionalEffects()
    {
        foreach (MoveAdditionalEffect m in moveAdditionalEffectsList)
        {
            m.UseAdditionalEffect(targetedCybermon);
        }
    }

    public void UseMove()
    {
        if (myMoveTargetType == MoveTargetType.Self)
        {
            targetedCybermon = gameObject.transform.parent.transform.parent.gameObject.GetComponent<Cybermon>();
        }
        else
        {
                targetedCybermon = FindOpponentCybermon(moveOwnerCybermon);
        }

        if (isPPGreaterThanZero())
        {
            UsePrivateMove();
            UseAdditionalEffects();
            currentPP--;
        }
        
    }

    public Cybermon FindOpponentCybermon(Cybermon moveOwner)
    {
        List<Cybermon> CBList = new List<Cybermon>();
        Cybermon CBtoReturn = new Cybermon();
        CBList.AddRange(GameObject.FindObjectsOfType<Cybermon>());
        foreach (Cybermon CB in CBList)
        {
            if (CB != moveOwnerCybermon)
            {
                CBtoReturn = CB;
            }
            else
            {
                continue;
            }
        }
        return CBtoReturn;
    }
    public void Start()
    {
        moveAdditionalEffectsList.AddRange(gameObject.GetComponents<MoveAdditionalEffect>());
        moveOwnerCybermon = gameObject.transform.parent.transform.parent.gameObject.GetComponent<Cybermon>();
    }


}

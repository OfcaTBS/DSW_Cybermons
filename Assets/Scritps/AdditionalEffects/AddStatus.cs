using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStatus : MoveAdditionalEffect
{
    [Range(0,100)]
    public int chance = 100;

    public enum Status { Burn, Sleeping, Paralyzed, Poisoned, Frozen}
    public Status statusToAdd;

    public override void UseAdditionalEffect(Cybermon targetedCybermon)
    {
        if (chance != 0)
        {
            int random = Random.Range(1, 100);
            Debug.Log("AddStatus randomized chance: " + random);
            if (random <= chance)
            {
                Debug.Log("Added status.");
                switch (statusToAdd)
                {
                    case Status.Burn:
                        targetedCybermon.cybermonStatsAndVariables.AddStatusBurn();
                        break;
                    case Status.Sleeping:
                        targetedCybermon.cybermonStatsAndVariables.AddStatusSleep();
                        break;
                    case Status.Paralyzed:
                        targetedCybermon.cybermonStatsAndVariables.AddStatusParalyzed();
                        break;
                    case Status.Poisoned:
                        targetedCybermon.cybermonStatsAndVariables.AddStatusPoisoned();
                        break;
                    case Status.Frozen:
                        targetedCybermon.cybermonStatsAndVariables.AddStatusFrozen();
                        break;
                }

            }
        }
    }

}

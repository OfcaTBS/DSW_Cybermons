using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingDance : Move
{
    public override void UsePrivateMove()
    {
        targetedCybermon.AddHealth(20);
    }
}

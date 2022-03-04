using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBite : Move
{
    public override void UsePrivateMove()
    {
        targetedCybermon.TakeDamage(3);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tackle : Move
{
    public override void UsePrivateMove()
    {
        targetedCybermon.TakeDamage(10);
    }
}

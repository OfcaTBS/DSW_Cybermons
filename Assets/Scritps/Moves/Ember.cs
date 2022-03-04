using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ember : Move
{
    public override void UsePrivateMove()
    {
        targetedCybermon.TakeDamage(5);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEffectBurn : MoveAdditionalEffect
{
    public override void UseAdditionalEffect(Cybermon targetedCybermon)
    {
        targetedCybermon.AddStatusBurn();
    }
}

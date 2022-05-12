using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CybermonEventSystem : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent OnBeingHealedByItem;
    public UnityEvent OnBeingKilled;
    public UnityEvent OnGainLevel;
    public UnityEvent OnGainExperience;
    public UnityEvent OnTypeChange;
    public UnityEvent OnMoveUse;
    public UnityEvent OnStatusAddBurn;
    public UnityEvent OnStatusAddSleep;
    public UnityEvent OnStatusAddParalyzed;
    public UnityEvent OnStatusAddPoisoned;
    public UnityEvent OnStatusAddFrozen;
    public UnityEvent OnStatusRemoveBurn;
    public UnityEvent OnStatusRemoveSleep;
    public UnityEvent OnStatusRemoveParalyzed;
    public UnityEvent OnStatusRemovePoisoned;
    public UnityEvent OnStatusRemoveFrozen;
    public UnityEvent OnAnyStatusAdd;
    public UnityEvent OnAnyStatusRemove;
    public UnityEvent OnBeingKnockedOut;
    public UnityEvent OnTakeDamage;
    public UnityEvent OnGainHealth;
}

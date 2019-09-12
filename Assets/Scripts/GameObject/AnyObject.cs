using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// 
/// </summary>
public abstract class AnyObject : MonoBehaviour
{
    // ----- 変数 ----- //
    protected bool Attackable;
    protected bool Damageable;
    public TeamType TeamType { get; protected set; }

    // ----- Subject ----- //
    public Subject<Unit> HitAttack;
    public Subject<AnyObject> HitDamage;
    public Subject<Unit> ThroughAttack;
    public Subject<AnyObject> ThroughDamage;

    // ----- 関数 ----- //
    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }
}
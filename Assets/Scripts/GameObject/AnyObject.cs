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

    protected ReactiveProperty<bool> _IsAlive = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> IsAlive => _IsAlive;

    // ----- Subject ----- //
    protected Subject<Unit> _HitAttack = new Subject<Unit>();
    public IObservable<Unit> HitAttack => _HitAttack;
    protected Subject<AttackData> _HitDamage = new Subject<AttackData>();
    public IObservable<AttackData> HitDamage => _HitDamage;
    private Subject<Unit> _ThroughAttack = new Subject<Unit>();
    public IObservable<Unit> ThroughAttack => _ThroughAttack;
    protected Subject<AttackData> _ThroughDamage = new Subject<AttackData>();
    public IObservable<AttackData> ThroughDamage => _ThroughDamage;

    protected Subject<Unit> _OnKilled = new Subject<Unit>();
    public IObservable<Unit> OnKilled => _OnKilled;
    protected Subject<Unit> _OnDied = new Subject<Unit>();
    public IObservable<Unit> OnDied => _OnDied;

    // ----- 関数 ----- //
    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }
}
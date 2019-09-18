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
    //攻撃に当たったとき
    protected Subject<TeamType> _HitAttack = new Subject<TeamType>();
    public IObservable<TeamType> HitAttack => _HitAttack;
    //攻撃が当たったとき
    protected Subject<TeamType> _HitDamage = new Subject<TeamType>();
    public IObservable<TeamType> HitDamage => _HitDamage;
    private Subject<AttackData> _ThroughAttack = new Subject<AttackData>();
    public IObservable<AttackData> ThroughAttack => _ThroughAttack;
    protected Subject<AttackData> _ThroughDamage = new Subject<AttackData>();
    public IObservable<AttackData> ThroughDamage => _ThroughDamage;

    protected Subject<TeamType> _OnKilled = new Subject<TeamType>();
    public IObservable<TeamType> OnKilled => _OnKilled;
    protected Subject<Unit> _OnDied = new Subject<Unit>();
    public IObservable<Unit> OnDied => _OnDied;

    // ----- 関数 ----- //
    protected virtual void Start()
    {
        Init();
    }

    protected abstract void Init();
}
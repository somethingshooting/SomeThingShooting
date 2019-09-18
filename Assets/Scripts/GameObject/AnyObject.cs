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
    public IObservable<TeamType> HitAttackSubject => _HitAttack;
    //攻撃が当たったとき
    protected Subject<TeamType> _HitDamage = new Subject<TeamType>();
    public IObservable<TeamType> HitDamageSubject => _HitDamage;
    private Subject<AttackData> _ThroughAttack = new Subject<AttackData>();
    public IObservable<AttackData> ThroughAttackSubject => _ThroughAttack;
    protected Subject<AttackData> _ThroughDamage = new Subject<AttackData>();
    public IObservable<AttackData> ThroughDamageSubject => _ThroughDamage;

    protected Subject<TeamType> _OnKilled = new Subject<TeamType>();
    public IObservable<TeamType> OnKilledSubject => _OnKilled;
    protected Subject<Unit> _OnDied = new Subject<Unit>();
    public IObservable<Unit> OnDiedSubject => _OnDied;

    // ----- 関数 ----- //
    protected virtual void Start()
    {
        Init();
    }

    protected abstract void Init();
}
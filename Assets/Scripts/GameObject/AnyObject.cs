using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// 
/// </summary>
public abstract class AnyObject : MonoBehaviour, IAttackable, IDamageable
{
    protected BoolReactiveProperty _Attackable = new BoolReactiveProperty(true);
    public IReadOnlyReactiveProperty<bool> Attackable => _Attackable;
    protected BoolReactiveProperty _Damageable = new BoolReactiveProperty(true);
    public IReadOnlyReactiveProperty<bool> Damageable => _Damageable;

    public TeamType TeamType { get; protected set; }

    protected ReactiveProperty<bool> _IsAlive = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> IsAlive => _IsAlive;

    protected Subject<AnyObject> _SendPhysicsHit = new Subject<AnyObject>();
    public IObservable<AnyObject> SendPhysicsHit => _SendPhysicsHit;
    protected Subject<AnyObject> _SendDamageHit = new Subject<AnyObject>();
    public IObservable<AnyObject> SendDamageHit => _SendDamageHit;
    protected Subject<AnyObject> _OnKill = new Subject<AnyObject>();
    public IObservable<AnyObject> OnKill => _OnKill;

    protected Subject<AnyObject> _HadPhysicsHit = new Subject<AnyObject>();
    public IObservable<AnyObject> HadPhysicsHit => _HadPhysicsHit;
    protected Subject<AnyObject> _HadDamageHit = new Subject<AnyObject>();
    public IObservable<AnyObject> HadDamageHit => _HadDamageHit;
    protected Subject<AnyObject> _OnDied = new Subject<AnyObject>();
    public IObservable<AnyObject> OnDied => _OnDied;

    // ----- 関数 ----- //
    protected virtual void Start()
    {
        Init();
    }

    protected abstract void Init();

    //接触判定
    protected void OnTriggerEnter(Collider other)
    {
        AnyObject obj = other.GetComponent<AnyObject>();
        //Had系の判定
        if (TeamType != obj.TeamType && Damageable.Value && obj.Attackable.Value)
        {
            _HadPhysicsHit.OnNext(obj);
        }
        //Send系の判定
        if (TeamType != obj.TeamType && Attackable.Value && obj.Damageable.Value)
        {
            _SendPhysicsHit.OnNext(obj);
        }
    }
}
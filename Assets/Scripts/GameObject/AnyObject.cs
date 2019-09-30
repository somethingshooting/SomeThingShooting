using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// すべてのゲームオブジェクトが所持
/// </summary>
public abstract class AnyObject : MonoBehaviour, IAttackable, IDamageable
{
    protected BoolReactiveProperty _Attackable = new BoolReactiveProperty(true);
    public IReadOnlyReactiveProperty<bool> Attackable => _Attackable;
    protected BoolReactiveProperty _Damageable = new BoolReactiveProperty(true);
    public IReadOnlyReactiveProperty<bool> Damageable => _Damageable;

    public TeamType TeamType { get; protected set; }

    /// <summary>
    /// 現在の攻撃データ
    /// </summary>
    public AttackData CurrentAtackData { get; protected set; }

    protected ReactiveProperty<bool> _IsAlive = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> IsAlive => _IsAlive;

    protected Subject<AnyObject> _Sub_SendPhysicsHit = new Subject<AnyObject>();
    public IObservable<AnyObject> Sub_SendPhysicsHit => _Sub_SendPhysicsHit;
    protected Subject<AnyObject> _Sub_SendDamageHit = new Subject<AnyObject>();
    public IObservable<AnyObject> Sub_SendDamageHit => _Sub_SendDamageHit;
    protected Subject<AnyObject> _Sub_OnKill = new Subject<AnyObject>();
    public IObservable<AnyObject> Sub_OnKill => _Sub_OnKill;

    protected Subject<AnyObject> _Sub_HadPhysicsHit = new Subject<AnyObject>();
    public IObservable<AnyObject> Sub_HadPhysicsHit => _Sub_HadPhysicsHit;
    protected Subject<AnyObject> _Sub_HadDamageHit = new Subject<AnyObject>();
    public IObservable<AnyObject> Sub_HadDamageHit => _Sub_HadDamageHit;
    protected Subject<AnyObject> _Sub_OnDied = new Subject<AnyObject>();
    public IObservable<AnyObject> Sub_OnDied => _Sub_OnDied;

    /// <summary>
    /// 時間の流れの速さ
    /// </summary>
    protected float _TimeVelocity = 1;
    protected float _Timedelta => _TimeVelocity * Time.deltaTime;

    // ----- 関数 ----- //
    protected virtual void Start()
    {
        Sub_OnKill.Subscribe(killedObj => OnKill(killedObj)).AddTo(gameObject);
        Sub_OnDied.Subscribe(_ => OnDied()).AddTo(gameObject);
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
            _Sub_HadPhysicsHit.OnNext(obj);
        }
        //Send系の判定
        if (TeamType != obj.TeamType && Attackable.Value && obj.Damageable.Value)
        {
            _Sub_SendPhysicsHit.OnNext(obj);
        }
    }

    protected abstract void OnKill(AnyObject killedObj);
    protected abstract void OnDied();
}
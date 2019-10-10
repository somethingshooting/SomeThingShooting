using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// プレイヤーのサンプル弾(直線に飛ぶだけ)
/// </summary>
public class PlayerSampleBullet : BulletBase
{
    [SerializeField]
    private float _MoveSpeed = 1;

    protected override void Init()
    {
        Observable.EveryUpdate()
            .Subscribe(_ => Move());
        Sub_SendPhysicsHit
            .Subscribe(obj => SendHitObj(obj));
    }

    private void Move()
    {
        transform.Translate(transform.forward * _Timedelta * _MoveSpeed);
    }

    protected void SendHitObj(AnyObject obj)
    {
        if (CurrentAtackData != null)
        {
            SendDamage(obj);
        }
    }

    private void SendDamage(AnyObject obj)
    {
        EnemyBase enemy = obj as EnemyBase;
        if (enemy != null)
        {
            obj.Sub_HadDamageHit
                .Take(1)
                .Subscribe(_ => _Sub_SendDamageHit.OnNext(obj));
            enemy.ApplyDamage(this);
        }
    }

    protected override void OnKill(AnyObject killedObj)
    {

    }

    protected override void OnDied()
    {
        Destroy(gameObject);
    }

    protected override void HadHitDamage(AnyObject obj)
    {

    }
}

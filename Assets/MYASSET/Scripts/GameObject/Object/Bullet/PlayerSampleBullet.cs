using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary> プレイヤーのサンプル弾(直線に飛ぶだけ) </summary>
public class PlayerSampleBullet : BulletBase
{
    private PlayerCore _Core;

    protected override void Init()
    {

        _Core = GameObject.FindWithTag("Player").GetComponent<PlayerCore>();

        this.UpdateAsObservable()
            .Subscribe(_ => Move());

        Sub_SendPhysicsHit
            .Subscribe(obj => SendHitObj(obj));

        this.UpdateAsObservable()
            .Where(_ => Vector3.Distance(Vector3.zero, transform.position) > 20)
            .Subscribe(_ => _Sub_OnDied.OnNext(this));

    }

    protected override void Move()
    {
        transform.Translate(Vector3.forward * _Timedelta * _MoveSpeed);
    }

    protected override void OnKill(AnyObject killedObj)
    {
        _Core.NotifyDestruction(killedObj);
    }

    protected override void OnDied()
    {
        Destroy(gameObject);
    }

    protected override void HadHitDamage(AnyObject obj)
    {
        _Sub_OnDied.OnNext(obj);
    }
}

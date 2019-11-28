using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class AimForEnmBullet : BulletBase
{
    [SerializeField] private TeamType _TeamType;
    private Character _TargetChara = null;

    protected override void Init()
    {
        base.Init();
        // Targetを設定
        TeamType = _TeamType;
        if (TeamType == TeamType.Enemy)
        {
            _TargetChara = GameObject.FindWithTag("Player").GetComponent<Character>();
        }
        else if (TeamType == TeamType.Player)
        {
            GameObject nearEnemy = null;
            float distance = -1;
            foreach (var enm in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (Vector3.Distance(gameObject.transform.position,enm.transform.position) < distance || distance == -1)
                {
                    nearEnemy = enm;
                }
            }

            if (nearEnemy != null)
            {
                _TargetChara = nearEnemy.GetComponent<Character>();
            }
        }

        transform.LookAt(new Vector3(_TargetChara.transform.position.x, transform.position.y, _TargetChara.transform.position.z));

        this.UpdateAsObservable()
            .Subscribe(_ => Move());

        Sub_SendPhysicsHit
            .Subscribe(obj => SendHitObj(obj));

        this.UpdateAsObservable()
            .Where(_ => Vector3.Distance(Vector3.zero, transform.position) > 20)
            .Subscribe(_ => _Sub_OnDied.OnNext(this));
    }

    protected override void HadHitDamage(AnyObject obj)
    {

    }

    protected override void Move()
    {
        transform.Translate(Vector3.forward * _Timedelta * _MoveSpeed);
    }

    protected override void OnDied()
    {
        Destroy(gameObject);
    }

    protected override void OnKill(AnyObject killedObj)
    {
        _TargetChara.NotifyDestruction(killedObj);
    }
}

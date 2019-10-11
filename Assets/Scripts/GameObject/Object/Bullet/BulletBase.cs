using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public abstract class BulletBase : AnyObject
{
    [SerializeField]
    protected float _MoveSpeed = 1;

    [System.NonSerialized]
    public Transform Affiliation = null;

    protected override void Init()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => Move());
    }

    protected override void Start()
    {
        base.Start();

        Sub_SendPhysicsHit
            .Subscribe(obj => SendHitObj(obj));
    }

    protected abstract void Move();

    protected virtual void SendHitObj(AnyObject obj)
    {
        if (CurrentAtackData != null && IsHittableTeam(obj))
        {
            SendDamage(obj);
        }
    }

    protected virtual void SendDamage(AnyObject obj)
    {
        Character character = obj as Character;
        if (character != null) //接触したObjectが敵であることを確認
        {
            if (character.RequestForConfirmationOfAttackDetermination(this))
            {
                _Sub_SendDamageHit.OnNext(obj);
            }
        }
    }
}

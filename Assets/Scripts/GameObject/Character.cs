using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class Character : AnyObject
{
    // ----- 変数 ----- //
    protected ReactiveProperty<int> _NowHealth = new ReactiveProperty<int>();
    public IReadOnlyReactiveProperty<int> NowHealth => _NowHealth;
    protected ReactiveProperty<int> _MaxHealth = new ReactiveProperty<int>();
    public IReadOnlyReactiveProperty<int> MaxHealth => _MaxHealth;
    protected ReactiveProperty<float> _MoveSpeed = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<float> MoveSpeed => _MoveSpeed;
    protected ReactiveProperty<BuffData> _BuffData = new ReactiveProperty<BuffData>();
    public IReadOnlyReactiveProperty<BuffData> BuffData => _BuffData;
    public string RunningSkillName { get; protected set; } = "None";
    
    // ----- 関数 ----- //
    protected override void Start()
    {
        base.Start();

    }

    protected override void Update()
    {
        base.Update();

    }

    protected virtual void PlaySkill(SkillBase skillBase)
    {

    }
}

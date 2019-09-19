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
    protected ReactiveProperty<string> _RunningSkill = new ReactiveProperty<string>();
    public IReadOnlyReactiveProperty<string> RunningSkill => _RunningSkill;

    public Dictionary<string, SkillBase> RunableSkills = new Dictionary<string, SkillBase>();

    // ----- 関数 ----- //
    protected override void Start()
    {
        base.Start();

    }

    /// <summary>
    /// スキルを実行する
    /// </summary>
    /// <param name="runSkillName">実行するスキルの名前</param>
    public void PlaySkill(string runSkillName)
    {
        if (RunableSkills[runSkillName].CanCancel)
        {
            _RunningSkill.Value = RunableSkills[runSkillName].SkillName;
        }
    }
}

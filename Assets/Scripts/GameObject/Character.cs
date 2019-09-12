using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class Character : AnyObject
{    
    // ----- 変数 ----- //
    public int NowHealth { get; protected set; }
    protected int MaxHealth;
    public float MoveSpeed;
    public BuffData buffData;

    // ----- Subject ----- //
    
    // ----- 関数 ----- //
    protected override void Start()
    {
        base.Start();

    }

    protected override void Update()
    {
        base.Update();

    }

    protected virtual void Skill()
    {

    }
}

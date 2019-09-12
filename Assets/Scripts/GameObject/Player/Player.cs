using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Player : Character
{    
    // ----- 変数 ----- //
    public string RunningSkillName { get; protected set; }

    // ----- Subject ----- //
    public Subject<Unit> SkillStart;

    // ----- 関数 ----- //
    protected override void Start()
    {
        base.Start();

    }

    protected override void Update()
    {
        base.Update();

    }

    protected void PlayMotion()
    {

    }
}

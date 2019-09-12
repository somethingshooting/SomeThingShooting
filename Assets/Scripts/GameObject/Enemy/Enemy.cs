using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    // ----- 変数 ----- //
    [SerializeField] protected RuntimeAnimatorController Animator;

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
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : Character
{
    // ----- 変数 ----- //
    [SerializeField] protected RuntimeAnimatorController Animator;

    // ----- Subject ----- //

    // ----- 関数 ----- //
    protected override void Start()
    {
        base.Start();

    }
}

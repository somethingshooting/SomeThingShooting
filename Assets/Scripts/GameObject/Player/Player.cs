using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/* Playerのパラメータ : HP ATK MoveSpeed
 * 
 * 
 */
public class Player : Character
{
    // ----- 変数 ----- //

    // ----- Subject ----- //
    public Subject<Unit> SkillStart;

    // ----- 関数 ----- //
    protected override void Start()
    {
        base.Start();

    }

    protected void PlayMotion()
    {

    }

    protected override void Init()
    {

    }
}

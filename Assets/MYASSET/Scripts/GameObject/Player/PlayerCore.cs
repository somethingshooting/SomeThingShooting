using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/* Playerのパラメータ : HP ATK MoveSpeed
 * 
 * 
 */
public class PlayerCore : Character
{
    // ----- 変数 ----- //


    // ----- 関数 ----- //
    protected override void Init()
    {
        
    }

    /// <summary>
    /// Playerが敵を倒した時の処理
    /// </summary>
    protected override void OnKill(AnyObject killedObj)
    {

    }

    /// <summary>
    /// Playerが死んだときの処理
    /// </summary>
    protected override void OnDied()
    {

    }

    protected override void HadHitDamage(AnyObject obj)
    {
        base.HadHitDamage(obj);
    }
}

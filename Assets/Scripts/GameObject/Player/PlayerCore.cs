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
    protected GameManager _GameManager = null;


    // ----- Subject ----- //

    // ----- 関数 ----- //
    protected override void Init()
    {

    }

    /// <summary>
    /// スキルを実行する
    /// </summary>
    /// <param name="SkillName">実行するスキルの名前</param>
    protected void PlayMotion(string SkillName)
    {

    }

    /// <summary>
    /// Playerが敵を倒した時の処理
    /// </summary>
    protected void OnKilled()
    {

    }

    /// <summary>
    /// Playerが死んだときの処理
    /// </summary>
    protected void OnDied()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerController : BasePlayerComponent
{
    private ActionManager_AA _ActionManager;

    protected override void Init()
    {
        _ActionManager = GetComponent<ActionManager_AA>();

        
    }

    #region Playerのスキル
    private void FirstAdvanceSkill()
    {

    }

    private void SecondAdvanceSkill()
    {

    }

    private void ThirdAdvanceSkill()
    {

    }

    private void ExtraSkill()
    {

    }
    #endregion 
}

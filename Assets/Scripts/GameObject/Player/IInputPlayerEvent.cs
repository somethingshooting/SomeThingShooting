using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IInputPlayerEvent
{
    IReadOnlyReactiveProperty<bool> MoveFront { get; }
    IReadOnlyReactiveProperty<bool> MoveRight { get; }
    IReadOnlyReactiveProperty<bool> MoveLeft { get; }
    IReadOnlyReactiveProperty<bool> MoveBack { get; }
    IReadOnlyReactiveProperty<bool> SlowMove { get; }

    IReadOnlyReactiveProperty<bool> ShootNormalBullet { get; }
    IReadOnlyReactiveProperty<bool> FirstAdvanceSkill { get; }
    IReadOnlyReactiveProperty<bool> SecondAdvanceSkill { get; }
    IReadOnlyReactiveProperty<bool> ThirdAdvanceSkill { get; }
    IReadOnlyReactiveProperty<bool> ExtraSkill { get; }
}

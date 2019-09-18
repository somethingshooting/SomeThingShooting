using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerInputEventProvider : MonoBehaviour, IInputPlayerEvent
{
    protected ReactiveProperty<bool> _MoveFront = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> MoveFront => _MoveFront;
    protected ReactiveProperty<bool> _MoveRight = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> MoveRight => _MoveRight;
    protected ReactiveProperty<bool> _MoveLeft = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> MoveLeft => _MoveLeft;
    protected ReactiveProperty<bool> _MoveBack = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> MoveBack => _MoveBack;
    protected ReactiveProperty<bool> _SlowMove = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> SlowMove => _SlowMove;
    protected ReactiveProperty<bool> _ShootNormalBullet = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> ShootNormalBullet => _ShootNormalBullet;
    protected ReactiveProperty<bool> _FirstAdvanceSkill = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> FirstAdvanceSkill => _FirstAdvanceSkill;
    protected ReactiveProperty<bool> _SecondAdvanceSkill = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> SecondAdvanceSkill => _SecondAdvanceSkill;
    protected ReactiveProperty<bool> _ThirdAdvanceSkill = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> ThirdAdvanceSkill => _ThirdAdvanceSkill;
    protected ReactiveProperty<bool> _ExtraSkill = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> ExtraSkill => _ExtraSkill;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

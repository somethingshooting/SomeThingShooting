using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IAttackable
{
    IObservable<AnyObject> Sub_SendPhysicsHit { get; }
    IObservable<AnyObject> Sub_SendDamageHit { get; }
    IObservable<AnyObject> Sub_OnKill { get; }

}

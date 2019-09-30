using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IAttackable
{
    IObservable<AnyObject> SendPhysicsHit { get; }
    IObservable<AnyObject> SendDamageHit { get; }
    IObservable<AnyObject> OnKill { get; }

}

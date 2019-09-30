using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IDamageable
{
    IObservable<AnyObject> Sub_HadPhysicsHit { get; }
    IObservable<AnyObject> Sub_HadDamageHit  { get; }
    IObservable<AnyObject> Sub_OnDied        { get; }
}

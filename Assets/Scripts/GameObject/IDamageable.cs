using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IDamageable
{
    IObservable<AnyObject> HadPhysicsHit { get; }
    IObservable<AnyObject> HadDamageHit  { get; }
    IObservable<AnyObject> OnDied        { get; }
}

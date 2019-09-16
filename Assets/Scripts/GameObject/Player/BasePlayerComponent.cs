using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class BasePlayerComponent : MonoBehaviour
{
    protected void Start()
    {
        Init();

        LateStart();
    }

    protected abstract void Init();

    protected virtual void LateStart() { }
}

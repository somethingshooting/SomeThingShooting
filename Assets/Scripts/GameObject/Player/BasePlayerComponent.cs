using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class BasePlayerComponent : MonoBehaviour
{
    protected IInputPlayerEvent _InputPlayerEvent { get; set; }
    protected PlayerCore _Core = null;

    protected void Start()
    {
        _Core = GetComponent<PlayerCore>();
        _InputPlayerEvent = GetComponent<IInputPlayerEvent>();
        Init();
    }

    protected abstract void Init();
}

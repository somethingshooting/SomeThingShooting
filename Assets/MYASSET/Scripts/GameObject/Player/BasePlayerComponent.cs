using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class BasePlayerComponent : MonoBehaviour
{
    protected PlayerCore _Core = null;

    protected void Start()
    {
        _Core = GetComponent<PlayerCore>();
        Init();
    }

    protected abstract void Init();
}

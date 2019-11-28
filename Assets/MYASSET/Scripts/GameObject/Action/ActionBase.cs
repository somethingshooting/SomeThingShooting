using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アクションのひな型
/// </summary>
public abstract class ActionBase : MonoBehaviour
{
    public abstract string ActionName { get; protected set; }

    /// <summary>
    /// 割り込みが可能か
    /// </summary>
    public bool CanCancel;

    public abstract void ActionStart();

    public abstract void ActionEnd();
}

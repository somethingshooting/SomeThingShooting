using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    /// <summary>
    /// 割り込みが可能か
    /// </summary>
    public bool Interruptible = false;


    public abstract void SkillStart();

    public abstract void SkillEnd();
}

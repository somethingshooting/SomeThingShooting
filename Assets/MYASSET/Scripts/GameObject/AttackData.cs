using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackDataName",menuName = "SomeShingShooting/AttackData")]
public class AttackData : ScriptableObject
{
    public int DamageValue = 1;
    public List<BuffData> BuffDatas = new List<BuffData>();
}

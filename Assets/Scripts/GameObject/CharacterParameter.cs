using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParameter
{
    public int Value;

    public int BaseValue;

    private List<ParameterEffect> EffectsList;

    public void AddList(ParameterEffect effect)
    {
        EffectsList.Add(effect);
    }

    public void RemoveList(ParameterEffect effect)
    {
        EffectsList.Remove(effect);
    }

    public void Calculate()
    {
        var c = new Comparison<ParameterEffect>(Compare);
        EffectsList.Sort();

        foreach (var item in EffectsList)
        {
            switch (item.ParameterEffectType)
            {
                case ParameterEffectType.Add:
                    Value += item.Value;
                    break;
                case ParameterEffectType.Muiltple:
                    Value += Mathf.RoundToInt(BaseValue * item.Value * 0.01f);
                    break;
                case ParameterEffectType.HightMultple:
                    Value = Mathf.RoundToInt(Value * item.Value * 0.01f);
                    break;
                default:
                    Debug.Log("ParameterEffectTypeに指定されていない値です");
                    break;
            }
        }
    }

    private int Compare(ParameterEffect a, ParameterEffect b)
    {
        return a.Order - b.Order;
    }
}

public class ParameterEffect
{
    //乗算の場合は%ですので, 100で1.00 となります
    public int Value = 0;
    public ParameterEffectType ParameterEffectType;
    public int Order = 0;
    public object Source;

    public ParameterEffect(int value, ParameterEffectType type, int order, object source)
    {
        Value = value;
        ParameterEffectType = type;
        Order = order;
        Source = source;
    }
    public ParameterEffect(int value, ParameterEffectType type, object source)
    {
        Value = value;
        ParameterEffectType = type;
        Order = 0;
        Source = source;
    }
}

public enum ParameterEffectType
{
    Add = 0,//加算
    Muiltple = 1,//乗算
    HightMultple = 2,//現在値をもとに乗算
}
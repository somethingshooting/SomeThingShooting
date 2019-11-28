using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[Serializable]
public class CharacterParameter
{
    [SerializeField]
    private IntReactiveProperty _Value = new IntReactiveProperty();
    public IReadOnlyReactiveProperty<int> Value => _Value;

    public int BaseValue;

    private List<ParameterEffect> EffectsList;

    public void AddList(ParameterEffect effect)
    {
        EffectsList.Add(effect);
        Calculate();
    }

    public void RemoveList(ParameterEffect effect)
    {
        EffectsList.Remove(effect);
        Calculate();
    }

    private void Calculate()
    {
        var c = new Comparison<ParameterEffect>(Compare);
        EffectsList.Sort();

        foreach (var item in EffectsList)
        {
            switch (item.ParameterEffectType)
            {
                case ParameterEffectType.Add:
                    _Value.Value += item.Value;
                    break;
                case ParameterEffectType.Muiltple:
                    _Value.Value += Mathf.RoundToInt(BaseValue * item.Value * 0.01f);
                    break;
                case ParameterEffectType.HightMultple:
                    _Value.Value = Mathf.RoundToInt(Value.Value * item.Value * 0.01f);
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

[Serializable]
public class ParameterEffect
{
    //乗算の場合は%ですので, 100で1.00 となります
    public int Value = 0;
    public ParameterEffectType ParameterEffectType;
    //小さいものから計算される
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
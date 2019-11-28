using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PlayerUI : BasePlayerComponent
{
    [SerializeField]
    private Slider HPSlider = null;

    protected override void Init()
    {
        HPSlider.maxValue = _Core.MaxHealth.Value.Value;

        _Core.NowHealth
            .Subscribe(_ => ChangedNowHealth(_));

        _Core.MaxHealth.Value
            .Subscribe(_ => ChangedMaxHealth(_));
    }

    private void ChangedNowHealth(int value)
    {
        HPSlider.value = value;
    }

    private void ChangedMaxHealth(int value)
    {
        HPSlider.maxValue = value;
    }
}

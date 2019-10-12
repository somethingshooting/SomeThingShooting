using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class NormalShoot_AA : ActionCore_AA
{
    private PlayerCore _Core;

    private Animator _Animator;
    [SerializeField]
    private float _RecastTime = 1.0f;
    private float _Timer = 0;

    [SerializeField]
    private GameObject BulletPrefab = null;

    public override void Start()
    {
        base.Start();
        _Animator = GetComponentInChildren<Animator>();

        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                _Timer += Time.deltaTime;
                _Animator.SetFloat("NormalShootRecast", _RecastTime - _Timer);
            });

        this.UpdateAsObservable()
            .Where(_ => _Manager.Button == 1 && _RecastTime < _Timer)
            .Subscribe(_ =>
            {
                ShootNomalBullet();
                _Timer = 0;
            });
    }

    private void ShootNomalBullet()
    {
        if (BulletPrefab!=null)
        {
            var bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/* 自機狙いの弾を放つ
 * 
 * 
 * 
 */
public class Enemy_Zako : EnemyBase
{
    private GameObject PlayerObj = null;

    [SerializeField]
    private GameObject BulletPrefab = null;

    [SerializeField]
    private float _RecastTime = 1.0f;
    private float _Timer = 0;

    protected override void Init()
    {
        PlayerObj = GameObject.FindWithTag("Player");

        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                _Timer += Time.deltaTime;
                if (_Timer >= _RecastTime)
                {
                    _Timer = 0;
                    ShotBullet();
                }
            });
    }

    protected override void OnKill(AnyObject killedObj)
    {

    }

    protected override void OnDied()
    {
        Destroy(gameObject);
    }

    protected override void HadHitDamage(AnyObject obj)
    {
        base.HadHitDamage(obj);
    }

    private void ShotBullet()
    {
        if (BulletPrefab != null)
        {
            var bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        }
    }
}

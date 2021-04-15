using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Interactable
{
    [Header("Functional")]
    [SerializeField]
    private int damage;
    [SerializeField]
    private int fireRate;
    [SerializeField]
    private LayerMask enemyLayer;
    [SerializeField]
    private int range;

    [Header("Visual")]
    [SerializeField]
    private int heaviness;
    [SerializeField]
    private int maxBloom;
    [SerializeField]
    private int minBloom;
    [SerializeField]
    private ParticleSystem gunShotParticle;

    [Header("Objects")]
    [SerializeField]
    private Transform muzzle;

    private RaycastHit enemyRaycast;
    private GameObject enemy;
    private int timeToFire;
    protected override void HandleAnimation()
    {
        
    }

    protected override void HandleUse()
    {
        timeToFire -= (fireRate / 1000);
        if (activated)
        {
            if (input.wantUse && timeToFire <=0)
            {
                gunShotParticle.Play();
                Physics.Raycast(muzzle.position, muzzle.forward, out enemyRaycast, enemyLayer);
                enemy = enemyRaycast.collider.gameObject;
                enemy.GetComponent<DamageController>().AddDamage(damage);
            }
        }
    }

    protected override void Init()
    {
        transform.position = parent.position;
        transform.parent = parent;
    }
}

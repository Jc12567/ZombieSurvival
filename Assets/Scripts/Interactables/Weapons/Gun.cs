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

    [Header("Audio")]
    [SerializeField]
    private AudioSource audio;

    private RaycastHit enemyRaycast;
    private GameObject enemy;
    private int timeToFire;
    protected override void HandleAnimation()
    {
        
    }

    protected override void HandleUse()
    {
        timeToFire -= (fireRate / 100000);
        if (activated)
        {
            if (input.wantUse && timeToFire <=0)
            {
                Physics.SphereCast(muzzle.position, 0.01f, muzzle.forward, out enemyRaycast, range, enemyLayer);
                gunShotParticle.Play();
                audio.Play();
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

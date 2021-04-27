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
    [SerializeField]
    private Object bullet;

    [Header("Objects")]
    [SerializeField]
    private Transform muzzle;
    [SerializeField]
    private Transform camera;

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
        timeToFire -= (int)((fireRate * Time.deltaTime)/ 100000);
        if (activated)
        {
            if (input.wantUse && timeToFire <=0)
            {
                Physics.SphereCast(camera.position, 0.01f, camera.forward, out enemyRaycast, range, enemyLayer);
                gunShotParticle.Play();
                audio.Play();
                Instantiate(bullet, muzzle.forward, muzzle.rotation, muzzle);
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

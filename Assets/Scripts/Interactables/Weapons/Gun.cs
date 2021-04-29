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
    [SerializeField]
    private Transform camera;

    [Header("Audio")]
    [SerializeField]
    private AudioSource audio;

    private RaycastHit enemyRaycast;
    private GameObject enemy;
    private float timeToFire;
    private Vector3 startPos;
    private Quaternion startRot;
    protected override void HandleAnimation()
    {
        if (activated)
        {
            if (input.wantUse)
            {
                transform.localRotation.SetFromToRotation(transform.localPosition, transform.up);
            }
        }
    }

    protected override void HandleUse()
    {
        if (activated)
        {
            if (input.wantUse && timeToFire <=0)
            {
                Physics.SphereCast(camera.position, 0.01f, camera.forward, out enemyRaycast, range, enemyLayer);
                gunShotParticle.Play();
                audio.Play();
                enemy = enemyRaycast.collider.gameObject;
                enemy.GetComponent<DamageController>().AddDamage(damage);
                timeToFire = 100/fireRate;
            }
        }
    }

    protected override void Init()
    {
        transform.position = parent.position;
        transform.parent = parent;
        startPos = transform.localPosition;
        startRot = transform.localRotation;
        transform.localRotation.SetFromToRotation(transform.localPosition, parent.forward);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (!(timeToFire <= 0))
        {
            timeToFire -= (fireRate* Time.deltaTime)/10;
        }
    }
}

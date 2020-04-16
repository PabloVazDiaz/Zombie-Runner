using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammoSlot.GetCurrentAmmo() > 0)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        PlayMuzzleEffect();
        ProcessRaycast();
        ammoSlot.ReduceCurrentAmmo();
    }

    private void PlayMuzzleEffect()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            GameObject go = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(go, 0.1f);
            print(hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
                target.Damage(damage);
        }
    }
}

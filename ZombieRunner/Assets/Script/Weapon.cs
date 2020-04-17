using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] float fireRate;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;


    private bool isAbleToShoot = true;


    // Start is called before the first frame update
    private void OnEnable()
    {
        isAbleToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
        if (Input.GetMouseButtonDown(0))
        {
            if (ammoSlot.GetCurrentAmmo(ammoType) > 0 && isAbleToShoot)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        PlayMuzzleEffect();
        ProcessRaycast();
        ammoSlot.ReduceCurrentAmmo(ammoType);
        StartCoroutine(ShootCooldown());
    }

    private IEnumerator ShootCooldown()
    {
        isAbleToShoot = false;
        yield return new WaitForSeconds(fireRate);
        isAbleToShoot = true;
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

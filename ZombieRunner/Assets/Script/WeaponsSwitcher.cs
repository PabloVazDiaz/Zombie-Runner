using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSwitcher : MonoBehaviour
{

    [SerializeField] int currentWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    private void IncreaseCurrentWeapon()
    {
        if (currentWeapon >= transform.childCount -1)
        {
            currentWeapon = 0;
        }
        else
        {
            currentWeapon++;
        }
    }

    private void DecreaseCurrentWeapon()
    {
        if (currentWeapon == 0)
        {
            currentWeapon = transform.childCount -1;
        }
        else
        {
            currentWeapon--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = currentWeapon;
        ProcessMouseWheel();
        ProcessKeyInput();
        if(currentWeapon!=previousWeapon)
            SetWeaponActive();
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
        
        
    }

    private void ProcessMouseWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            IncreaseCurrentWeapon();
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            DecreaseCurrentWeapon();
        }
    }
}

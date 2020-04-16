﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float normalFOV;
    [SerializeField] float zoomedFOV;
    [SerializeField] float normalMouseSensitivity = 2f;
    [SerializeField] float zoomedMouseSensitivity = 1f;


    bool isZoomend = false;
    Camera FPCamera;
    UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController FPSController;

    // Start is called before the first frame update
    void Start()
    {
        FPCamera = GetComponentInChildren<Camera>();
        FPSController = GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ChangeZoom();
        }
    }

    private void ChangeZoom()
    {
        if (isZoomend)
        {
            FPCamera.fieldOfView = normalFOV;
            FPSController.mouseLook.XSensitivity = normalMouseSensitivity;
            FPSController.mouseLook.YSensitivity = normalMouseSensitivity;
        }
        else
        {
            FPCamera.fieldOfView = zoomedFOV;
            FPSController.mouseLook.XSensitivity = zoomedMouseSensitivity;
            FPSController.mouseLook.YSensitivity = zoomedMouseSensitivity;
        }
        isZoomend = !isZoomend;
    }

}

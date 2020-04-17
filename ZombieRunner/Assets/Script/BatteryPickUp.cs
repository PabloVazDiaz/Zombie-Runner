using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float addIntensity = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FlashLightSystem flashLight = other.gameObject.GetComponentInChildren<FlashLightSystem>();
            flashLight.RestoreLightAngle(restoreAngle);
            flashLight.RestoreLightIntesity(addIntensity);
            Destroy(gameObject);
        }
    }
}

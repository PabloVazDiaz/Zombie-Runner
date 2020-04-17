using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{

    [SerializeField] AmmoType ammoType;
    [SerializeField] int amount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Ammo>().IncreaseCurrentAmmo(ammoType, amount);
            Destroy(this.gameObject);
        }
    }
}

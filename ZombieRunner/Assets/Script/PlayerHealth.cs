using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas damageCanvas;

    private void Start()
    {
        damageCanvas.enabled = false;
        gameOverCanvas.enabled = false;
    }

    public void TakeDamage( float damage)
    {
        hitPoints -= damage;
        StartCoroutine(hitCanvasDisplay());
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private IEnumerator hitCanvasDisplay()
    {
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(0.15f);
        damageCanvas.enabled = false;
    }

    private void Die()
    {
        gameOverCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FindObjectOfType<WeaponsSwitcher>().enabled = false;
        Time.timeScale = 0;
        print("You dead");
    }
}

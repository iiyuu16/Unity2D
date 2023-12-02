using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour
{
    private TopDownCharacterController player;
    private float healingTime = 3.0f;
    private bool isHealing = false;
    private float healingTimer = 0.0f;

    private void Update() {
        if (isHealing) {
            if (player.currentHP < player.maxHP)
            {
                healingTimer += Time.deltaTime;

                if (healingTimer >= healingTime)
                {
                    player.currentHP = player.maxHP;
                    Debug.Log("Player HP: " +player.currentHP+ "/" +player.maxHP);
                }
            }
            else {
                healingTimer = 0.0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player = other.GetComponent<TopDownCharacterController>();
        if (other.CompareTag("Player")) {
            isHealing = true;
            Debug.Log("player in zone");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            isHealing = false;
            healingTimer = 0.0f;
            Debug.Log("player left zone");
        }
    }

}

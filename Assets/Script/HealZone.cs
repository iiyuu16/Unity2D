using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour
{
    private TopDownCharacterController player;
    private float healingInterval = 1.0f; // Interval in seconds between each healing tick
    private float healingTimer = 0.0f;

    private void Update()
    {
        if (player != null && player.currentHP < player.maxHP && IsPlayerInHealingZone())
        {
            healingTimer += Time.deltaTime;

            if (healingTimer >= healingInterval)
            {
                // Heal the player by 1 HP
                player.currentHP += 1;

                // Clamp the HP to the maxHP
                player.currentHP = Mathf.Min(player.currentHP, player.maxHP);

                Debug.Log("Player HP: " + player.currentHP + "/" + player.maxHP);

                // Reset the timer after each healing tick
                healingTimer = 0.0f;
            }
        }
        else
        {
            // Reset the timer if the player is not in the healing zone
            healingTimer = 0.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<TopDownCharacterController>();
            Debug.Log("Player entered healing zone");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = null; // Player left the zone, set player to null
            Debug.Log("Player left healing zone");
        }
    }

    private bool IsPlayerInHealingZone()
    {
        return player != null;
    }
}

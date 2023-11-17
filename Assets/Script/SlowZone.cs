using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        TopDownCharacterController player = other.GetComponent<TopDownCharacterController>();

        if (player != null) { 
            player.speed = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        TopDownCharacterController player = other.GetComponent<TopDownCharacterController>();

        if (player != null)
        {
            player.speed = 3;
        }
    }
}

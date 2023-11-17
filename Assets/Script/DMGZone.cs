using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        TopDownCharacterController player = other.GetComponent<TopDownCharacterController>();

        if (player != null)
        {
            player.changeHP(-1);
        }
    }
}

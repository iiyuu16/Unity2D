using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HPCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        TopDownCharacterController player = other.GetComponent<TopDownCharacterController>();

        if (player != null){
            if (player.HP < player.maxHP) {
                player.changeHP(+1);
                Destroy(gameObject);
            }
        }
    }
}
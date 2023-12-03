using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAfterDeath : MonoBehaviour
{
    public GameObject objectToDisable;

    private void OnDisable()
    {
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }
    }
}

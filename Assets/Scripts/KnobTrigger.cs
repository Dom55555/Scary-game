using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PLAYER")
        {
            Gamemanager.KnobCollected = true;
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PLAYER")
        {
            Gamemanager.PlayerHiding = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name=="PLAYER")
        {
            Gamemanager.PlayerHiding = false;
        }
    }

}

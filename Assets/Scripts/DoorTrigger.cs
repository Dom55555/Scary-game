using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Transform door;
    public Gamemanager game;

    float animationTime = 2f;
    bool animationProcess = false;
    bool standing = false;
    float timer = 0f;

    AudioSource[] sources;

    void Start()
    {
        sources = GetComponents<AudioSource>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && standing && door.transform.rotation.eulerAngles.y == 305)
        {
            if(Gamemanager.KnobCollected)
            {
                sources[0].Play();
                animationProcess = true;
                timer = 0f;
            }
            else
            {
                sources[1].Play();
                game.cantUnlockDoorText();
            }
        }
        if (animationProcess && timer < animationTime)
        {
            door.transform.Rotate(0f,80/animationTime*Time.deltaTime,0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PLAYER")
        {
            standing = true;
            if (Gamemanager.KnobCollected && !door.Find("Knob").gameObject.activeSelf)
            {
                sources[2].Play();
                door.Find("Knob").gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        standing = false;
    }
}

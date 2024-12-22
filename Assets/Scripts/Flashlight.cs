using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Light spotLight;
    public float energy = 100f;
    public float dischargeSpeed = 1f;
    public Transform batteryLevelIndicator;
    AudioSource sound;

    void Start()
    {
        spotLight = GetComponentInChildren<Light>();
        sound = GetComponent<AudioSource>();
        spotLight.enabled = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && energy > 0f)
        {
            sound.Play();
            spotLight.enabled = !spotLight.enabled;
        }
        if(spotLight.enabled)
        {
            energy -= Time.deltaTime * dischargeSpeed;
        }
        if(energy < 25f)
        {
            spotLight.intensity = Random.Range(0f,1f);
        }
        if(energy<0f)
        {
            spotLight.enabled = false;
            energy = 0f;
        }
        batteryLevelIndicator.localScale = new Vector3(energy / 100f, 1f, 1f);
    }

}

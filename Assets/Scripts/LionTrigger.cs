using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionTrigger : MonoBehaviour
{
    public Transform lion;
    public GameObject books;
    public Gamemanager game;

    bool animationProcess = false;
    float timer = 0f;
    AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(animationProcess)
        {
            books.SetActive(true);
            if(timer>1f)
            {
                if(lion.position.x == 95.519f)
                {
                    sound.Play();
                }
                lion.position = Vector3.MoveTowards(lion.position,new Vector3(95.16f,9.3f,97.79f),Time.deltaTime/1.8f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(Gamemanager.objectiveNum == 1 || Gamemanager.objectiveNum == 3)
        {
            game.nextObjective();
        }
        if (other.name == "PLAYER" && Gamemanager.PartsCollected == 3)
        {
            animationProcess = true;
            timer = 0f;
        }
    }
}

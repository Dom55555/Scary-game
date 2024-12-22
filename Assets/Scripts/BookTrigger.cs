using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTrigger:MonoBehaviour
{
    public Enemy enemy;
    public Gamemanager game;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PLAYER")
        { 
            game.addBooks();
            gameObject.SetActive(false);
        }
    }
}

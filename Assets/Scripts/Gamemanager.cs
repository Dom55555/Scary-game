using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public TMP_Text booksText;
    public TMP_Text doorText;
    public TMP_Text objectiveText;
    public GameObject bookIcon;

    public Enemy enemy;

    public static int objectiveNum = 1;
    public static int PartsCollected = 0;
    public static bool PlayerHiding = false;
    public static bool KnobCollected = false;

    static float timer = 0f;
    float objTimer = 0f;

    Color colorText;
    AudioSource[] sources;
    void Start()
    {
        sources = GetComponents<AudioSource>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        objTimer += Time.deltaTime;
        if(timer>2f)
        {
            doorText.gameObject.SetActive(false); 
        }
        if(objTimer>1f)
        {
            if (objectiveNum == 2)
            {
                changeTextColor(objectiveText);
                if (objTimer > 3f)
                {
                    booksText.gameObject.SetActive(true);
                    bookIcon.SetActive(true);
                }
            }
            else if (objectiveNum == 3)
            {
                changeTextColor(booksText);
                colorText = bookIcon.GetComponent<Image>().color;
                colorText.a = Mathf.Clamp(colorText.a - Time.deltaTime, 0, 1); 
                bookIcon.GetComponent<Image>().color = colorText;
                if (objTimer > 3f)
                {
                    objectiveText.text = "Return to the statue";
                    objectiveText.color = Color.white;
                }
            }
            else if (objectiveNum == 4)
            {
                changeTextColor(objectiveText);
                if (objTimer > 3f)
                {
                    objectiveText.text = "Find and unlock exit";
                    objectiveText.color = Color.white;
                }
            }
        }
    }
    void changeTextColor(TMP_Text Object)
    {
        colorText = Object.color;
        colorText.a = Mathf.Clamp(colorText.a - Time.deltaTime, 0, 1);
        Object.color = colorText;
    }
    public void addBooks()
    {
        sources[0].Play();
        PartsCollected++;
        booksText.text = PartsCollected.ToString() + " / 3";
        enemy.difficulty();
        if(PartsCollected==3)
        {
            nextObjective();
        }
    }
    public void gameOver()
    {

    }
    public void cantUnlockDoorText()
    {
        timer = 0f;
        doorText.gameObject.SetActive(true);
    }
    public void nextObjective()
    {
        objTimer = 0f;
        objectiveNum++;
        if(objectiveNum==2||objectiveNum==4)
        {
            objectiveText.color = Color.green;
        }
        if(objectiveNum == 3)
        {
            booksText.color = Color.green;
        }
    }
}

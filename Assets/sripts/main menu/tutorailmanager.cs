using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tutorailmanager : MonoBehaviour
{
    // private bool stacticmessageson;
    [SerializeField] private GameObject[] messages;
    [SerializeField] private GameObject[] joystick;
    [SerializeField] private GameObject[] jump;
    [SerializeField] private GameObject[] buttonS;
    [SerializeField] private GameObject[] manualS;
    [SerializeField] private GameObject[] ground_distroy;
    [SerializeField] private GameObject[] health;
    [SerializeField] private GameObject[] score;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject[] setting;
    [SerializeField] private GameObject[] exit;
    [SerializeField] private Button jumpbuttonclick;
    [SerializeField] private Button shoot;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject dummyenemy;
    [SerializeField] private GameObject upperimage;
    [SerializeField] private GameObject lowerimage;
    [SerializeField] private GameObject fadeimage;
    private bool isbutton = true;
    // private bool joystickbool = true;
    // private bool jumpbool = true;
    // private bool shootbool = true;
    // private bool maunalshootbool = true;
    [SerializeField] private float delay;

    void Start()
    {
        if(PlayerPrefs.GetString("shootingway","b") == "b")
        {
            text.text = "press shoot button to fire on vipers";
            Debug.Log("button is active in the settings");
            isbutton = true;
        }
        else
        {
            text.text = "tap on the enemy to fire on vipers";
            Debug.Log("manual firing is enables in the settings");
            isbutton = false;
        }
        joystickbutton();
    }
    
    public void joystickbutton()// for starting a the first message
    {
        upperimage.SetActive(true);
        alltheelementofamessage(joystick,true);
    }

    public void jumpbutton() // for joystickbutton
    {
        alltheelementofamessage(joystick,false);
        alltheelementofamessage(jump,true);
    }

    public void shootway()
    {
        if(isbutton)
        {
            shootbutton();
        }
        else
        {
            manualslide();
        }
    }

    void shootbutton()
    {
        alltheelementofamessage(jump,false);
        alltheelementofamessage(buttonS,true);
    }

    void manualslide()
    {
        alltheelementofamessage(jump,false);
        alltheelementofamessage(manualS,true);
    }

    public void grounddistroy()
    {
        alltheelementofamessage(buttonS,false);
        alltheelementofamessage(manualS,false);
        alltheelementofamessage(ground_distroy,true);
        upperimage.SetActive(false);
    }
    
    void health_info()
    {
        lowerimage.SetActive(true);
        alltheelementofamessage(ground_distroy,false);
        alltheelementofamessage(health,true);
        Invoke("score_info",delay);
    }

    void score_info()
    {
        alltheelementofamessage(health,false);
        alltheelementofamessage(score,true);
        Invoke("enemy_info",delay);
    }

    void enemy_info()
    {
        alltheelementofamessage(score,false);
        alltheelementofamessage(enemy,true);
        Invoke("setting_info",delay);
    }
    void setting_info()
    {
        alltheelementofamessage(enemy,false);
        alltheelementofamessage(setting,true);
        Invoke("exit_info",delay);
    }
    void exit_info()
    {
        alltheelementofamessage(setting,false);
        alltheelementofamessage(exit,true);
        Invoke("fade_event",delay);
    }
    void fade_event()
    {
        alltheelementofamessage(exit,false);
        Invoke("fadescreen",2f);
        gamemanger.instance.loadgamemainmenu();
    }
    void fadescreen()
    {
        fadeimage.SetActive(true);
    }

    // trun on or off the array of gameObject
    void alltheelementofamessage(GameObject[] themessageelement,bool turnon)
    {
        foreach (GameObject obj in themessageelement)
        {
            if(obj == null)
            {
                return;
            }
            if(obj == themessageelement[themessageelement.Length - 1])
            {
                obj.SetActive(false);
                return;
            }
            obj.SetActive(turnon);
        }
    }


}

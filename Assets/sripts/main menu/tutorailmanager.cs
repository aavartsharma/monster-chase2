using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorailmanager : MonoBehaviour
{
    private bool stacticmessageson;
    [SerializeField] private GameObject[] messages;
    [SerializeField] private GameObject[] joystick;
    [SerializeField] private GameObject[] jump;
    [SerializeField] private GameObject[] shoot;
    [SerializeField] private GameObject[] health;
    [SerializeField] private GameObject[] score;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject dummyenemy;
    [SerializeField] private GameObject upperimage;
    [SerializeField] private GameObject lowerimage;
    private bool joystickbool = true;
    private bool jumpbool = true;
    private bool shootbool = true;
    private int a = 0;
    [SerializeField] private float delay;

    void Start()
    {
        // start displaying the message after n seconds
        Invoke("startingmessage",2.0f);
    }

    void Update()
    {
        
        // countine the message that have no button atteched
    }

    void startingmessage()// for starting a the first message
    {
        upperimage.SetActive(true);
        alltheelementofamessage(joystick,true);
    }

    public void joystickbutton()
    {
        if(joystickbool)
        {
            alltheelementofamessage(joystick,false);
            alltheelementofamessage(jump,true);
            joystickbool = false;
        }
        
    }

    public void jumpbutton()
    {
        if(jumpbool)
        {
            alltheelementofamessage(jump,false);
            alltheelementofamessage(shoot,true);
            jumpbool = false;
        }
    }

    public void shootbutton()
    {
        if(dummyenemy == null && shootbool)
        {
            alltheelementofamessage(shoot,false);
            stacticmessageson = true;
            shootbool = false;
            lowerimage.SetActive(true);
        }
    }

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

    public void doittrue(){
        stacticmessageson=true;
    }

    public void lowermessages()
    {
        lowerimage.SetActive(true);
        if(a >= messages.Length)
        {
            stacticmessageson = false;
            return;
        }
        if(a-1 > 0)
        {
            messages[a-1].SetActive(false);
        }
        messages[a].SetActive(true);
        a++;
    }


}

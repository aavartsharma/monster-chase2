using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class store : MonoBehaviour
{
    [SerializeField] private GameObject alreadyOwned;
    [SerializeField] private GameObject togetplayer2;
    [SerializeField] private GameObject tosetplayer1;
    [SerializeField] private GameObject tosetplayer2;
    [SerializeField] private GameObject needmorecoin;
    [SerializeField] private GameObject player2owedtext;
    [SerializeField] private GameObject amount;
    [SerializeField] private GameObject bagmessage;

    void Awake()
    {
        if(PlayerPrefs.GetInt("panthersoldout",0) == 1)
        {
            onoroffmessage(player2owedtext,true);
            onoroffmessage(amount,false);
        }
    }

    void onoroffmessage(GameObject obj,bool onoroff)
    {
        obj.SetActive(onoroff);
        bagmessage.SetActive(onoroff);
    }
    public void onplayerskintap(string playername)
    {
        if(playername == "garo") // if the button was of garo
        {
            if(PlayerPrefs.GetString("currentplayer","garo") == "garo") // if current skin is of garo
            {
                onoroffmessage(alreadyOwned,true);
                //alreadyOwned.SetActive(true);
            }
            else
            {
                onoroffmessage(tosetplayer1,true);
                //tosetplayer1.SetActive(true);
            }
        }
        if(playername == "panther") // if the button was of panther
        {
            if(PlayerPrefs.GetInt("panthersoldout",0) == 0)// if want to buy
            {
                onoroffmessage(togetplayer2,true);
                //togetplayer2.SetActive(true);
            }
            else if(PlayerPrefs.GetString("currentplayer","garo") == "panther") // if current skin is of panther
            {
                onoroffmessage(alreadyOwned,true);
                // alreadyOwned.SetActive(true);
            }
            else
            {
                onoroffmessage(tosetplayer2,true);
                tosetplayer2.SetActive(true);
            }
        }
    }
    

    public void confirmedtobuy(int coinneeded)
    {
        int coins = PlayerPrefs.GetInt("bitcoins",0);
        if(coins - coinneeded < 0)
        {
            onoroffmessage(needmorecoin,true);
            // needmorecoin.SetActive(true);
        }
        else
        {
            int coinsleft = coins - coinneeded;
            PlayerPrefs.SetInt("bitcoins", coinsleft);
            PlayerPrefs.SetString("currentplayer","panther");
            PlayerPrefs.SetInt("panthersoldout",1);
            PlayerPrefs.Save();
            onoroffmessage(player2owedtext,true);
            onoroffmessage(amount,false);
            // player2owedtext.SetActive(true);
            // amount.SetActive(false);
        }
    }

    public void equpthisskin(string name)
    {
        PlayerPrefs.SetString("currentplayer",name);
    }
}

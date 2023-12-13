using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameoverbroad : MonoBehaviour
{
    [SerializeField] private playermover rewardingsystem;
    [SerializeField] private scorestexts scores;
    [SerializeField] private TextMeshProUGUI best;
    [SerializeField] private TextMeshProUGUI rewardgiven;
    [SerializeField] private TextMeshProUGUI currentscore;
    [SerializeField] private TextMeshProUGUI diffculty;

    void Start()
    {
        int giventhebit = playermover.instance.bitsgiven;
        int verycurrentscore = (int) scores.finalscores;
        best.text = PlayerPrefs.GetInt("highscore",0).ToString();
        rewardgiven.text = giventhebit.ToString();
        currentscore.text = verycurrentscore.ToString();
        string d = gamemanger.instance.settingList[3];
        diffculty.text = d;
        /*if(d == 0)
        {
            diffculty.text = "Very Easy";
        }
        if(d == 1)
        {
            diffculty.text = "Easy";
        }
        if(d == 2)
        {
            diffculty.text = "Normal";
        }
        if(d == 3)
        {
            diffculty.text = "Hard";
        }*/

    }
}

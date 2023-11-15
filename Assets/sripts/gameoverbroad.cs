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
        int giventhebit = (int)(scores.finalscores * (scores.speicalkills + scores.normalkills)/100);
        int verycurrentscore = (int) scores.finalscores;
        best.text = PlayerPrefs.GetInt("highscore",0).ToString();
        rewardgiven.text = giventhebit.ToString();
        currentscore.text = verycurrentscore.ToString();

    }
}

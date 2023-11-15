using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scorestexts : MonoBehaviour
{
    public int speicalkills;
    public int normalkills;
    public int highscorebyplayer; // highest score done by player
    public float finalscores; // the score that should be displayed to the player 
    [SerializeField] private TextMeshProUGUI scores;
    [SerializeField] private Transform playery;
    //[SerializeField] private playermover shouldgetdouble;// player refernce
    [SerializeField] private int perkillscore; // the extra score per kill
    [SerializeField] private Image image;
    private int perkill2;
    private int extraofnormal;
    private int extraofspeical;
    private float extrascores; // the score gained by killing the enemys
    private float playerpos; // the current y coordanite of player

    void Start()
    {
        extrascores = 0f;
        perkill2 = perkillscore * 2;
        highscorebyplayer = PlayerPrefs.GetInt("highscore",0);
    }

    void Update()
    {
        if(finalscores >= highscorebyplayer)
        {
            image.fillAmount = 1f;
        }
        if(finalscores <= highscorebyplayer) // if pass this than player has made an highscore
        {
            image.fillAmount = finalscores/highscorebyplayer;
        }
        
        else if(highscorebyplayer == 0)
        {
            highscorebyplayer = 1;
        }
        // the score of the player get x2
        /*if(shouldgetdouble.doublekillscore)
        {
            playerpos = playery.position.y;
            extraofspeical = speicalkills * perkill2;
            extrascores = extraofspeical + extraofs;
            finalscores = playerpos + extrascores;
            scores.text = finalscores.ToString("0");
        }*/
        
        /*else
        {
            playerpos = playery.position.y;
            extraofnormal = normalkills * perkill2;
            extrascores = extraofnormal + extraofs;
            finalscores = playerpos + extrascores;
            scores.text = finalscores.ToString("0");
        }*/

        playerpos = playery.position.y;
        extraofnormal = normalkills * perkillscore;
        extraofspeical = speicalkills * perkill2;
        extrascores = extraofspeical + extraofnormal;
        finalscores = playerpos + extrascores;
        scores.text = finalscores.ToString("0");
        /*Debug.Log("y: "+playerpos);
        Debug.Log("normalkillingscore: "+extraofnormal+"   spkilling: "+extraofspeical);
        Debug.Log("finalscores: "+finalscores+"   extrasorces: "+extrascores);*/


    }
}

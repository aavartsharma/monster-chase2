using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject twox;
    [SerializeField] private GameObject hiteffect;// the particle that should appear
    [SerializeField] private playermover playerscripts;
    [SerializeField] private int powerupstime;
    [SerializeField] private string ground;// groundtag
    [SerializeField] private string ground2;
    [SerializeField] private string texttag; // texttag
    [SerializeField] private string untag;
    [SerializeField] private string heartTag;
    [SerializeField] private string twoxTag;
    private scorestexts numberofenemykill;
    private playeraudio audioofplayer;

    void Start()
    {
        audioofplayer = GameObject.FindWithTag("playersaudio").GetComponent<playeraudio>();
        playerscripts = GameObject.FindWithTag("Player").GetComponent<playermover>();
        numberofenemykill = GameObject.FindWithTag(texttag).GetComponent<scorestexts>(); // will give the text gameobject refernce
        Destroy(gameObject,10f);
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag(twoxTag) || collider.gameObject.CompareTag(heartTag))
        {
            return;
        }
        bool isplayer = collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag(untag);
        if(!isplayer)// if the gameobject is not player
        {
            bool isground = collider.gameObject.CompareTag(ground);
            bool isground2 = collider.gameObject.CompareTag(ground2);
            if(!isground && !isground2)// if the gameobject is not on the ground
            {
                int speicalkilling = numberofenemykill.speicalkills;
                int normalkilling = numberofenemykill.normalkills;
                Vector2 hitonenemy = collider.transform.position;
                GameObject particle = Instantiate(hiteffect,hitonenemy,Quaternion.identity);
                if(Random.Range(1,4) == 1)
                {
                    if(Random.Range(1,3) == 1)
                    {
                        GameObject spawed1=Instantiate(twox,hitonenemy,Quaternion.identity);
                        Destroy(spawed1,powerupstime);
                    }
                    else{
                        GameObject spawed2=Instantiate(heart,hitonenemy,Quaternion.identity);
                        Destroy(spawed2,powerupstime);
                    }
                }
                audioofplayer.playaudio(5);
                Destroy(collider.gameObject);
                if(playerscripts.doublekillscore)
                {
                    speicalkilling++;
                    numberofenemykill.speicalkills = speicalkilling; 
                }
                else
                {
                    normalkilling++;
                    numberofenemykill.normalkills = normalkilling;
                }
                Destroy(particle,3f);
                Destroy(gameObject);
            }
            else if(isground2)
            {
                Destroy(gameObject);
            }
        }

       
    }
}

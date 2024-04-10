using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    [SerializeField] private string[] enemytag;
    [SerializeField] private string[] notDestroy;
    [SerializeField] private GameObject[] particles;
    [SerializeField] private GameObject[] PickUps;
    [SerializeField] private GameObject hiteffect;// the particle that should appear
    [SerializeField] private int powerupstime;
    [SerializeField] private string texttag; // texttag
    [SerializeField] private string ground;
    [SerializeField] private string ground2;
    private playermover playerscripts;
    private scorestexts numberofenemykill;
    private playeraudio audioofplayer;

    void Start()
    {
        audioofplayer = GameObject.FindWithTag("playersaudio").GetComponent<playeraudio>();
        playerscripts = GameObject.FindWithTag("Player").GetComponent<playermover>();
        numberofenemykill = GameObject.FindWithTag(texttag).GetComponent<scorestexts>(); // will give the text gameobject refernce
        Destroy(gameObject,10f);
    }

    GameObject findCorrectPartile(string tag,Vector2 position) // find and instances the correct particle gameobject
    {  
        int index  = 0;
        //ghost,greenenemy,redenemy,missile
        foreach (var item in enemytag)
        {
            if(tag == item)
            {
                GameObject particle = particles[index];
                particle = Instantiate(particle,position,Quaternion.identity);
                return particle;
            }
            index++;
        }
        return hiteffect;
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        /*foreach(string Tag in notDestroy)
        {
            if(collider.gameObject.CompareTag(ground) || collider.gameObject.CompareTag(ground2))
            {
                Destroy(gameObject);
                return;
            }
            if(collider.gameObject.CompareTag(Tag))
            {
                return;
            }
        }*/
        foreach (string item in enemytag)
        {
            if(collider.gameObject.CompareTag(ground) || collider.gameObject.CompareTag(ground2))
            {
                Destroy(gameObject);
                return;
            }
            if(!collider.gameObject.CompareTag(item))
            {
                Debug.Log("the item is nkot an enemy");
                return;
            }
        }
        Debug.Log("the item is an enemy");
        int speicalkilling = numberofenemykill.speicalkills;
        int normalkilling = numberofenemykill.normalkills;
        Vector2 hitonenemy = collider.transform.position;
        string Etag = collider.gameObject.tag;
        GameObject particle = findCorrectPartile(Etag,hitonenemy);// Instantiate(hiteffect,hitonenemy,Quaternion.identity);
        if(Random.Range(1,4) == 1)
        {
            int length = PickUps.Length;
            int randomNumber = Random.Range(0,length-1);
            GameObject spwanedPickUp = Instantiate(PickUps[randomNumber],hitonenemy,Quaternion.identity);
            Destroy(spwanedPickUp,powerupstime);
            /*if(Random.Range(1,3) == 1)
            {
                GameObject spawed1=Instantiate(twox,hitonenemy,Quaternion.identity);
                Destroy(spawed1,powerupstime);
            }
            else{
                GameObject spawed2=Instantiate(heart,hitonenemy,Quaternion.identity);
                Destroy(spawed2,powerupstime);
            }*/
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
        
        /*if( || collider.gameObject.CompareTag(heartTag))
        {
            return;
        }
        bool isplayer = collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag(untaggedObjet);
        if(!isplayer)// if the gameobject is not player
        {
            bool isground = collider.gameObject.CompareTag(ground);
            bool isground2 = collider.gameObject.CompareTag(ground2);
            if(!isground && !isground2)// if the gameobject is not on the ground
            {
                int speicalkilling = numberofenemykill.speicalkills;
                int normalkilling = numberofenemykill.normalkills;
                Vector2 hitonenemy = collider.transform.position;
                string Etag = collider.gameObject.tag;
                GameObject particle = findCorrectPartile(Etag,hitonenemy);// Instantiate(hiteffect,hitonenemy,Quaternion.identity);
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
        }*/

       
    }
}

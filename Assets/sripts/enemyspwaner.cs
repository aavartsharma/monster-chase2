using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspwaner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemys; // every possible enemys
    [SerializeField] private GameObject[] allenemyspawar;// having 9 spawers
    [SerializeField] private GameObject[] allthegrounds;
    [SerializeField] private int numofenemy = 2; // number of enemy spawered

    // Update is called once per frame
    void Start()
    {
        if(allenemyspawar.Length != allthegrounds.Length)
        {
            Debug.LogWarning("both are not equal");
            return;
        }
        for(int i = 1; i <= numofenemy;i++)
        {
            int random_number = Random.Range(0,allenemyspawar.Length);
            Transform spawerpos = allenemyspawar[random_number].transform; // gets the random spawer position
            GameObject theground = allthegrounds[random_number];
            bool activeness = theground.gameObject.activeSelf;
            if(theground.gameObject.activeSelf)// checking if the the random transform's gameobject is active or not
            {
                Debug.Log("the spawer "+activeness);
                GameObject enemychoser = enemys[Random.Range(0,enemys.Length)]; // gets the random enemy perpab
                Instantiate(enemychoser,spawerpos.position,spawerpos.rotation);
            }
            else
            {
                Debug.Log("i-- "+activeness);
                i--;
            }
        }
    }
}

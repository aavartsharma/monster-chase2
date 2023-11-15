using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missilespawer : MonoBehaviour
{
    [SerializeField] private GameObject[] spawingobjects;
    [SerializeField] private int y =10;
    [SerializeField] private string playerTag;
    private int randomNumber1;
    private Transform player;
    void Start()
    {
        player = GameObject.FindWithTag(playerTag).transform;
    }
    void Update()
    {
        float distanceY = player.position.y - transform.position.y;
        randomNumber1 = Random.Range(0,spawingobjects.Length);
        if(distanceY < y && player.position.y >= 100f)
        {
            int randomNumber2 = Random.Range(0,3);
            if(randomNumber2 == 1)
            {
                Instantiate(spawingobjects[randomNumber1],transform.position,Quaternion.identity);
            }
            Destroy(gameObject);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radomoffer : MonoBehaviour
{
    [SerializeField] private GameObject[] grounds;// if fisrt ground 9 else 8
    [SerializeField] private Transform playery;
    [SerializeField] private float cameraLength;
    private int a;
    void Start()
    {
        for(int i = 0;i < grounds.Length;i++)
        {
            grounds[i].SetActive(true);
        }
        for(int i = 0;i <= 7;i++)
        {
            a = Random.Range(0,grounds.Length);
            if(a != 3 && a != 6)
            {
                grounds[a].SetActive(false);
            }
        } 
    }
    
}

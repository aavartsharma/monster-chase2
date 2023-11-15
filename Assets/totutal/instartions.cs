using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instartions : MonoBehaviour
{
    [SerializeField] private GameObject[] messages;
    private int sss;
    
    public void showmessage()
    {
        sss++;
        messages[sss].SetActive(true);
    }

    
}

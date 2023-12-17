using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementground : MonoBehaviour
{
    [SerializeField] private GameObject mainObject;
    private int limit = 5;
    private int smashes = 0;
    void OnTriggerEnter2D(Collider2D collidier)
    {
        if(collidier.CompareTag("Player"))
        {
            smashes++;
        }
        if(smashes >= limit)
        {
            Destroy(mainObject);
        }
    }
}

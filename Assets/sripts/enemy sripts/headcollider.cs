using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headcollider : MonoBehaviour
{
    [SerializeField] private GameObject thisenemy;
    [SerializeField] private GameObject enemydieparticle;
    [SerializeField] private string playerfoottag;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag(playerfoottag))
        {
            Destroy(thisenemy);
            Instantiate(enemydieparticle, thisenemy.transform.position, Quaternion.identity);
        }
    }
}

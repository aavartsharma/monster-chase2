using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tbullet : MonoBehaviour
{
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject twox;
    [SerializeField] private GameObject hiteffect;// the particle that should appear
    [SerializeField] private string ground;// groundtag
    [SerializeField] private string texttag; // texttag
    [SerializeField] private string heartTag;
    [SerializeField] private string twoxTag;

    void Start()
    {
        Destroy(gameObject,10f);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag(twoxTag) || collider.gameObject.CompareTag(heartTag))
        {
            return;
        }
        bool boolen = collider.gameObject.CompareTag("Player");
        if(!boolen)// if the gameobject is not player
        {
            bool isground = collider.gameObject.CompareTag(ground);
            if(!isground)// if the gameobject is not on the ground
            {
                Vector2 hitonenemy = collider.transform.position;
                GameObject particle = Instantiate(hiteffect,hitonenemy,Quaternion.identity);
                if(Random.Range(1,4) == 1)
                {
                    if(Random.Range(1,3) == 1)
                    {
                        GameObject spawed1=Instantiate(twox,hitonenemy,Quaternion.identity);
                        Destroy(spawed1,5f);
                    }
                    else{
                        GameObject spawed2=Instantiate(heart,hitonenemy,Quaternion.identity);
                        Destroy(spawed2,5f);
                    }
                }
                Destroy(collider.gameObject);
                Destroy(particle,3f);
            }
            Destroy(gameObject);
        }

       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementground : MonoBehaviour
{
    [SerializeField] private GameObject grounddestroyedpartiles;
    [SerializeField] private BoxCollider2D box2d;
    [SerializeField] private SpriteRenderer sprite2d;
    [SerializeField] private int dd;
    private bool caluate = false;
    private float player;
    private int limit = 5;
    private int smashes = 0;
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D collidier)
    {
        player = playermover.instance.transform.position.y - transform.position.y;
        if(collidier.CompareTag("Player") && caluate == false)
        {
            smashes++;
        }
        if(smashes >= limit && caluate == false)
        {
            box2d.enabled = false;
            sprite2d.enabled = false;
            GameObject p = Instantiate(grounddestroyedpartiles,transform.position,Quaternion.identity);
            Destroy(p,5f);
            caluate = true;
            smashes = 0;
        }
    }
    void Update()
    {
        if(caluate)
        {
            float distance = playermover.instance.transform.position.y - transform.position.y;
            if(distance < 0)
            {
                distance = -distance;
            }
            if(distance >= dd)
            {
                box2d.enabled = true;
                sprite2d.enabled = true;
                caluate = false;
            }
        }
    }
}

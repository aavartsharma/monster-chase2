using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redenemy : MonoBehaviour
{
    public playermover playerisdeid2;
    [SerializeField] private Transform playerPos;
    [SerializeField] private GameObject spritObject;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprit;
    [SerializeField] private float speed;
    [SerializeField] private float sideLeft; // +19
    [SerializeField] private float sideRight;// -19
    [SerializeField] private float thechascevalue;
    [SerializeField] private float themeshoff;
    [SerializeField] private float diedistance;
    [SerializeField] private string playerTag;
    void Start()
    {
        playerPos = GameObject.FindWithTag(playerTag).transform;
        
        playerisdeid2 = GameObject.FindWithTag(playerTag).GetComponent<playermover>();
    }
    void FixedUpdate()
    {
        if(playerisdeid2.Deid)
        {
            Destroy(gameObject);
        }
        float distance = playerPos.position.y - transform.position.y;// the distance from player in Y axis
        if(distance > diedistance || distance < -diedistance)// if the enemy is far away from the player
        {
            Destroy(gameObject);
        }
        if(distance > themeshoff || distance < -themeshoff)
        {
            spritObject.SetActive(false);
        }
        else
        {
            spritObject.SetActive(true);
        }
        Vector2 redposition = transform.position;
        if(redposition.x > sideLeft)//the enemy is face the left side
        {
            speed = -speed;
            sprit.flipX = true;
        }
        else if(redposition.x < sideRight)  //he is going to face the right side
        {
            speed = -speed;
            sprit.flipX = false;
        }
        redposition.x += speed * Time.deltaTime;
        transform.position = redposition;
    }
}

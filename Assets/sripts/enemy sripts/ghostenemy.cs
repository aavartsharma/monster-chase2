using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostenemy : MonoBehaviour
{
    public playermover playerisdeid3;
    [SerializeField] private Transform playerPos;
    [SerializeField] private GameObject ghostpartilce;
    [SerializeField] private Animator ghostanimation;
    [SerializeField] private SpriteRenderer sprit;
    [SerializeField] private string playerTag;
    [SerializeField] private string bullet;
    [SerializeField] private float distanceonblust;
    [SerializeField] private float speed;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float thechascevalue;
    [SerializeField] private float ditanceondistroy;
    private BoxCollider2D this_collider;
    private bool isdied = false;

    void Awake()
    {
        playerPos = GameObject.FindWithTag(playerTag).transform;
        playerisdeid3 = GameObject.FindWithTag(playerTag).GetComponent<playermover>();
        this_collider = GetComponent<BoxCollider2D>();
    }
    
    void FixedUpdate()
    {
        if(playerisdeid3.Deid)
        {
            Destroy(gameObject);
        }
        if(isdied)
        {
            return;
        }
        float distancetoplayer = Vector2.Distance(transform.position,playerPos.position);// the distance between player and ghost
        if(distancetoplayer > ditanceondistroy)// the ghost is far off
        {
            Destroy(gameObject);
        }
        if(distancetoplayer < distanceonblust)// the ghost is near to player
        {
            ghoostdied();
        }   

        if(distancetoplayer < thechascevalue) // when should the ghost chase the player
        {
            transform.position = Vector2.MoveTowards(transform.position,playerPos.position,speed * Time.deltaTime);
            return;
        }
        Vector2 ghostpos = transform.position;
        if(ghostpos.x > 19)//the enemy is face the left side
        {
            if(normalSpeed > 0)
            {
                normalSpeed = -normalSpeed;
            }
            sprit.flipX = true;
        }
        
        else if(ghostpos.x < -19)  //he is going to face the right side
        {
            if(normalSpeed < 0)
            {
                normalSpeed = -normalSpeed;
            }
            sprit.flipX = false;
        }
        ghostpos.x += normalSpeed * Time.deltaTime;
        transform.position = ghostpos;
    }

    // void OnCollisionEnter2D(Collision2D hits)
    // {
    //     if(hits.gameObject.CompareTag(bullet))
    //     {
    //         ghoostdied();
    //     }
    // }

    void ghoostdied()
    {
        isdied = true;
        ghostanimation.SetBool("dead",true);
        this_collider.enabled = false;
    }

    public void distroyghoost()
    {
        Destroy(gameObject);
    }

    public void partcils()
    {
        ghostpartilce.SetActive(true);
    }
}
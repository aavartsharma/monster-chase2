using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    [SerializeField] private GameObject[] tobeoffed;
    [SerializeField] private GameObject hittingeffect;
    [SerializeField] private float movementspeed;
    [SerializeField] private int distancetomeshoff;
    [SerializeField] private string playerstag;
    [SerializeField] private string phycalgroundTag;
    [SerializeField] private Vector3 diritiontothepoint;
    private Transform player;
    private playermover playerscript;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag(playerstag).transform;
        playerscript = GameObject.FindWithTag(playerstag).GetComponent<playermover>();
        Vector2 direcition = (player.position - transform.position).normalized;
        diritiontothepoint = direcition;
        transform.up = direcition;


        // if(playerscript.Deid)
        // {
        //     Destroy(gameObject);
        // }
        // transform.up = player.position - transform.position;
        // diritiontothepoint = (player.position - transform.position).normalized;
    }
    void FixedUpdate()
    {
        if(playerscript.Deid)
        {
            Destroy(gameObject);
        }
        rb.AddForce(transform.up * movementspeed * Time.fixedDeltaTime);
        // transform.position = Vector2.MoveTowards(transform.position,diritiontothepoint,movementspeed * Time.deltaTime);
        if(transform.position == diritiontothepoint)
        {
            GameObject s =Instantiate(hittingeffect,transform.position,Quaternion.identity);
            Destroy(s,4f);
            Destroy(gameObject);
        }
        
    }
    void Update()
    {
        float distanceY = player.position.y - transform.position.y;
        if(distanceY > distancetomeshoff || distanceY < -distancetomeshoff)
        {
            for(int i = 0; i < tobeoffed.Length;i++)
            {
                tobeoffed[i].SetActive(false);
            }
        }
        else
        {
            for(int i = 0; i < tobeoffed.Length;i++)
            {
                tobeoffed[i].SetActive(true);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player.gameObject || collision.gameObject.CompareTag(phycalgroundTag))
        {
            Instantiate(hittingeffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        Debug.Log(collision.gameObject);
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
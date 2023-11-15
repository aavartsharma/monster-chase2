using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenenemy : MonoBehaviour
{
    public playermover playerisdeid;
    private bool isdied;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject partiles;
    [SerializeField] private GameObject mesh;
    [SerializeField] private float distanceofparticlies;
    [SerializeField] private float distancefordestroy;
    [SerializeField] private string playerTag;
    void Awake()
    {
        player = GameObject.FindWithTag(playerTag).transform;
        playerisdeid = GameObject.FindWithTag(playerTag).GetComponent<playermover>();
    }
    void FixedUpdate()
    {
        if(playerisdeid.Deid)
        {
            Destroy(gameObject);
        }
        float distance = player.position.y - transform.position.y;
        if(distance > distanceofparticlies || distance < -distanceofparticlies)
        {
            OnBecameInvisible();
            if(distance > distancefordestroy || distance < -distancefordestroy)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            OnBecameVisible();
        }
    }
    void OnBecameVisible()
    {
        partiles.SetActive(true);
        mesh.SetActive(true);
    }

    void OnBecameInvisible()
    {
        partiles.SetActive(false);
        mesh.SetActive(false);
    }
}

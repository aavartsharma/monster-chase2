using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundscript : MonoBehaviour //name is not correctly name pls change it
{
    [SerializeField] private GameObject groundobject;// the ground prefab
    [SerializeField] private GameObject meshes;
    [SerializeField] private Transform playery; // player y position
    [SerializeField] private Vector3 gap; //the amount of gap between the grounds
    [SerializeField] private float cameraLength;
    private bool shouldbespwaned = true;
    
    
    void Update()
    {
        // checking for camera position if out of the range of the camera the mesh will be set to off 
        float distanceY = playery.position.y - transform.position.y;
        if(distanceY > cameraLength || distanceY < -cameraLength)
        {
            meshes.SetActive(false);
            Debug.Log("the ground2 has been set to off");
        }
        else
        {
            meshes.SetActive(true);
            Debug.Log("the ground2 has been set to on");
        }
    }

    GameObject SpawerNextGround() // where to spawn the next ground
    {
        Vector3 Pos = transform.position + gap;
        GameObject nextground = Instantiate(groundobject,Pos,transform.rotation);
        return nextground;
    }

    void OnTriggerEnter2D(Collider2D collision)// when to spawer the next ground
    {
        if(collision.gameObject.CompareTag("Player") && shouldbespwaned)
        {
            SpawerNextGround();
            shouldbespwaned = false;
        }

    }
}

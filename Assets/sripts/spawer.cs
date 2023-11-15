using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawer : MonoBehaviour
{
    [SerializeField] private GameObject groundobject;// the ground prefab
    [SerializeField] private GameObject meshes;// this gameObject mesh
    [SerializeField] private Transform playery; // player y position
    [SerializeField] private Vector3 gap; //the amount of gap between the grounds
    [SerializeField] private float cameraLength;// length of the camera
    private bool shouldbespwaned = true;

    void Update()
    {
        // checking for camera position if out of the range of the camera the mesh will be set to off 
        float distanceY = playery.position.y - transform.position.y;
        if(distanceY > cameraLength || distanceY < -cameraLength)
        {
            //meshes.SetActive(false);
        }
        else
        {
            meshes.SetActive(true);
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

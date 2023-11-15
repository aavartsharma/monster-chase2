using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camra : MonoBehaviour
{
    private Vector3 cam;
    [SerializeField] private Transform player;
    void LateUpdate()
    {
        cam = transform.position;
        cam.y= player.position.y;
        transform.position = cam;
    }
}

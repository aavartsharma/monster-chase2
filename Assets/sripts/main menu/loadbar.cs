using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadbar : MonoBehaviour
{
    [SerializeField] private GameObject loadingsceen;
    [SerializeField] private GameObject countgame;

    void Start()
    {
        loadingsceen.SetActive(true);
        Time.timeScale = 0f;
    }

    void offloadingscene()
    {
        Time.timeScale = 1f;
        loadingsceen.SetActive(false);
        countgame.SetActive(true);
    } 
}

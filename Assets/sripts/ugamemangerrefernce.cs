using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ugamemangerrefernce : MonoBehaviour
{
    private gamemanger manager;
    [SerializeField] private string managertag;

    void Awake()
    {
        manager = GameObject.FindWithTag(managertag).GetComponent<gamemanger>();;
    }

    public void loadGameload()
    {
        manager.loadgameplayscene();
    }

    public void mainmenuScene()
    {
        manager.loadmainmenuscene();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uianimations : MonoBehaviour
{
    [SerializeField] private GameObject ghost,re,b1,b2,opition;
    private Animator a;
    void Start()
    {
        a = GetComponent<Animator>();
    }
    void ghostoff()
    {
        ghost.SetActive(false);
        b1.SetActive(false);
    }

    void reoff()
    {
        re.SetActive(false);
        b2.SetActive(false);
    }

    void b1on()
    {
        b1.SetActive(true);
    }

    void b2on()
    {
        b2.SetActive(true);
    }
    void allon()
    {
        ghost.SetActive(true);
        //b1.SetActive(true);
        re.SetActive(true);
        //b2.SetActive(true);
    }

    public void on1()
    {
        a.SetInteger("state",1);
    }

    public void on2()
    {
        a.SetInteger("state",2);
    }

    public void on3()
    {
        a.SetInteger("state",3);
    }

    void opitionshower()
    {
        opition.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class counterimage : MonoBehaviour
{
    [SerializeField] private GameObject textgameobject;
    [SerializeField] private TextMeshProUGUI counttext;
    void textimagestart()
    {
        textgameobject.SetActive(true);
        counttext.text = "3";
        Time.timeScale = 0f;
    }

    void change2()
    {
        textgameobject.SetActive(false);
        textgameobject.SetActive(true);
        counttext.text = "2";
    }
    void change1()
    {
        textgameobject.SetActive(false);
        textgameobject.SetActive(true);
        counttext.text = "1";
    }
    void changeplay()
    {
        textgameobject.SetActive(false);
        textgameobject.SetActive(true);
        counttext.text = "Go";
    }


    void textimageend()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

}

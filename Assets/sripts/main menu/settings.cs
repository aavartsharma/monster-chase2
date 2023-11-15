using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class settings : MonoBehaviour
{
    [SerializeField] private Toggle bgtoggle;
    [SerializeField] private Slider soundslider;
    [SerializeField] private Toggle manualtoggle;
    [SerializeField] private Toggle buttontoggle;
    [SerializeField] private TMP_Dropdown diffcultyDD;
    float delay = 0;
    void Awake()
    {
        /*PlayerPrefs.SetInt("bgmusic",1); // this is a bool
        PlayerPrefs.SetInt("soundlevel",100);
        PlayerPrefs.SetInt("shootingway",1); // this a bool
        PlayerPrefs.SetInt("diffculty",1);
        PlayerPrefs.Save();*/
    }
    void Start()
    {
        bgtoggle.isOn = (PlayerPrefs.GetInt("bgmusic",1) != 0);
        soundslider.value = PlayerPrefs.GetInt("soundlevel",100);
        if((PlayerPrefs.GetInt("shootingway",1) == 0))
        {
            manualtoggle.isOn = true;
        }
        else{
            buttontoggle.isOn = true;
        }
        diffcultyDD.value = PlayerPrefs.GetInt("diffculty",1);
    }

    void Update()
    {
        /*bgtoggle.onValueChanged.AddListener(() =>{
            if(bgtoggle.isOn)
            {
                PlayerPrefs.SetInt("bgmusic",1);
            }
            else
            {
                PlayerPrefs.SetInt("bgmusic",0);
            }
        });

        soundslider.onValueChanged.AddListener(() =>{
            PlayerPrefs.SetInt("soundlevel",soundslider.value);
        });

        manualtoggle.onValueChanged.AddListener(() =>{
            if(manualtoggle.isOn)
            {
                PlayerPrefs.SetInt("shootingway",0);
            }
            else
            {
                PlayerPrefs.SetInt("bgmusic",1);
            }
        });

        diffcultyDD.onValueChanged.AddListener(() =>{
            set("diffculty",gettheindex());
        });*/

        if(Time.time >= delay)
        {
            int bgs = PlayerPrefs.GetInt("bgmusic",1);
            int soundss = PlayerPrefs.GetInt("soundlevel",100);
            int mt = PlayerPrefs.GetInt("shootingway",1);
            int DDD = PlayerPrefs.GetInt("diffculty",1);

            Debug.Log($"bg: {bgs} | sound: {soundss} | manual: {mt} | DDD: {DDD}");
            delay = Time.time + 10;
        }
    }

    public void forbgtoggle()
    {
        int a = bgtoggle.isOn ? 1:0;
        PlayerPrefs.SetInt("bgmusic",a);
        PlayerPrefs.Save();
    }

    public void forsoundslider()
    {
        set("soundlevel",(int)soundslider.value);
    }

    public void formanual(string name)
    {
        if(name =="b")
        {
            PlayerPrefs.SetInt("shootingway",1);
            Debug.Log("gta");
            PlayerPrefs.Save();
        }
        else if(name == "m")
        {
            PlayerPrefs.SetInt("shootingway",0);
            PlayerPrefs.Save();
        }
    }

    public void fordiffculty()
    {
        set("diffculty",gettheindex());
    }


    void set(string name,int number)
    {
        PlayerPrefs.SetInt(name,number);
        PlayerPrefs.Save();
    }

    int gettheindex()
    {
        if(diffcultyDD.options.Count > 0 && diffcultyDD.value >=0)
        {
            int index = diffcultyDD.value;
            return index;
        }
        return 0;
    }
}

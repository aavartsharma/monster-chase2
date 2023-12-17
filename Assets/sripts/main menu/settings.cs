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
    [SerializeField] private Button savebutton;
    [SerializeField] private Dictionary<string,string> settingdict = new Dictionary<string,string>();
    void Awake()
    {
        applythesetting();
        /*PlayerPrefs.SetString("bgmusic","1"); // this is a bool
        PlayerPrefs.SetString("soundlevel","100");
        PlayerPrefs.SetString("shootingway","b"); // this a bool
        PlayerPrefs.SetString("diffculty","Easy");
        PlayerPrefs.Save();*/
    }
    void Start()
    {
        savebutton.onClick.AddListener(() => {
            savethesitting();
        });
    }

    void applythesetting()
    {
        // for bgtoggle
        if(gamemanger.instance.settingList[0] == "0")
        {
            bgtoggle.isOn = false;
        }
        else
        {
            bgtoggle.isOn = true;
        }

        // for slider value
        soundslider.value = int.Parse(gamemanger.instance.settingList[1]);

        // for shooting check box

        if(gamemanger.instance.settingList[2] == "b")
        {
            buttontoggle.isOn = true;
        }
        else 
        {
            manualtoggle.isOn = true; 
        }

        // for diffculty
        string d = gamemanger.instance.settingList[3];
        int opitionIndex = diffcultyDD.options.FindIndex(option => option.text == d); 
        diffcultyDD.value = opitionIndex;
        

    }

    void savethesitting()
    {
        string buttonvalue = ""; 
        string shootingvalue = "";
        // for bg
        if(bgtoggle.isOn)
        {
            PlayerPrefs.SetString("bgmusic","1");
            audiomanager.instance.playthbg();
            buttonvalue = "1";
        }
        else
        {
            PlayerPrefs.SetString("bgmusic","0"); 
            audiomanager.instance.stopthebg();
            buttonvalue = "0";
        }
        
        // for music
        string soundsliderValue = ((int) soundslider.value).ToString();
        PlayerPrefs.SetString("soundlevel", soundsliderValue);

        // for shooting mothod
        if(manualtoggle.isOn)
        {
            PlayerPrefs.SetString("shootingway","m");
            shootingvalue = "m";
        }
        else if(buttontoggle.isOn)
        {
            PlayerPrefs.SetString("shootingway","b");
            shootingvalue = "b";
        }

        // for diffculty
        string d = diffcultyDD.captionText.text;
        PlayerPrefs.SetString("diffculty",d);

        // changing the value of the setting list in the gamemanager
        gamemanger.instance.settingList = new List<string>{buttonvalue,soundsliderValue,shootingvalue,d};

        // making a dict of the settings
        settingdict = showsetttings();
        foreach(var item in settingdict)
        {
            Debug.Log(item);
        }
        
    }

    Dictionary<string,string> showsetttings()
    {
        settingdict.Clear();
        string bg = PlayerPrefs.GetString("bgmusic","1").ToString();
        string sl = PlayerPrefs.GetString("soundlevel","100").ToString();
        string sw = PlayerPrefs.GetString("shootingway","b").ToString();
        string dc = PlayerPrefs.GetString("diffculty","easy").ToString();
        settingdict.Add("bgmusic",bg);
        settingdict.Add("soundlevel",sl);
        settingdict.Add("shootingway",sw);
        settingdict.Add("diffculty",dc);
        return settingdict;
    }
}

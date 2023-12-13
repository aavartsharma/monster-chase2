using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanger : MonoBehaviour
{
    public static bool ispaused = false;
    public static gamemanger instance;
    public List<string> settingList;
    public string player1;
    public int Gvolume;
    public bool shootingtype;
    public string diffculty;
    public bool panthersoldout;
    [SerializeField] private string gameplayScene;
    [SerializeField] private string mainmenuScene;
    [SerializeField] private string totutoralScene;
    [SerializeField] private string shopScene;
    [SerializeField] private string settingsScene;
    [SerializeField] private string manualScene;
    [SerializeField] private string asianScene;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        player1 = PlayerPrefs.GetString("currentplayer","garo");
        panthersoldout = (PlayerPrefs.GetInt("panthersoldout",0) != 0);
        string str1 = PlayerPrefs.GetString("bgmusic","1"); // this is a bool
        string str2 = PlayerPrefs.GetString("soundlevel","100");
        string str3 = PlayerPrefs.GetString("shootingway","b"); // this a bool
        string str4 = PlayerPrefs.GetString("diffculty","Easy");
        settingList = new List<string>();
        settingList.Add(str1);
        settingList.Add(str2);
        settingList.Add(str3);
        settingList.Add(str4);

        foreach(var i in settingList)
        {
            Debug.Log(i);
        }
    }

    public void loadgamemainmenu()
    {
        int timesgameopened = PlayerPrefs.GetInt("gameopened",0);
        if(timesgameopened == 0)
        {
            loadtoturalscene();
            PlayerPrefs.SetInt("gameopend",timesgameopened+1);
        }
        else
        {
            loadgameplayscene();
            PlayerPrefs.SetInt("gameopend",timesgameopened+1);
        }
        PlayerPrefs.Save();
    }// error

    public void gamestartbutton()
    {
        int isfirsttime = PlayerPrefs.GetInt("newplayer",0);
        Debug.Log($"newplayer value - {isfirsttime}");
        if(isfirsttime == 0)
        {
            PlayerPrefs.SetInt("newplayer",1);
            PlayerPrefs.Save();
            loadtoturalscene();
        }
        else
        {
            Debug.Log($"newplayer value - {isfirsttime}");
            loadgameplayscene();
        }
    }

    public void loadgameplayscene()
    {
        // audiomanager.instance.GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        if(settingList[3] == "Asian") // for diffculty
        {
            SceneManager.LoadScene(asianScene);
        }
        else
        {
            SceneManager.LoadScene(gameplayScene);
        }
        
    }

    public void pause()
    {
        Time.timeScale = 0f;
        ispaused = true;
    }

    public void resume()
    {
        Time.timeScale = 1f;
        ispaused = false;
    }

    public void loadmainmenuscene()
    {
        if(settingList[0] == "1") // the bg
        {
            audiomanager.instance.GetComponent<AudioSource>().Play();
        }
        // audiomanager.instance.GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainmenuScene);
    }

    public void loadtoturalscene()
    {
        audiomanager.instance.GetComponent<AudioSource>().Stop();
        Time.timeScale = 1f;
        SceneManager.LoadScene(totutoralScene);
    }

    public void loadshop()
    {
        SceneManager.LoadScene(shopScene);
    }

    public void loadsettings()
    {
        SceneManager.LoadScene(settingsScene);
    }

    public void loadmanual()
    {
        SceneManager.LoadScene(manualScene);
    }

    public void quitthegame()
    {
        Application.Quit();
    }

    

}

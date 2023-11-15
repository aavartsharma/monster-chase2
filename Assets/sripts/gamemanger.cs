using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanger : MonoBehaviour
{
    public static bool ispaused = false;
    public static gamemanger instance;
    public string player1;
    public bool panthersoldout;
    [SerializeField] private string gameplayScene;
    [SerializeField] private string mainmenuScene;
    [SerializeField] private string totutoralScene;
    [SerializeField] private string shopScene;
    [SerializeField] private string settingsScene;
    [SerializeField] private string manualScene;

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
    }


    public void loadgameplayscene()
    {
        audiomanager.instance.GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameplayScene);
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
        audiomanager.instance.GetComponent<AudioSource>().Play();
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

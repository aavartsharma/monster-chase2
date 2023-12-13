using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getreffernce : MonoBehaviour
{
    
    public void onbuttonpressed(string soundname)
    {
        audiomanager.instance.play(soundname);
    }

    public void onbuttonpressedoff(string soundname)
    {
        audiomanager.instance.stop(soundname);
    }

    public void onbuttonpressedpause(string soundname)
    {
        audiomanager.instance.pause(soundname);
    }

    public void onbuttonpressedresume(string soundname)
    {
        audiomanager.instance.resume(soundname);
    }

    public void mainmaenu()
    {
        gamemanger.instance.loadmainmenuscene();
    }

    public void gameon()
    {
        gamemanger.instance.loadgameplayscene();
    }

    public void startMMbutton()
    {
        gamemanger.instance.gamestartbutton();
    }

    public void toturialr()
    {
        gamemanger.instance.loadtoturalscene();
    }

    public void shop()
    {
        gamemanger.instance.loadshop();
    }

    public void sitting()
    {
        gamemanger.instance.loadsettings();
    }

    public void manual()
    {
        gamemanger.instance.loadmanual();
    }

    public void indirectpause()
    {
        gamemanger.instance.pause();
    }

    public void indirectresume()
    {
        gamemanger.instance.resume();
    }

    public void Quit()
    {
        gamemanger.instance.quitthegame();
    }
}

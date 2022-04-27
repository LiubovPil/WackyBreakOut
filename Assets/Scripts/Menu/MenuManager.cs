using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager 
{
    private static bool _pauseOnLoad = false;

    static public bool PauseOnLoad
    {
        get { return _pauseOnLoad; }
        set { _pauseOnLoad = value; }
    }
    public static void GoTomenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Main:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.About:
                SceneManager.LoadScene("AboutMenu");
                break;
            case MenuName.Pause:
                Object.Instantiate(Resources.Load("PauseMenu"));
                PauseOnLoad = true;
                break;
        }
    }
}

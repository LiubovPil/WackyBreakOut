using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 0;
    }
    public void ResumeButtonOnclick()
    {
        Time.timeScale = 1;

        AudioManager.Playing(AudioClipName.MenuButtonClick);

        MenuManager.PauseOnLoad = false;
        Destroy(gameObject);
    }
    public void ExitButtonOnclick()
    {
        Time.timeScale = 1;

        AudioManager.Playing(AudioClipName.MenuButtonClick);

        Destroy(gameObject); //swap 
        MenuManager.PauseOnLoad = false;
        MenuManager.GoTomenu(MenuName.Main);
    }
}

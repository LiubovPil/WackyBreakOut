using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonOnclick()
    {
        AudioManager.Playing(AudioClipName.MenuButtonClick);
        SceneManager.LoadScene("GamePlay");
    }
    public void ExitButtonOnclick()
    {
        AudioManager.Playing(AudioClipName.MenuButtonClick);
        Application.Quit();
    }
    public void AboutButtonOnclick()
    {
        AudioManager.Playing(AudioClipName.MenuButtonClick);
        MenuManager.GoTomenu(MenuName.About);
    }
}

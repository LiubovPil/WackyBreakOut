using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutMenu : MonoBehaviour
{
    public void PlayButtonOnClick()
    {
        AudioManager.Playing(AudioClipName.MenuButtonClick);
        MenuManager.GoTomenu(MenuName.Main);
    }
}

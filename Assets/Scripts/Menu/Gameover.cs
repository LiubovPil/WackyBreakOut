using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    [SerializeField] private Text _GameOverText;
    public void Start()
    {
        Time.timeScale = 0;
    }
    public void SetScore(float score)
    {
        _GameOverText.text = "Game Over!\n\nScore: " + score;//\n = new line
    }
    public void ExitButtonOnclick()
    {
        Time.timeScale = 1;

        AudioManager.Playing(AudioClipName.MenuButtonClick);

        Destroy(gameObject);
        MenuManager.GoTomenu(MenuName.Main);
    }
}

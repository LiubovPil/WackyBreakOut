using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WackyBreakoutPause : MonoBehaviour
{
    private GameObject _hud;
    private HUD _hudScript;

    private GameObject _gameOverMessage;

    private void Start()
    {
        _hud = GameObject.FindGameObjectWithTag("hud");
        _hudScript = _hud.GetComponent<HUD>();

        EventManager.AddHudListener(LastBall);
        EventManager.AddBlockDestoyListener(LastBlockDestroyed);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!MenuManager.PauseOnLoad)
            {
                MenuManager.GoTomenu(MenuName.Pause);
            }
        }
    }
    private void LastBlockDestroyed()
    {
        if (GameObject.FindGameObjectsWithTag("block").Length == 1)
        {
            LastBall();
        }
    }
    private void LastBall()
    {
        if (!MenuManager.PauseOnLoad)
            AudioManager.Playing(AudioClipName.GameLost);

        _gameOverMessage = Instantiate(Resources.Load("GameOverMessage")) as GameObject;
        Gameover gameOverScript = _gameOverMessage.GetComponent<Gameover>();
        gameOverScript.SetScore(_hudScript.ScoreValue);
    }
}

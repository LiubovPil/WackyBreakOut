using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HUD : MonoBehaviour
{
    #region Fields
    private Text _textScore;
    private const string _scorePrefix = "Score: ";
    private float _score = 0f;
    
    private Text _ballLeft;
    private const string _ballLeftPrefix = "Ball Left: ";
    private float _ballLeftNum;
    
    private LastBallEvent _ballEvent;
    #endregion
    public float ScoreValue
    {
        get { return _score; }
    }
    private void Start()
    {
        _textScore = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        _textScore.text = _scorePrefix + _score.ToString();

        _ballLeftNum = ConfigurationUtils.BallLeft;
        _ballLeft = GameObject.FindGameObjectWithTag("ballleft").GetComponent<Text>();
        _ballLeft.text = _ballLeftPrefix + _ballLeftNum.ToString();

        EventManager.AddListenerBlock(Score);
        EventManager.AddListenerBall(BallLeft);

        _ballEvent = new LastBallEvent();
        EventManager.AddHudInvoker(this);
    }
    private void Score(float scoreValue)
    {
        _score += scoreValue;
        _textScore.text = _scorePrefix + _score.ToString();
    }
    private void BallLeft()
    {
        _ballLeftNum--;
        _ballLeft.text = _ballLeftPrefix + _ballLeftNum.ToString();
        if (_ballLeftNum == 0)
        { 
            _ballEvent.Invoke();
        }
    }
    public void AddHUDListener(UnityAction listener)
    {
        _ballEvent.AddListener(listener);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    #region Fields
    //supporting for adding force
    private Rigidbody2D _rb2D;
    private float _angle = -90 * Mathf.Deg2Rad;

    //support for game timing
    private Timer _ballTime;

    //support for ball spawning
    private BallSpawnerEvent _ballSpawner;

    //supporting for nomoving after start, in the original it is timer
    private int _coolDown = 1;
    private float _freezenTime = 0f;
    private bool _noMoving = true;

    //support for speedup
    private Timer _speedUpTime;
    private bool _speedUpControl = false;
    private float _speedUpValue;

    private BallChangeEvent _ballChange;
    #endregion
    private void Start()
    {
        //support for spawn ball
        _ballTime = GetComponent<Timer>();
        _ballTime.Duration = ConfigurationUtils.BallLifetime;
        _ballTime.AddTimerFinishedEffectListener(BallTimeFinished);
        _ballTime.Run();

        _ballSpawner = new BallSpawnerEvent(); //see below AddBallSpawnEffectListener
        EventManager.AddInvokerBallSpawn(this);

        _rb2D = GetComponent<Rigidbody2D>();

        //support fot speedup effect
        _speedUpTime = GetComponent<Timer>();
        EventManager.AddListenerSpeedup(SpeedupEffectActivated);
        _speedUpTime.AddTimerFinishedEffectListener(SpeedupTimeFinished);

        //support for ball change
        _ballChange = new BallChangeEvent();
        EventManager.AddInvokerBall(this);
    }
    private void Update()
    {
        if (_noMoving)
        {
            _freezenTime += Time.deltaTime; //can be optimize with corotine
            if (_freezenTime >= _coolDown)
            {
                _noMoving = false;
                StartMoving();
            }
        }
    }
    private void StartMoving()
    {
        Vector2 posStart = new Vector2(Mathf.Cos(_angle), Mathf.Sin(_angle));

        if (EffectUtils.SpeedUpRunning) //checkinf if the speedup effect is currently active
        {
            _speedUpControl = true;

            this._speedUpValue = EffectUtils.SpeedUpFactor;
            posStart *= EffectUtils.SpeedUpFactor;

            _speedUpTime.Duration = EffectUtils.SpeedUpLeft;
            _speedUpTime.Run();
        }
        _rb2D.AddForce(posStart * ConfigurationUtils.BallImpulseForce);
    }
    private void OnBecameInvisible() //!work correctly if turn on "MaximizeOnPlay"
    {
        if (_ballTime.Running)
        {
            if (transform.position.y < ScreenUtils.ScreenBottom)
            {
                _ballTime.Stop(); //not necessary as object will be destroied below
                _ballSpawner.Invoke();
                _ballChange.Invoke();

                _noMoving = true; //not necessary as object will be destroied below

                AudioManager.Playing(AudioClipName.BallLost);
            }
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("ball") ||
            coll.gameObject.CompareTag("block") ||
            coll.gameObject.CompareTag("racket"))
        {
            AudioManager.Playing(AudioClipName.BallSpawn);
        }
    }
    private void BallTimeFinished()
    {
        if (!_noMoving)
        {
            _ballSpawner.Invoke();
            Destroy(this.gameObject);

            _freezenTime = 0;
        }
    }
    private void SpeedupTimeFinished()
    {
        if (_speedUpControl)
        {
            Time.timeScale = 1;
            this._rb2D.velocity *= (1 / _speedUpValue);
            _speedUpControl = false;
        }
    }
    private void SpeedupEffectActivated(float speedupDuration, float speedupfactor)
    {
        if (!_speedUpControl)
        {
            _speedUpControl = true;

            this._speedUpValue = speedupfactor;
            _rb2D.velocity *= speedupfactor;

            _speedUpTime.Duration = speedupDuration;
            _speedUpTime.Run();
        }
        else
        {
            _speedUpTime.Duration = speedupDuration; //if the effect is applied, then start the timer again
        }
    }
    public void SetDirection(Vector2 direction)
    {
        float speed = _rb2D.velocity.magnitude;
        _rb2D.velocity = direction * speed;
    }
    public void AddBallChangeEffectListener(UnityAction listener)
    {
        _ballChange.AddListener(listener);
    }
    public void AddBallSpawnEffectListener(UnityAction listener)
    {
        _ballSpawner.AddListener(listener);
    }
}

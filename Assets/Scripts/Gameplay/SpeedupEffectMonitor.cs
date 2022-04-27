using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour
{
    private Timer _speedUpDuration;
    private float _speedUpFactor;

    #region Properties
    public float SpeedUpFactor
    {
        get { return _speedUpFactor; }
    }
    public bool SpeedUpRunning
    {
        get { return _speedUpDuration.Running; }
    }
    public float SpeedUpLeft
    {
        get { return _speedUpDuration.TimeLeft; }
    }
    #endregion
    private void Start()
    {
        _speedUpDuration = gameObject.AddComponent<Timer>();
        EventManager.AddListenerSpeedup(SpeedupEffectHandle);
        _speedUpDuration.AddTimerFinishedEffectListener(SpeedupDurationFinished);
    }
    private void SpeedupEffectHandle(float duration, float factor)
    {
        if (!_speedUpDuration.Running)
        {
            this._speedUpFactor = factor;

            _speedUpDuration.Duration = duration;
            _speedUpDuration.Run();
        }
        else
        {
            _speedUpDuration.Duration = duration;
        }
    }
    private void SpeedupDurationFinished()
    {
        _speedUpDuration.Stop();
        _speedUpFactor = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
	#region Fields
	// timer duration
	private float _totalSeconds = 0f;

	// timer execution
	private bool running = false;
	private float _elapsedSeconds = 0f;

	// support for Finished property
	private bool started = false;

	private TimerFinishedEvent timerFinished = new TimerFinishedEvent();
	#endregion

	#region Properties

	/// <summary>
	/// Sets the duration of the timer
	/// </summary>
	/// <value>duration</value>
	public float Duration
	{
		set
		{
			if (!running)
			{
				_totalSeconds = value;
			}
			if (running)
            {
				_totalSeconds = _elapsedSeconds + value;
			}
		}
	}
	/// <summary>
	/// Gets the time left
	/// </summary>
	/// <value>duration</value>
	public float TimeLeft
	{
		get 
		{
			if (running)
			{
				return _totalSeconds - _elapsedSeconds;
			}
			else
				return 0;
		}
	}
	/// <summary>
	/// Gets whether or not the timer has finished running
	/// This property returns false if the timer has never been started
	/// </summary>
	/// <value>true if finished; otherwise, false.</value>
	public bool Finished
	{
		get {	return started && !running; }
	}
	/// <summary>
	/// Gets whether or not the timer is currently running
	/// </summary>
	/// <value>true if running; otherwise, false.</value>
	public bool Running
	{
		get { return running; }
	}
	#endregion

	#region Methods
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		// update timer and check for finished
		if (running)
		{
			_elapsedSeconds += Time.deltaTime;
			if (_elapsedSeconds >= _totalSeconds)
			{
				running = false;
				timerFinished.Invoke();
			}
		}
	}
	/// <summary>
	/// Runs the timer
	/// Because a timer of 0 duration doesn't really make sense,
	/// the timer only runs if the total seconds is larger than 0
	/// This also makes sure the consumer of the class has actually 
	/// set the duration to something higher than 0
	/// </summary>
	public void Run()
	{
		// only run with valid duration
		if (_totalSeconds > 0)
		{
			started = true;
			running = true;
			_elapsedSeconds = 0;
		}
	}
    public void Stop()
    {
		started = false;
		running = false;
	}
	public void AddTimerFinishedEffectListener(UnityAction listener)
	{
		timerFinished.AddListener(listener);
	}
	#endregion
}

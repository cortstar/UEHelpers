using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Timer object which can be checked for completeness.
/// The instantiating class will have to force-update this timer.
/// </summary>
public class Timer {
    private bool _paused = false;

    public float RemainingTime { get; private set; }
    public float StartingTime { get; private set; }

    private bool _isComplete = false; 
    public bool IsComplete { get { return _isComplete; } private set { _isComplete = value; } }

    private readonly List<Action> TimerEndCallbackActions = new List<Action>();

    public Timer(float time)
    {
        RemainingTime = time;
        StartingTime = time;
    }

    public void Pause()
    {
        this._paused = true;
    }

    public void Unpause()
    {
        this._paused = false;
    }

    public void Reset()
    {
        IsComplete = false;
        _paused = false;
        RemainingTime = StartingTime;
    }
	
	// Update is called once per frame
	public void Update ()
    {
        if (_paused || IsComplete) return;
        
        RemainingTime -= Time.fixedDeltaTime;
        
        if (!(RemainingTime <= 0f)) return;
        
        this._paused = true;
        this.IsComplete = true;
                
        TimerEndCallbackActions.ForEach(c => c());
    }

    public void RegisterTimerCallback(Action callback)
    {
        TimerEndCallbackActions.Add(callback);
    }
}

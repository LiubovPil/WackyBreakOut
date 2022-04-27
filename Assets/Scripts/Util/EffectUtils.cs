using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{
    private static SpeedupEffectMonitor _speedUpEffectMonitor;

    public static float SpeedUpFactor
    {
        get { return SpeedupInitialize().SpeedUpFactor; }
    }
    public static float SpeedUpLeft
    {
        get { return SpeedupInitialize().SpeedUpLeft; }
    }
    public static bool SpeedUpRunning
    {
        get { return SpeedupInitialize().SpeedUpRunning; }
    }
    static SpeedupEffectMonitor SpeedupInitialize()
    {
        return _speedUpEffectMonitor = Camera.main.GetComponent<SpeedupEffectMonitor>();
    }
}

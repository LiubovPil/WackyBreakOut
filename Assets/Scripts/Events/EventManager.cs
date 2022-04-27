using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    private static List<PickupBlock> _invokerFreezen = new List<PickupBlock>();
    private static List<UnityAction<float>> _listenerFreezen = new List<UnityAction<float>>();

    private static List<PickupBlock> _invokerSpeedUp = new List<PickupBlock>();
    private static List<UnityAction<float,float>> _listenerSpeedUp = new List<UnityAction<float,float>>();

    private static List<Block> _invokerBlock = new List<Block>();
    private static List<UnityAction<float>> _listenerBlock = new List<UnityAction<float>>();

    private static List<Ball> _invokerBall = new List<Ball>();
    private static List<UnityAction> _listenerBall = new List<UnityAction>();

    private static List<Ball> _invokerBallSpawn = new List<Ball>();
    private static List<UnityAction> _listenerBallSpawn = new List<UnityAction>();

    private static HUD _invokerHud;
    private static UnityAction _listenerHud;

    private static List<Block> _invokerBlockDestroy = new List<Block>();
    private static List<UnityAction> _listenerBlockDestroy = new List<UnityAction>();

    public static void AddInvokerFreezen(PickupBlock invoker)
    {
        _invokerFreezen.Add(invoker);
        foreach (UnityAction<float> listener in _listenerFreezen)
        {
            invoker.AddFreezenEffectListener(listener);
        }
    }
    public static void AddListenerFreezen(UnityAction<float> listener)
    {
        _listenerFreezen.Add(listener);
        foreach (PickupBlock invoker in _invokerFreezen)
        {
            invoker.AddFreezenEffectListener(listener);
        }
    }
    public static void AddInvokerSpeedup(PickupBlock invoker)
    {
        _invokerSpeedUp.Add(invoker);
        foreach (UnityAction<float,float> listener in _listenerSpeedUp)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }
    public static void AddListenerSpeedup(UnityAction<float,float> listener)
    {
        _listenerSpeedUp.Add(listener);
        foreach (PickupBlock invoker in _invokerSpeedUp)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }
    public static void AddInvokerBlock(Block invoker)
    {
        _invokerBlock.Add(invoker);
        foreach (UnityAction<float> listener in _listenerBlock)
        {
            invoker.AddScoreChangeEffectListener(listener);
        }
    }
    public static void AddListenerBlock(UnityAction<float> listener)
    {
        _listenerBlock.Add(listener);
        foreach (Block invoker in _invokerBlock)
        {
            invoker.AddScoreChangeEffectListener(listener);
        }
    }
    public static void AddInvokerBall(Ball invoker)
    {
        _invokerBall.Add(invoker);
        foreach (UnityAction listener in _listenerBall)
        {
            invoker.AddBallChangeEffectListener(listener);
        }
    }
    public static void AddListenerBall(UnityAction listener)
    {
        _listenerBall.Add(listener);
        foreach (Ball invoker in _invokerBall)
        {
            invoker.AddBallChangeEffectListener(listener);
        }
    }
    public static void AddInvokerBallSpawn(Ball invoker)
    {
        _invokerBallSpawn.Add(invoker);
        foreach (UnityAction listener in _listenerBallSpawn)
        {
            invoker.AddBallSpawnEffectListener(listener);
        }
    }
    public static void AddListenerBallSpawn(UnityAction listener)
    {
        _listenerBallSpawn.Add(listener);
        foreach (Ball invoker in _invokerBallSpawn)
        {
            invoker.AddBallSpawnEffectListener(listener);
        }
    }
    public static void AddHudInvoker(HUD invoker)
    {
        _invokerHud = invoker;
        if (_listenerHud != null)
        {
            _invokerHud.AddHUDListener(_listenerHud);
        }
    }
    public static void AddHudListener(UnityAction listener)
    {
        _listenerHud = listener;
        if (_invokerHud != null)
        {
            _invokerHud.AddHUDListener(_listenerHud);
        }
    }
    public static void AddBlockDestoyInvoker(Block invoker)
    {
        _invokerBlockDestroy.Add(invoker);
        foreach (UnityAction listener in _listenerBlockDestroy)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }
    public static void AddBlockDestoyListener(UnityAction listener)
    {
        _listenerBlockDestroy.Add(listener);
        foreach (Block invoker in _invokerBlockDestroy)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }
}

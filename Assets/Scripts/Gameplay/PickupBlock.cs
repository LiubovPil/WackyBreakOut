using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block
{
    #region Fields
    //sprites for blocks
    [SerializeField] private Sprite _speedBlock;
    [SerializeField] private Sprite _freezenBlock;

    private float _effectDuration;
    private float _speedUpFactor;

    private PickupEffect effect;

    //support for freezen
    private FreezenEffectedActivated _freezenEvent;

    //Support for speedup
    private SpeedupEffectsActivated _speedUpEvent;
    #endregion
    override protected void Start()
    {
        score = ConfigurationUtils.PickupPoint;
        base.Start();
    }
    public PickupEffect Effect
    {
        set
        {
            effect = value;

            // set sprite according to the effect
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (effect == PickupEffect.Freezer)
            {
                spriteRenderer.sprite = _freezenBlock;
                _effectDuration = ConfigurationUtils.FreezenTime;
                _freezenEvent = new FreezenEffectedActivated();
                EventManager.AddInvokerFreezen(this);
            }
            else
            {
                spriteRenderer.sprite = _speedBlock;
                _effectDuration = ConfigurationUtils.SpeedupTime;
                _speedUpFactor = ConfigurationUtils.SpeedupFactor;
                _speedUpEvent = new SpeedupEffectsActivated();
                EventManager.AddInvokerSpeedup(this);
            }
        }
    }
    public void AddFreezenEffectListener(UnityAction<float> listener)
    {
        _freezenEvent.AddListener(listener);
    }
    public void AddSpeedupEffectListener(UnityAction<float,float> listener)
    {
        _speedUpEvent.AddListener(listener);
    }
    override protected void OnCollisionEnter2D(Collision2D coll) //sets the effect depending on which pickup block was destroyed
    {
        if (effect == PickupEffect.Freezer)
        {
            _freezenEvent.Invoke(_effectDuration);
        }
        else if (effect == PickupEffect.Speedup)
        {
            _speedUpEvent.Invoke(_effectDuration, _speedUpFactor);
        }
        base.OnCollisionEnter2D(coll);
    }
}

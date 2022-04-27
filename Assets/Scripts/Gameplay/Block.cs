using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Parent class for all kinds of blocks
/// </summary>
public class Block : MonoBehaviour
{
    private ScoreChangeEvent _scoreChange;

    private BlockDestroyed _blockDestroy;

    protected float score;

    virtual protected void Start()
    {
        _scoreChange = new ScoreChangeEvent();
        _blockDestroy = new BlockDestroyed();

        EventManager.AddInvokerBlock(this);
        EventManager.AddBlockDestoyInvoker(this);
    }
    virtual protected void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("ball"))
        {
            _scoreChange.Invoke(score);
            Destroy(this.gameObject);
            _blockDestroy.Invoke();
        }
    }
    public void AddScoreChangeEffectListener(UnityAction<float> listener)
    {
        _scoreChange.AddListener(listener);
    }
    public void AddBlockDestroyedListener(UnityAction listener) 
    {
        _blockDestroy.AddListener(listener);
    }
}

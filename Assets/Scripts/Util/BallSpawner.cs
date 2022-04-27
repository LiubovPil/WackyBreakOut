using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    #region
    [SerializeField] private GameObject _ballPrefab;

    private Timer _spawnTimer;
    private float _minTimeSpawn;
    private float _maxTimeSpawn;

    private Vector2 _spawnLocationMin;
    private Vector2 _spawnLocationMax;

    private bool _retrySpawn = false;
    #endregion
    private void Start()
    {
        GameObject tempBall = Instantiate(_ballPrefab);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        _spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        _spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);

        _minTimeSpawn = ConfigurationUtils.MinBallSpawn;
        _maxTimeSpawn = ConfigurationUtils.MaxBallSpawn;

        _spawnTimer = gameObject.AddComponent<Timer>(); //timer of spawn, ball have own timer
        _spawnTimer.Duration = Random.Range(_minTimeSpawn,_maxTimeSpawn);
        _spawnTimer.AddTimerFinishedEffectListener(BallSpawnFinished);
        _spawnTimer.Run();

        EventManager.AddListenerBallSpawn(BallSpawn);
        BallSpawn();
    }
    private void Update()
    {
        if (_retrySpawn)
        {
            BallSpawn();
        }
    }
    private void BallSpawn() //in case ball was destroyed, but timer still run 
    {
        if (Physics2D.OverlapArea(_spawnLocationMin, _spawnLocationMax) == null)
        {
            _retrySpawn = false;
            Instantiate(_ballPrefab);
            AudioManager.Playing(AudioClipName.BallSpawn);
        }
        else
        {
            _retrySpawn = true;
        }
    }
    private void BallSpawnFinished() //in case timer finished 
    {
        _retrySpawn = false; 
        BallSpawn();
        _spawnTimer.Duration = Random.Range(_minTimeSpawn, _maxTimeSpawn);
        _spawnTimer.Run();
    }
}

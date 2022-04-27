using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Paddle management
/// </summary>
public class Paddle : MonoBehaviour
{
    #region Fields
    //support fot moving
    private Rigidbody2D _rb2d;
    private Vector2 _input;

    //support for size of the paddle
    private BoxCollider2D _box;
    private Vector2 _size;
    private float _halfWidth;

    private float _bounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    //support for freezen effect
    private Timer freezenTime;
    private bool freezen = false;
    #endregion
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();

        _box = GetComponent<BoxCollider2D>();
        _size = _box.size;
        _halfWidth = _size.x / 2;
        //height = size.y / 2;

        freezenTime = gameObject.AddComponent<Timer>();
        EventManager.AddListenerFreezen(FreezenEffectActivated);
        freezenTime.AddTimerFinishedEffectListener(TimerFinished);
    }
    private void FixedUpdate()
    {
        if (!freezen)
        {
            _input = new Vector2(Input.GetAxis("Horizontal"), 0);

            float x = CalculateClampedX(_input.x); //clamps the paddle within the screen
            _input.x = x;

            if (Input.GetAxis("Horizontal") != 0)
            {
                _rb2d.MovePosition(_rb2d.position + _input * Time.deltaTime * ConfigurationUtils.PaddleMoveUnitsPerSecond);
            }
        }
    }
    private float CalculateClampedX(float x)
    {
        float posX = _rb2d.position.x;
        if (((posX < ScreenUtils.ScreenLeft + _halfWidth) && (x < 0)) || ((posX > ScreenUtils.ScreenRight - _halfWidth) && (x > 0)))
        {
            x = 0;
        }
        return x;
    }
    private void OnCollisionEnter2D(Collision2D coll) // this method was provided on the course (by Dr. Tim "Dr. T" Chamillard)
    {
            // calculate new ball direction
            if (coll.gameObject.CompareTag("ball") &&
            DetectedCollision(coll))
            {
                float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
                float normalizedBallOffset = ballOffsetFromPaddleCenter /
                    _halfWidth;
                float angleOffset = normalizedBallOffset * _bounceAngleHalfRange;
                float angle = Mathf.PI / 2 + angleOffset;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                // tell ball to set direction to new direction
                Ball ballScript = coll.gameObject.GetComponent<Ball>();
                ballScript.SetDirection(direction);
            }
    }
    private bool DetectedCollision(Collision2D coll) // this method was provided on the course (by Dr. Tim "Dr. T" Chamillard)
    {
        const float tolerance = 0.05f;

        // on top collisions, both contact points are at the same y location
        ContactPoint2D contact1 = coll.GetContact(0);
        ContactPoint2D contact2 = coll.GetContact(1);
        return Mathf.Abs(contact1.point.y - contact2.point.y) < tolerance;
    }
    private void FreezenEffectActivated(float value)
    {
        if (!freezen)
        {
            freezen = true;

            freezenTime.Duration = value;
            freezenTime.Run();
        }
        else
        {
            freezenTime.Duration = value;
        }
    }
    private void TimerFinished()
    {
        freezen = false;
    }
}

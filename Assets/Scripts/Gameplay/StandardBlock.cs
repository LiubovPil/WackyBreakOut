using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    #region Fields
    [SerializeField] private Sprite _orangeblock;
    [SerializeField] private Sprite _purpleblock;
    [SerializeField] private Sprite _greenblock;

    private SpriteRenderer _currentSprite;
    #endregion
    override protected void Start()
    {
        score = ConfigurationUtils.BlockPoints;
        int sprite = Random.Range(0, 3);

        _currentSprite = GetComponent<SpriteRenderer>(); //sprite selection

        if (sprite == 0)
        {
            _currentSprite.sprite = _orangeblock;
        }
        else if (sprite == 1)
        {
            _currentSprite.sprite = _purpleblock;
        }
        else
        {
            _currentSprite.sprite = _greenblock;
        }
        base.Start();
    }

}

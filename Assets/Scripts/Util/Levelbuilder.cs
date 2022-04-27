using UnityEngine;

public class Levelbuilder : MonoBehaviour
{
    #region Fields
    [Header("The paddle")]
    [SerializeField] private GameObject _racket;
    [Header("The blocks")]
    [SerializeField] private GameObject _standardBlock;
    [SerializeField] private GameObject _bonusBlock;
    [SerializeField] private GameObject _pickUpBlock;
    
    private PickupBlock _currentScript;
    private GameObject _currentBlock;

    private float _blockColliderWidth;
    private float _blockColliderHeight;

    private float _screenHeight;
    private float _screenWidth;

    private int _blockNum;

    private Vector2 currentPosition;

    private float _startPositionX;
    private float _startPositionY;
    #endregion
    void Start()
    {
        Instantiate(_racket);

        _screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        _screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;

        GameObject tempblock = Instantiate(_standardBlock);
        BoxCollider2D collider = tempblock.GetComponent<BoxCollider2D>();
        _blockColliderWidth = collider.size.x;
        _blockColliderHeight = collider.size.y;

        _blockNum = (int) (_screenWidth / _blockColliderWidth);

        Destroy(tempblock);

        _startPositionX = ScreenUtils.ScreenLeft + (_screenWidth - _blockNum * _blockColliderWidth) / 2;
        _startPositionY = ScreenUtils.ScreenBottom + (_screenHeight * 0.8f);

        currentPosition = new Vector2(_startPositionX + (_blockColliderWidth / 2), _startPositionY);

        for (int i = 0; i < _blockNum; i++)
        {
            currentPosition.y = _startPositionY;
            for (int j = 0; j < 3; j++)
            {
                PlaceBlock(currentPosition);
                currentPosition.y -= _blockColliderHeight;
            }
            currentPosition.x += _blockColliderWidth;
        }

    }
    private void PlaceBlock(Vector2 position)
    {
        float probability = Random.Range(0,100);

        if (probability <= ConfigurationUtils.StandardBlockProbability)
        {
            _currentBlock = Instantiate(_standardBlock, position, Quaternion.identity);
        }
        else if (probability <= ConfigurationUtils.StandardBlockProbability + ConfigurationUtils.BonusBlockProbability)
        {
            _currentBlock = Instantiate(_bonusBlock, position, Quaternion.identity);
        }
        else
        {
            _currentBlock = Instantiate(_pickUpBlock, position, Quaternion.identity);
            _currentScript = _currentBlock.GetComponent<PickupBlock>();
            int num = Random.Range(0, 2);
            
            if (num == 0)
            {
                _currentScript.Effect = PickupEffect.Freezer;
            }
            else
            {
                _currentScript.Effect = PickupEffect.Speedup;
            }
        }
    }
}

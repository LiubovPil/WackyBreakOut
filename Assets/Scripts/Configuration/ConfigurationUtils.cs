using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    private static ConfigurationData _configData;

    #region Properties
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return _configData.PaddleMoveUnitsPerSecond; }
    }
    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public static float BallImpulseForce
    {
        get { return _configData.BallImpulseForce; }
    }
    /// <summary>
    /// Gets the Lifetime of ball
    /// </summary>
    /// <value>impulse force</value>
    public static float BallLifetime
    {
        get { return _configData.BallLifetime; }
    }
    /// <summary>
    /// Gets the minimum spawn time
    /// </summary>
    /// <value>impulse force</value>
    public static float MinBallSpawn
    {
        get { return _configData.MinBallSpawn; }
    }
    /// <summary>
    /// Gets the maximum spawn time
    /// </summary>
    /// <value>impulse force</value>
    public static float MaxBallSpawn
    {
        get { return _configData.MaxBallSpawn; }
    }
    /// <summary>
    /// Gets the score for standard block
    /// </summary>
    /// <value>impulse force</value>
    public static float BlockPoints
    {
        get { return _configData.BlockPoints; }
    }
    /// <summary>
    /// ets the score for bonus block 
    /// </summary>
    /// <value>impulse force</value>
    public static float BonusBlockPoints
    {
        get { return _configData.BonusBlockPoints; }
    }
    /// <summary>
    /// Gets the score for pick up block
    /// </summary>
    /// <value>impulse force</value>
    public static float PickupPoint
    {
        get { return _configData.PickupPoint; }
    }
    /// <summary>
    /// Gets the probability of occurrence of standard block
    /// </summary>
    /// <value>impulse force</value>
    public static float StandardBlockProbability
    {
        get { return _configData.StandardBlockProbability; }
    }
    /// <summary>
    /// Gets the probability of occurrence of bonus block
    /// </summary>
    /// <value>impulse force</value>
    public static float BonusBlockProbability
    {
        get { return _configData.BonusBlockProbability; }
    }
    /// <summary>
    /// Gets the probability of occurrence of freezer block
    /// </summary>
    /// <value>impulse force</value>
    public static float FreezerBlockProbability
    {
        get { return _configData.FreezerBlockProbability; }
    }
    /// <summary>
    /// Gets the probability of occurrence of speed block
    /// </summary>
    /// <value>impulse force</value>
    public static float SpeedBlockProbability
    {
        get { return _configData.SpeedBlockProbability; }
    }
    /// <summary>
    /// Gets the total number of ball
    /// </summary>
    /// <value>impulse force</value>
    public static float BallLeft
    {
        get { return _configData.BallLeft; }
    }
    /// <summary>
    /// Gets the time of freezen effect
    /// </summary>
    /// <value>impulse force</value>
    public static float FreezenTime
    {
        get { return _configData.FreezenTime; }
    }
    /// <summary>
    /// Gets the time of speed effect
    /// </summary>
    /// <value>impulse force</value>
    public static float SpeedupTime
    {
        get { return _configData.SpeedupTime; }
    }
    /// <summary>
    /// Gets the value of speed factor
    /// </summary>
    /// <value>impulse force</value>
    public static float SpeedupFactor
    {
        get { return _configData.SpeedupFactor; }
    }
    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        _configData = new ConfigurationData();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    private const string ConfigurationDataFileName = "ConfigData.csv";

    // configuration data
    private static float _paddleMoveUnitsPerSecond = 10f;
    private static float _ballImpulseForce = 200f;
    private static float _ballLifeTime = 8f;
    private static float _minBallSpawn = 5f;
    private static float _maxBallSpawn = 10f;
    private static float _bonusBlockPoints = 15f;
    private static float _blockPoints = 10f;
    private static float _pickUpPoint = 20f;
    private static float _standardBlockProbability = 70f;
    private static float _bonusBlockProbability = 25f;
    private static float _freezerBlockProbability = 0f;
    private static float _speedBlockProbability = 5f;
    private static float _ballLeft = 7f;
    private static float _freezenTime = 3f;
    private static float _speedUpTime = 4f;
    private static float _speedUpFactor = 3f;
    #endregion

    #region Properties
    public float PaddleMoveUnitsPerSecond
    {
        get { return _paddleMoveUnitsPerSecond; }
    }
    public float BallImpulseForce
    {
        get { return _ballImpulseForce; }    
    }
    public float MinBallSpawn
    {
        get { return _minBallSpawn; }
    }
    public float MaxBallSpawn
    {
        get { return _maxBallSpawn; }
    }
    public float BallLifetime
    {
        get { return _ballLifeTime; }
    }
    public float BlockPoints
    {
        get { return _blockPoints; }
    }
    public float BonusBlockPoints
    {
        get { return _bonusBlockPoints; }
    }
    public float PickupPoint
    {
        get { return _pickUpPoint; }
    }
    public float StandardBlockProbability
    {
        get { return _standardBlockProbability; }
    }
    public float BonusBlockProbability
    {
        get { return _bonusBlockProbability; }
    }
    public float FreezerBlockProbability
    {
        get { return _freezerBlockProbability; }
    }
    public float SpeedBlockProbability
    {
        get { return _speedBlockProbability; }
    }
    public float BallLeft
    {
        get { return _ballLeft; }
    }
    public float FreezenTime
    {
        get { return _freezenTime; }
    }
    public float SpeedupTime
    {
        get { return _speedUpTime; }
    }
    public float SpeedupFactor
    {
        get { return _speedUpFactor; }
    }
    #endregion

    #region Constructor
    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;
        try 
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            string names = input.ReadLine();
            string values = input.ReadLine();

            string[] sepValues = values.Split(',');

            _paddleMoveUnitsPerSecond = float.Parse(sepValues[0]);
            _ballImpulseForce = float.Parse(sepValues[1]);
            _ballLifeTime = float.Parse(sepValues[2]);
            _minBallSpawn = float.Parse(sepValues[3]);
            _maxBallSpawn = float.Parse(sepValues[4]);
            _blockPoints = float.Parse(sepValues[5]);
            _bonusBlockPoints = float.Parse(sepValues[6]);
            _pickUpPoint = float.Parse(sepValues[7]);
            _standardBlockProbability = float.Parse(sepValues[8]);
            _bonusBlockProbability = float.Parse(sepValues[9]);
            _freezerBlockProbability = float.Parse(sepValues[10]);
            _speedBlockProbability = float.Parse(sepValues[11]);
            _ballLeft = float.Parse(sepValues[12]);
            _freezenTime = float.Parse(sepValues[13]);
            _speedUpTime = float.Parse(sepValues[14]);
            _speedUpFactor = float.Parse(sepValues[15]);

            Debug.Log("paddleMoveUnitsPerSecond " + _paddleMoveUnitsPerSecond);
            Debug.Log("ballImpulseForce " + _ballImpulseForce);
            Debug.Log("ballLifetime " + _ballLifeTime);
            Debug.Log("minballspawn " + _minBallSpawn);
            Debug.Log("maxballspawn " + _maxBallSpawn);
            Debug.Log("blockpoints " + _blockPoints);
            Debug.Log("pickuppoint " + _pickUpPoint);
            Debug.Log("standardblockprobability " + _standardBlockProbability);
            Debug.Log("freezerblockprobability " + _freezerBlockProbability);
            Debug.Log("speedblockprobability " + _speedBlockProbability);
            Debug.Log("ballleft " + _ballLeft);
            Debug.Log("freezentime " + _freezenTime);
            Debug.Log("speeduptime " + _speedUpTime);
            Debug.Log("speedupfactor " + _speedUpFactor);
        }
        catch(Exception exc)
        {
            Debug.LogWarning("There is no config data " + exc);
        }
        finally 
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }
    #endregion
}

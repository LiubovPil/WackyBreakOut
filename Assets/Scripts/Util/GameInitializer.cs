using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour 
{
	private void Awake()
    {
        // initialize screen utils
        ScreenUtils.Initialize();
        ConfigurationUtils.Initialize();
    }
}

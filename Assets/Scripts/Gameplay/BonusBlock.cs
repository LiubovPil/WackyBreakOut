using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block
{
    override protected void Start()
    {
        score = ConfigurationUtils.BonusBlockPoints;
        base.Start();
    }
}

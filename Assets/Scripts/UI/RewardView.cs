using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardView : AnimatedText
{
    public void SetReward(int amount)
    {
        Animate(0, amount);
    }
}

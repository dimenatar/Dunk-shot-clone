public class RewardView : AnimatedText
{
    public void SetReward(int amount)
    {
        Animate(0, amount);
    }
}

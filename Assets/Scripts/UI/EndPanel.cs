using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private RewardView _rewardView;

    [SerializeField] private Transform _winPanel;
    [SerializeField] private Transform _losePanel;

    private bool _isShown;

    public void ShowPanel(bool isWin)
    {
        if (!_isShown)
        {
            _isShown = true;

            if (isWin)
            {
                _winPanel.ScaleIn(duration: 0f, update: true);
            }
            else
            {
                _losePanel.ScaleIn(duration: 0f, update: true);
            }
        }
    }

    private void ShowAnimations(int reward)
    {
        _rewardView.SetReward(reward);
    }
}

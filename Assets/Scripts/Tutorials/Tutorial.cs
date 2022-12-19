using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] protected Image _tutorialImage;

    public virtual void ShowTutorial()
    {
        _tutorialImage.gameObject.SetActive(true);
    }

    public virtual void HideTutorial()
    {
        _tutorialImage.gameObject.SetActive(false);
    }
}

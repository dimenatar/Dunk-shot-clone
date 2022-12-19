using UnityEngine;

public class SoundsPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;

    [SerializeField] private AudioClip _collisionSound;
    [SerializeField] private AudioClip _enteredSound;
    [SerializeField] private AudioClip _starCollected;

    private void Awake()
    {
        HoopsController.BallAdded += PlayBallEnteredHoopSound;
        BallForce.Collision += PlayCollisionSound;
        HoopStar.StarCollected += PlayStarCollectedSound;
    }

    private void OnDestroy()
    {
        HoopsController.BallAdded -= PlayBallEnteredHoopSound;
        BallForce.Collision -= PlayCollisionSound;
        HoopStar.StarCollected -= PlayStarCollectedSound;
    }

    private void PlayCollisionSound()
    {
        _source.PlayOneShot(_collisionSound);
    }

    private void PlayBallEnteredHoopSound()
    {
        _source.PlayOneShot(_enteredSound);
    }

    private void PlayStarCollectedSound()
    {
        _source.PlayOneShot(_starCollected);
    }
}

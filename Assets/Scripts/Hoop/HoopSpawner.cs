using System;
using System.Linq;
using UnityEngine;

public class HoopSpawner : MonoBehaviour
{
    [SerializeField] private HoopsSettings _hoopsSettings;

    [SerializeField] private Vector2 _xBounds;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _minXDeltaBetweenHoops = 2f;

    public void Spawn(int currentLevel, float currentYPos, float pastXPos, Action<Hoop> triggerCallback)
    {
        var hoopPrefab = GetHoop(currentLevel);

        var xPosition = ResolutionPositionsScaler.GetNormilizedXPosition(GetXPosition(pastXPos));
        
        var hoop = Instantiate(hoopPrefab.Prefab, new Vector3(xPosition, currentYPos + _yOffset), Quaternion.identity);

        hoop.SetActive(false);
        hoop.transform.ScaleIn();
        hoop.GetComponent<Hoop>().BallEntered += triggerCallback;
    }

    private HoopPrefab GetHoop(int currentLevel)
    {
        for (int i = _hoopsSettings.Hoops.Count - 1; i >= 0; i--)
        {
            if (currentLevel >= _hoopsSettings.Hoops[i].MinLevelOrderToSpawn)
            {
                if (IsEnoughChance(_hoopsSettings.Hoops[i].ChanceToSpawn))
                {
                    return _hoopsSettings.Hoops[i];
                }
            }
        }
        return _hoopsSettings.Hoops.First();
    }

    private bool IsEnoughChance(float chance)
    {
        return UnityEngine.Random.Range(0.0f, 1.0f) <= chance;
    }

    private float GetXPosition(float pastXPosition)
    {
        float newXPosition = Extensions.FloatRange(_xBounds.x, _xBounds.y, 0.1f).Where(number => !(number >= pastXPosition - _minXDeltaBetweenHoops && number <= pastXPosition + _minXDeltaBetweenHoops)).ToList().GetRandom();

        return newXPosition;
    }
}

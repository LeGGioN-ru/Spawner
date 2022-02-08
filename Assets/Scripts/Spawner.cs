using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _pointsParent;
    [SerializeField] private Enemy _enemy;

    private Transform[] _childPoints;
    private bool _isOn = true;
    private WaitForSecondsRealtime _sleepTime;

    private void Start()
    {
        int spawnDelaySeconds = 2;

        _childPoints = new Transform[_pointsParent.childCount];
        _sleepTime = new WaitForSecondsRealtime(spawnDelaySeconds);

        for (int i = 0; i < _pointsParent.childCount; i++)
        {
            _childPoints[i] = _pointsParent.GetChild(i);
        }

        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        int currentDot = 0;

        while (_isOn)
        {
            Instantiate(_enemy, _childPoints[currentDot]);

            currentDot++;

            if (currentDot == _childPoints.Length)
            {
                currentDot = 0;
            }

            yield return _sleepTime;
        }
    }
}

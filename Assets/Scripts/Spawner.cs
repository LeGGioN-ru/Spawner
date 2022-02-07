using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private GameObject _enemy;

    private Transform[] _pointsInPath;
    private bool _isOn = true;
    private WaitForSecondsRealtime _sleepTime;

    private void Start()
    {
        int spawnDelaySeconds = 2;

        _pointsInPath = new Transform[_path.childCount];
        _sleepTime = new WaitForSecondsRealtime(spawnDelaySeconds);

        for (int i = 0; i < _path.childCount; i++)
        {
            _pointsInPath[i] = _path.GetChild(i);
        }

        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        int currentDot = 0;

        while (_isOn)
        {
            Instantiate(_enemy, _pointsInPath[currentDot]);

            currentDot++;

            if (currentDot == _pointsInPath.Length)
            {
                currentDot = 0;
            }

            yield return _sleepTime;
        }
    }
}

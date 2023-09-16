using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public event UnityAction<float, float> WaveTimer;
    public event UnityAction<int, int> EnemyCountChanged;

    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Tower _target;
    [SerializeField] private float _timeBetweenWaves;

    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    private float _timeAfterLastSpawn;
    private float _wavesDelay;
    private int _spawned;
    private float waveTimer = 0;

    private void Start()
    {
        SetWave(_currentWaveIndex);
    }

    private void FixedUpdate()
    {
        if (_currentWave != null)
        {
            WaveTimer?.Invoke(waveTimer, _currentWave.Duration);
            waveTimer += Time.deltaTime;
        }
        else
        {
            WaveTimer?.Invoke(_wavesDelay, _timeBetweenWaves);
        }

        if (_currentWave == null && (_waves.Count > _currentWaveIndex + 1))
        {
            _wavesDelay -= Time.deltaTime;

            if (_wavesDelay < 0)
            {
                NextWave();
                waveTimer = 0;
            }
        }

        if (_currentWave == null)
        {
            return;
        }

        _timeAfterLastSpawn += Time.deltaTime;

        float enemyDelay = _currentWave.Duration / _currentWave.Count;

        if (_timeAfterLastSpawn >= enemyDelay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
        }

        if (_currentWave.Count <= _spawned)
        {
            _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Enemy, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_target);
        enemy.Dying += OnEnemyDying;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;

        _target.AddMoney(enemy.Reward);
    }

    private void SetWave(int index)
    {
        _wavesDelay = _timeBetweenWaves;
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
    }

    public void NextWave()
    {
        SetWave(++_currentWaveIndex);
        _spawned = 0;
    }
}

[System.Serializable]
public class Wave
{
    public Enemy Enemy;
    public float Duration;
    public int Count;
}

using Assets.Project.CodeBase.Fish;
using Assets.Project.CodeBase.Fish.Factory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFish : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown = 2f;
    [SerializeField] private int _maxCountFish = 100;
    
    private FishFactory _fishFactory;
    private RandomServer _random;

    private List<Fish> _fishes = new List<Fish>();

    private Coroutine _spawnCoroutine;

    public int MaxCountFish => _maxCountFish;

    private void Update()
    {
        if (_random != null)
            _random.GetRandomPositionFish();
    }

    public void Construct(FishFactory fishFactory, RandomServer random)
    {
        _fishFactory = fishFactory;
        _random = random;
    }

    public void StartWork()
    {
        StopWork();

        _spawnCoroutine = StartCoroutine(Spawn());
    }

    private void StopWork()
    {
        if(_spawnCoroutine != null )
            StopCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_fishes.Count < _maxCountFish)
        {
            TypeFish typeFish = (TypeFish)UnityEngine.Random.Range(0, Enum.GetValues(typeof(TypeFish)).Length);

            Fish fish = _fishFactory.GetFish(typeFish, _random.WhereToSpawn);

            AddFish(fish);

            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    private void AddFish(Fish fish)
    {
        fish.FishDied += OnFishDied;
        _fishes.Add(fish);
    }

    private void OnFishDied(Fish fish)
    {
        fish.FishDied -= OnFishDied;
        _fishes.Remove(fish);
    }
}

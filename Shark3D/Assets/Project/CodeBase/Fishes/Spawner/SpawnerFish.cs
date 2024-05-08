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
    public List<Fish> Fishes => _fishes;

    private void Update() => 
        StartSpawn();

    public void Construct(FishFactory fishFactory, RandomServer random)
    {
        _fishFactory = fishFactory;
        _random = random;
    }
    
    private void StartSpawn()
    {
        while (_fishes.Count < _maxCountFish)
        {
            Fish fish = SpawnFishes();
            AddFish(fish);
        }
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
            Fish fish = SpawnFishes();

            AddFish(fish);

            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    private Fish SpawnFishes()
    {
        Fish fish = _fishFactory.GetFish(_random.SpawnFishes(), _random.GetRandomPosition());
        return fish;
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
        _random.RemoveFish(fish);
    }
}

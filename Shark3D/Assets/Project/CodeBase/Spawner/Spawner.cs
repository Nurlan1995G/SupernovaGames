using Assets.Project.CodeBase.Fish;
using Assets.Project.CodeBase.Fish.Factory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown = 2f;
    
    private FishFactory _fishFactory;

    private List<Fish> _fishes = new List<Fish>();

    private float _nextSpawn = 0.0f;
    private float _randomSpawnX;
    private float _randomSpawnZ;

    private Vector3 _whereToSpawn;

    private Coroutine _spawnCoroutine;

    private void Update()
    {
        if (_fishes.Count > 20)
            return;
       
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnCooldown;

            _randomSpawnX = UnityEngine.Random.Range(-20, 20);
            _randomSpawnZ = UnityEngine.Random.Range(-20, 20);

            _whereToSpawn = new Vector3(_randomSpawnX, 0.2f, _randomSpawnZ);
        }
    }

    public void Construct(FishFactory fishFactory) =>
        _fishFactory = fishFactory;

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

        while (true)
        {
            TypeFish typeFish = (TypeFish)UnityEngine.Random.Range(0, Enum.GetValues(typeof(TypeFish)).Length);

            Fish fish = _fishFactory.GetFish(typeFish, _whereToSpawn);

            //ScoreLevel score = _fishFactory.GetScore();

            //score.transform.position = fish.transform.position;

            _fishes.Add(fish);
            fish.FishDied += OnFishDied;

            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    private void OnFishDied(Fish fish)
    {
        fish.FishDied -= OnFishDied;
        _fishes.Remove(fish);
    }
}

using UnityEngine;

public class RandomServer
{
    private SpawnerFish _spawner;
    
    private float _nextSpawn;
    private float _randomSpawnX;
    private float _randomSpawnZ;
    private Vector3 _whereToSpawn;
    private float _spawnCooldown;

    public Vector3 WhereToSpawn => _whereToSpawn;

    public void Construct(SpawnerFish spawner)
    {
        _spawner = spawner;
    }

    public int GetRandomCountFish()
    {
        while (true)
        {
            int level = Random.Range(0, 65);
            
            if(level == 1 || level == 2 || level == 4 || level == 8 || level == 16 || level == 32 || level == 64) 
                return level;
        }
    }

    public void GetRandomPositionFish()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnCooldown;

            _randomSpawnX = Random.Range(-20, 20);
            _randomSpawnZ = Random.Range(-20, 20);

            _whereToSpawn = new Vector3(_randomSpawnX, 0.2f, _randomSpawnZ);
        }
    }
}

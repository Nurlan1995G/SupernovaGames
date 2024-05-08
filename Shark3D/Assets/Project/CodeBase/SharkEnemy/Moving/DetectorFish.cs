using Assets.Project.CodeBase.SharkEnemy;
using UnityEngine;
using UnityEngine.AI;

public class DetectorFish
{
    private BotSharkMover _botSharkMover;
    private SharkModel _sharkView;

    public DetectorFish(BotSharkMover botSharkMover, SharkModel sharkView)
    {
        _botSharkMover = botSharkMover;
        _sharkView = sharkView;
    }

    public void FindToFish(SpawnerFish spawner, Transform transform, NavMeshAgent agent, float rotateSpeed)
    {
        if (spawner == null || spawner.Fishes.Count == 0)
            return;

        Transform closestFish = null;
        float closestDistance = Mathf.Infinity;

        SelectToFish(spawner, transform, rotateSpeed, ref closestFish, ref closestDistance);

        if (closestFish != null)
        {
            agent.SetDestination(closestFish.position);
        }
    }

    private void SelectToFish(SpawnerFish spawner, Transform transform, float rotateSpeed, ref Transform closestFish, ref float closestDistance)
    {
        foreach (var fish in spawner.Fishes)
        {
            float distance = Vector3.Distance(transform.position, fish.transform.position);

            if (distance < closestDistance && _sharkView.ScoreLevel >= fish.ScoreLevel)
            {
                closestFish = fish.transform;
                closestDistance = distance;

                _botSharkMover.MoveTo(closestFish.position, transform, rotateSpeed);
            }
        }
    }
}
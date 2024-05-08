using Assets.Project.CodeBase.SharkEnemy.Static;
using Assets.Project.CodeBase.SharkEnemy;
using UnityEngine;
using UnityEngine.AI;

public class AgentBotSharkMoveToPlayers : MonoBehaviour
{
    private NavMeshAgent _agent;
    private SharkModel _sharkModel;
    private SharkStaticData _sharkStaticData;
    private PlayerView _player;

    //private float _detectionRadius = 10f; // Радиус обнаружения игрока
    private float _chaseDuration = 10f; // Продолжительность преследования в секундах
    private float _timeLastDetected; // Время последнего обнаружения игрока

    private bool _isChasing = false;

    public void Construct(PlayerView player, NavMeshAgent agent, SharkModel sharkModel, SharkStaticData sharkStaticData)
    {
        _player = player;
        _agent = agent;
        _sharkModel = sharkModel;
        _sharkStaticData = sharkStaticData;
    }

    private void Update()
    {
        if (!_isChasing)
        {
            // Проверяем, если игрок находится в радиусе обнаружения и мы не находимся в режиме преследования
            if (Vector3.Distance(_agent.transform.position, _player.transform.position) <= _sharkStaticData.MinimalDistanceToPlayer)
            {
                _timeLastDetected += Time.time;
                _isChasing = true;
            }
        }
        else
        {
            // Если прошло достаточно времени преследования, выходим из режима преследования
            if (Time.time - _timeLastDetected >= _chaseDuration)
            {
                _isChasing = false;
                _agent.ResetPath();
            }
            else
            {
                // Преследование игрока
                _agent.destination = _player.transform.position;
            }
        }
    }
}

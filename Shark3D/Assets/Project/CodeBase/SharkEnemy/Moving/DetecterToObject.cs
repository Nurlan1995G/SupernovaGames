using Assets.Project.CodeBase.SharkEnemy.StateMashine.State;
using Assets.Project.CodeBase.SharkEnemy;
using System.Collections.Generic;
using UnityEngine;
using Assets.Project.CodeBase.SharkEnemy.Static;

public class DetecterToObject
{
    public const string PlayerTag = "Player";
    public const string SharkBotTag = "Shark1";

    private readonly AgentBotSharkMoveToPlayerState _agentBotSharkMoveToPlayer;
    private readonly AgentMoveBotSharkMoveToSharkState _agentMoveBotSharkMoveToShark;
    private readonly PlayerView _player;

    private readonly AgentMoveState _agentMoveState;
    private readonly SharkModel _sharkModel;
    private readonly SharkStaticData _sharkStaticData;
    public List<string> SharkBots = new List<string> { "Shark1", "Shark2" };
    private float _timeLastDetected;
    private float _chaseDuration = 10f;

    public DetecterToObject( AgentMoveState agentMoveState,  SharkModel sharkModel, SharkStaticData sharkStaticData)
    {
        //_agentBotSharkMoveToPlayer = agentBotSharkMoveToPlayer;
        //_agentMoveBotSharkMoveToShark = agentMoveBotSharkMoveToShark;
        //_player = player;

        _agentMoveState = agentMoveState;
        _sharkModel = sharkModel;
        _sharkStaticData = sharkStaticData;
    }

    public void DetectObjectfd(Transform transform, LayerMask layerMask, float detectionRadius)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, layerMask);
       
        foreach (Collider collider in colliders)
        {
            Debug.Log($"{collider.gameObject} - gameObject");

            // Проверяем, является ли обнаруженный объект игроком или другой акулой
            if (collider.CompareTag(PlayerTag))
            {
                Debug.Log("DetecterToObkect - DetectObject - нашли игрока");
                PositionPlayerObject(collider.gameObject, transform);
            }

            if (collider.CompareTag(SharkBotTag))
            {
                PositionSharkObject(collider.gameObject, transform);
            }
        }
    }

    public void DetectObject(Transform transform, LayerMask layerMask, float detectionRadius)
    {
        GameObject target = GameObject.FindGameObjectWithTag(PlayerTag);

        if (_agentMoveState.IsObjectNotReached(target,transform) && target.CompareTag(PlayerTag))
        {
            PositionPlayerObject(target.gameObject, transform);
        }

        if (target.CompareTag(SharkBotTag))
        {
            PositionSharkObject(target.gameObject, transform);
        }
    }

    private void PositionSharkObject(GameObject positionShark, Transform transform)
    {
        // Проверяем, является ли обнаруженный объект игроком или акулой
        if ((positionShark.GetComponent<SharkModel>().ScoreLevel < _sharkModel.ScoreLevel))
        {
            if (_timeLastDetected < _chaseDuration)
            {
                _agentMoveState.MoveTo(positionShark.transform.position, transform);
                _agentMoveState.IsChangedStateToShark = true;

                _timeLastDetected += Time.deltaTime;
            }
            else
            {
                _timeLastDetected = 0;
                _agentMoveState.IsChangedStateToShark = false;
                Debug.Log("Произошло обнуление");
            }
        }
    }

    private void PositionPlayerObject(GameObject positionTarget, Transform transform)
    {
        // Проверяем, является ли обнаруженный объект игроком или акулой
        if ((positionTarget.GetComponent<PlayerView>().ScoreLevel < _sharkModel.ScoreLevel))
        {
            if (_timeLastDetected < _chaseDuration)
            {
                _agentMoveState.MoveTo(positionTarget.transform.position, transform);

                _timeLastDetected += Time.deltaTime;
                Debug.Log(_timeLastDetected + " - timeLast");
            }
            else
            {
                _timeLastDetected = 0;
                Debug.Log(_timeLastDetected + " - timeLast");
                Debug.Log("Произошло обнуление");
            }
        }
    }

    private void PositionSharkObjects(GameObject positionShark, Transform transform)
    {
            // Проверяем, является ли обнаруженный объект игроком или акулой
            if (( positionShark.GetComponent<SharkModel>().ScoreLevel < _sharkModel.ScoreLevel))
            {
                if (_timeLastDetected <= _chaseDuration)
                {
                    _agentMoveBotSharkMoveToShark.Move(positionShark.transform.position, transform);
                    _agentMoveBotSharkMoveToShark.IsChangedStateToShark = true;

                    _timeLastDetected += Time.deltaTime;
                }
                else
                {
                    _timeLastDetected = 0;
                    _agentMoveBotSharkMoveToShark.IsChangedStateToShark = false;
                    Debug.Log("Произошло обнуление");
                }
            }
    }
}
﻿using Assets.Project.CodeBase.SharkEnemy.StateMashine.Interface;
using Assets.Project.CodeBase.SharkEnemy.Static;
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

namespace Assets.Project.CodeBase.SharkEnemy.StateMashine.State
{
    public class AgentMoveBotSharkMoveToSharkState : AgentMoveState
    {
        private DetecterToObject _detectorToObject;
        
        private float _chaseDuration = 10f; // Продолжительность преследования в секундах
        private float _timeLastDetected; // Время последнего обнаружения игрока
        private bool _isStart;
        private Vector3 _position;
        private Transform _transform;

        public AgentMoveBotSharkMoveToSharkState(NavMeshAgent agent, SharkModel sharkModel, SharkStaticData sharkStaticData, SpawnerFish spawnerFish) : base(agent, sharkModel, sharkStaticData, spawnerFish)
        {
        }

        public void Update()
        {
            if(IsChangedStateToShark)
                MoveTo(_position, _transform);
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Move(Vector3 positionShark, Transform transform)
        {
            _position = positionShark;
            _transform = transform;
        }

        private void FindLogic()
        {
            //GameObject targetObject = DetectTarget("Shark");

            //PositionObject(targetObject);

            //PositionSharkBot();
        }

        private void PositionObject(GameObject targetObject)
        {
            if (targetObject != null)
            {
                Debug.Log("Акуле боту обнаружен объект: " + targetObject.name);

                // Проверяем, является ли обнаруженный объект игроком или акулой
                if ((targetObject.CompareTag("Shark") && targetObject.GetComponent<SharkModel>()
                    .ScoreLevel < SharkModel.ScoreLevel))
                {
                    if (_timeLastDetected <= _chaseDuration)
                    {
                        Debug.Log("Акуле боту начинает преследование объекта: " + targetObject.name);
                        MoveTo(targetObject.transform.position, SharkModel.transform);
                        _timeLastDetected += Time.deltaTime;
                    }
                    else
                    {
                        _timeLastDetected = 0;
                        Debug.Log("Произошло обнуление");
                    }
                }
            }
        }

        /*private void PositionSharkBot()
        {
            if (IsObjectNotReached(SharkModel.transform, transform) && SharkModel.ScoreLevel < SharkModel.ScoreLevel)
            {
                Debug.Log("Акуле боту интересен другая акула");

                if (_timeLastDetected <= _chaseDuration)
                {
                    Debug.Log("Акуле боту начинает преследование другой акулы");
                    Debug.Log(_timeLastDetected += Time.time);

                    MoveTo(SharkModel.transform.position, SharkModel.transform);
                    _timeLastDetected += Time.time;
                }
                else
                {
                    _timeLastDetected = 0;
                    Debug.Log("произошло обнуление");
                }
            }
        }*/

    }
}

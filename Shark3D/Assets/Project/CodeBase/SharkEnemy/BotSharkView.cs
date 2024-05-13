﻿using Assets.Project.CodeBase.SharkEnemy;
using Assets.Project.CodeBase.SharkEnemy.StateMashine;
using Assets.Project.CodeBase.SharkEnemy.Static;
using UnityEngine;
using UnityEngine.AI;

public class BotSharkView : MonoBehaviour   
{   
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private SharkModel _sharkModel;
    [SerializeField] private AgentBotSharkMoveToPlayer _agentBotSharkMoveToPlayer;

    private float _rotateSpeed = 50f;
        
    private BotSharkMover _botSharkMover;
    private SpawnerFish _spawner;
    private SharkStaticData _sharkStaticData;
    private DetectorFish _detectorFish;
    private PlayerView _player;
    private SharkBotStateMachine _stateMashine;

    [field: SerializeField] public BotSharkNickName NickName { get; private set; }

    private void Start()
    {
        //_botSharkMover = new BotSharkMover(_agent, transform);
        //_detectorFish = new DetectorFish(_botSharkMover, _sharkModel);
        //_agentBotSharkMoveToPlayer.Construct(_player, _agent, _sharkModel, _sharkStaticData);
        _stateMashine = new SharkBotStateMachine(_agent, _sharkModel, _sharkStaticData, _player, _spawner);
    }

    private void Update()
    {
        //_detectorFish.FindToFish(_spawner, transform, _agent, _rotateSpeed);
        _stateMashine?.Update();
    }

    public void Construct(SpawnerFish spawner, SharkStaticData sharkStaticData, PlayerView player)
    {
        _spawner = spawner;
        _sharkStaticData = sharkStaticData;
        _player = player;
    }
}

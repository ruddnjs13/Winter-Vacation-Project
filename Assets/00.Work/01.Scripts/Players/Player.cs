using System;
using _00.Work._01.Scripts.Entities;
using _00.Work._01.Scripts.Player;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private InputReaderSO _inputReaderSO;

    [SerializeField] private StateListSO playerFSM;
    
    private StateMachine _stateMachine;

    protected override void Awake()
    {
        base.Awake();
        _stateMachine = new StateMachine(this, playerFSM);
        ComponentInitialize();
    }

    private void Start()
    {
        ChangeState("IDLE");
    }

    protected override void ComponentInitialize()
    {
        base.ComponentInitialize();
    }


    private void Update()
    {
        _stateMachine.UpdateStateMachine();
    }
    
    public void ChangeState(string stateName) => _stateMachine.ChangeState(stateName);
}

using System;
using _00.Work._01.Scripts.Entities;
using _00.Work._01.Scripts.Player;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private InputReaderSO _inputReaderSO;

   

    private void OnEnable()
    {
        _inputReaderSO.JumpKeyPressed += HandleJumpKeyPress;
    }

    private void OnDestroy()
    {
        _inputReaderSO.JumpKeyPressed -= HandleJumpKeyPress;
    }

    private void HandleJumpKeyPress()
    {
    }

    private void Update()
    {
    }
}

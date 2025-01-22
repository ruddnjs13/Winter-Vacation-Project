using System;
using _00.Work._01.Scripts.Player;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReaderSO;

    public PlayerMove MoveCompo { get; private set; }


    private void Awake()
    {
        MoveCompo = GetComponent<PlayerMove>();
    }

    private void OnEnable()
    {
        _inputReaderSO.JumpKeyPressed += HandleJumpKeyPress;
    }

    private void HandleJumpKeyPress()
    {
        MoveCompo.Jump();
    }

    private void Update()
    {
        MoveCompo.SetMovement(_inputReaderSO.InputDirection);
    }
}

using System.Numerics;
using _00.Work._01.Scripts.Entities;
using Code.Animators;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace _00.Work._01.Scripts.Player.States
{
    public class PlayerIdleState : PlayerGroundState
    {
        public PlayerIdleState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _mover.StopImmediately();
        }

        public override void Update()
        {
            Vector2 movement = _player.PlayerInput.InputDirection;
            base.Update();
            _mover.SetMovement(Vector2.zero);
            if(Mathf.Abs(movement.x) >0 || Mathf.Abs(movement.y) > 0)
                _player.ChangeState("MOVE");
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
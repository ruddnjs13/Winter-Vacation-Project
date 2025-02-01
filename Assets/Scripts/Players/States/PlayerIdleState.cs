using Animations;
using Entities;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Players.States
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
            base.Update();
            Vector2 movement = _player.PlayerInput.InputDirection;
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
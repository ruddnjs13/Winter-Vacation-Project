using Animations;
using Entities;
using UnityEngine;

namespace Players.States
{
    public class PlayerMoveState : PlayerGroundState
    {
        public PlayerMoveState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
        }

        public override void Update()
        {
            base.Update();

            Vector2 movement = _player.PlayerInput.InputDirection;
            
            _mover.SetMovement(movement);
            
            if (Mathf.Approximately(movement.x, 0f) && Mathf.Approximately(movement.y, 0f))
                _player.ChangeState("IDLE");
        }
    }
}
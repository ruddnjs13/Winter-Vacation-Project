using Animations;
using Entities;
using UnityEngine;

namespace Players.States
{
    public class PlayerJumpState : EntityState
    {
        private Player _player;
        private EntityMover _mover;
        private EntityRenderer _renderer;
        
        public PlayerJumpState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Player;
            _mover = entity.GetCompo<EntityMover>();
        }

        public override void Enter()
        {
            base.Enter();
            _mover.StopImmediately();
            _mover.RbCompo.AddForce(Vector3.up * 8, ForceMode.Impulse);
        }

        public override void Update()
        {
            base.Update();

            Vector2 movement = _player.PlayerInput.InputDirection;
            _mover.SetMovement(movement);
            if (_mover.RbCompo.linearVelocity.y < 1f) 
                    _player.ChangeState("JUMP_LOOP");
        }
    }
}
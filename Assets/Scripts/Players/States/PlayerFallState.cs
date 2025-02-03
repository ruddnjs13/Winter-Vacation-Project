using Animations;
using Entities;
using UnityEngine;

namespace Players.States
{
    public class PlayerFallState : EntityState
    {
        private Player _player;
        private EntityMover _mover;
        private EntityRenderer _renderer;

        public PlayerFallState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Player;
            _mover = entity.GetCompo<EntityMover>();
            _renderer = entity.GetCompo<EntityRenderer>();
            
        }

        public override void Enter()
        {
            base.Enter();
            _renderer.SetParam(_player.Y_VELOCITYParam, _mover.Movement.y);
        }

        public override void Update()
        {
            base.Update();
            Vector2 movement = _player.PlayerInput.InputDirection;
            _mover.SetMovement(movement);


            if (_mover.isGroundDetect())
                _player.ChangeState("IDLE");
        }

        public override void Exit()
        {
            _renderer.SetParam(_player.Y_VELOCITYParam, 1f);
            base.Exit();
        }
    }
}
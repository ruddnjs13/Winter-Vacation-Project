using Animations;
using Entities;

namespace Players.States
{
    
    public class PlayerGroundState : EntityState
    {
        protected Player _player;
        protected EntityMover _mover;
        
        public PlayerGroundState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Player;
            _mover = entity.GetCompo<EntityMover>();
        }

        public override void Enter()
        {
            base.Enter();
            _player.PlayerInput.JumpKeyPressed += HandleJumpKeyPressed;
        }

        public override void Exit()
        {
            _player.PlayerInput.JumpKeyPressed -= HandleJumpKeyPressed;
            base.Exit();
        }

        private void HandleJumpKeyPressed()
        {
            if (_mover.IsGroundDetect())
                _player.ChangeState("JUMP");
        }
    }
}
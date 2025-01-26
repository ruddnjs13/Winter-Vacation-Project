using _00.Work._01.Scripts.Entities;
using Code.Animators;
using UnityEngine;

namespace _00.Work._01.Scripts.Player.States
{
    
    public class PlayerGroundState : EntityState
    {
        protected Players.Player _player;
        protected EntityMover _mover;
        
        public PlayerGroundState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Players.Player;
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
            if (_mover.isGroundDetect())
                _player.ChangeState("JUMP");
        }
    }
}
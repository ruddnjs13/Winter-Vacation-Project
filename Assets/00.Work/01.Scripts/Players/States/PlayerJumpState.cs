using _00.Work._01.Scripts.Entities;
using Code.Animators;
using UnityEngine;

namespace _00.Work._01.Scripts.Player.States
{
    public class PlayerJumpState : EntityState
    {
        private Players.Player _player;
        private EntityMover _mover;
        
        public PlayerJumpState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Players.Player;
            _mover = entity.GetCompo<EntityMover>();
        }

        public override void Enter()
        {
            base.Enter();
            _mover.RbCompo.AddForce(Vector3.up * 7, ForceMode.Impulse);
        }

        public override void Update()
        {
            base.Update();
            //if (_mover.isGroundDetect())
                //_player.ChangeState("IDLE");
        }
    }
}
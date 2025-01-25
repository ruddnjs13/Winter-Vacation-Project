using System;
using Unity.Mathematics;
using UnityEngine;

namespace _00.Work._01.Scripts.Entities
{
    public class EntityMover : MonoBehaviour, IEntityComponent
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpPower = 7f;
        [SerializeField] private Vector3 boxHalfSize;
        [SerializeField] private float boxHeight = 0.5f;
        [SerializeField] private LayerMask whatIsGround;
        
        private Entity _entity;
        
        private Rigidbody rbCompo;
        
        public Vector3 Movement { get; private set; }
        
        public void Initialize(Entity entity)
        {
            _entity = entity;
            rbCompo = _entity.GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rbCompo.linearVelocity = Movement;
        }

        public void SetMovement(Vector2 movement)
        {
            Movement = new Vector3(movement.x * moveSpeed
                , rbCompo.linearVelocity.y, movement.y * moveSpeed);
        }

        public void StopImmediately()
        {
            
        }

        public bool isGroundDetect()
        {
            return Physics.BoxCast(transform.position,boxHalfSize,Vector3.down,
                Quaternion.identity,boxHeight,whatIsGround);
        }
    }
}
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
        [SerializeField] private Transform boxTrm;
        [SerializeField] private float boxHeight = 0.5f;
        [SerializeField] private LayerMask whatIsGround;
        
        private Entity _entity;
        
        public Rigidbody RbCompo {get; private set;}
        
        public Vector3 Movement { get; private set; }
        
        public void Initialize(Entity entity)
        {
            _entity = entity;
            RbCompo = _entity.GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            RbCompo.linearVelocity = Movement;
        }

        public void SetMovement(Vector2 movement)
        {
            Movement = new Vector3(movement.x * moveSpeed
                , RbCompo.linearVelocity.y, movement.y * moveSpeed);
        }

        public void StopImmediately()
        {
            RbCompo.linearVelocity = Vector3.zero;
        }

        public bool isGroundDetect()
        {
            return Physics.BoxCast(boxTrm.position, boxHalfSize, Vector3.down,
                Quaternion.identity, boxHeight, whatIsGround) != null;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(boxTrm.position + new Vector3(0,-boxHeight,0),boxHalfSize * 2);
            Gizmos.DrawRay(boxTrm.position ,Vector3.down * boxHeight);
        }
#endif
    }
    
}
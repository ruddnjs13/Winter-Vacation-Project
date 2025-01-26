using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace _00.Work._01.Scripts.Entities
{
    public class EntityMover : MonoBehaviour, IEntityComponent
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Vector3 boxSize;
        [SerializeField] private Transform checkerTrm;
        [SerializeField] private float maxDistance;
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
            if (Physics.BoxCast(checkerTrm.position, boxSize / 2f, Vector3.down,
                    Quaternion.identity, maxDistance, whatIsGround))
            {
                
                return true;
            }
            return false;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(checkerTrm.position, Vector3.down * maxDistance);
            Gizmos.DrawWireCube(checkerTrm.position + Vector3.down * maxDistance, boxSize);
        }
#endif
    }
    
}
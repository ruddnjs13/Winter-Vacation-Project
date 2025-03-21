using UnityEngine;
using UnityEngine.Serialization;

namespace Entities
{
    public class EntityMover : MonoBehaviour, IEntityComponent
    {
        [FormerlySerializedAs("cameraTrm")] [SerializeField] private Camera followCam;
        
        [Header("Movement Setting")]
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float rotationSpeed = 5f;
        
        [Header("GroundCheck Setting")]
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
            MoveCharacter();
            RotateCharacter();
        }

        private void MoveCharacter()
        {
            RbCompo.MovePosition(transform.position + Movement * moveSpeed* Time.fixedDeltaTime);
        }

        public void SetMovement(Vector2 movement)
        {
            Vector3 forward = followCam.transform.localRotation * Vector3.forward;
            Vector3 right = Quaternion.Euler(0,90,0) * forward;
            Vector3 moveDir = forward * movement.y + right * movement.x;
            Movement =  new Vector3(moveDir.x, 0, moveDir.z);
        }

        public void StopImmediately()
        {
            RbCompo.linearVelocity = Vector3.zero;
        }

        public bool IsGroundDetect()
        {
            if (Physics.BoxCast(checkerTrm.position, boxSize / 2f, Vector3.down,
                    Quaternion.identity, maxDistance, whatIsGround))
            {
                return true;
            }
            return false;
        }

        public void RotateCharacter()
        {
            if (Movement == Vector3.zero) return;
            transform.rotation = Quaternion.Lerp(transform.rotation
                , Quaternion.LookRotation(Movement), rotationSpeed * Time.deltaTime);
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
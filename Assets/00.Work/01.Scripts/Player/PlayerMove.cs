using System;
using UnityEngine;

namespace _00.Work._01.Scripts.Player
{
    public class PlayerMove : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpPower;
        
        public Vector3 MovementDirection { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetMovement(Vector2 movement)
        {
            MovementDirection = new Vector3(movement.x * moveSpeed, _rigidbody.linearVelocity.y, movement.y * moveSpeed);
        }

        public void Jump()
        {
            _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }


        private void FixedUpdate()
        {
            _rigidbody.linearVelocity = MovementDirection;
            
        }
    }
}
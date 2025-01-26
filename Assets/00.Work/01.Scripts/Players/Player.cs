using _00.Work._01.Scripts.Entities;
using UnityEngine;

namespace _00.Work._01.Scripts.Players
{
    public class Player : Entity
    {
        [field:SerializeField] public InputReaderSO PlayerInput { get; private set; }

        [SerializeField] private StateListSO playerFSM;
    
        private StateMachine _stateMachine;

        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new StateMachine(this, playerFSM);
            ComponentInitialize();
        }

        private void Start()
        {
            ChangeState("IDLE");
        }

        protected override void ComponentInitialize()
        {
            base.ComponentInitialize();
        }


        private void Update()
        {
            _stateMachine.UpdateStateMachine();
        }
    
        public void ChangeState(string stateName) => _stateMachine.ChangeState(stateName);
    }
}

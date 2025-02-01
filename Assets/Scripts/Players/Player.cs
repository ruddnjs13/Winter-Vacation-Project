using Animations;
using Entities;
using UnityEngine;

namespace Players
{
    public class Player : Entity
    {
        [field:SerializeField] public InputReaderSO PlayerInput { get; private set; }

        [SerializeField] private StateListSO playerFSM;
        [field:SerializeField] public AnimParamSO Y_VELOCITYParam;
    
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

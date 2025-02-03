using System.Linq;
using Animations;
using Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Players
{
    public class Player : Entity
    {
        [field:SerializeField] public InputReaderSO PlayerInput { get; private set; }

        [SerializeField] private StateListSO playerFsm;
        [field:SerializeField]public AnimParamSO Y_VELOCITYParam{get; private set;}
        
        private StateMachine _stateMachine;

        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new StateMachine(this, playerFsm);
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

        public AnimParamSO FindParam(string paramName)
        {
            AnimParamSO returnParam = null;

            foreach (StateSO state in playerFsm.states)
            {
                if (paramName == state.name)
                {
                    returnParam = state.animParam;
                    return returnParam;
                }
            }
            Debug.Assert(returnParam == null, $"{paramName} Param is not found");
            return null;
        }
    }
}

using Animations;
using UnityEngine;

namespace Entities
{
    public class EntityRenderer : MonoBehaviour, IEntityComponent
    {
        private Entity _entity;
        private Animator _animator;
        
       
        public void Initialize(Entity entity)
        {
            _entity = entity;
            _animator = GetComponent<Animator>();
        }
        
        

        public void SetParam(AnimParamSO animParam) => _animator.SetTrigger(animParam.hashValue);
        public void SetParam(AnimParamSO animParam, int value) => _animator.SetInteger(animParam.hashValue, value);
        public void SetParam(AnimParamSO animParam, float value) => _animator.SetFloat(animParam.hashValue,value);
        public void SetParam(AnimParamSO animParam,bool value) => _animator.SetBool(animParam.hashValue,value);

    }
}
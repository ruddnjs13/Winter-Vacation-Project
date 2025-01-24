using Code.Animators;

namespace _00.Work._01.Scripts.Entities
{
    public abstract class EntityState
    {
        protected Entity _entity;
        
        protected AnimParamSO _animParam;
        
        protected bool _isTriggerCall;
        
        protected EntityRenderer _renderer;

        protected EntityState(Entity entity, AnimParamSO animParam)
        {
            _entity = entity;
            _animParam = animParam;
            _renderer = _entity.GetComponentInChildren<EntityRenderer>();
        }

        public virtual void Enter()
        {
            _renderer.SetParam(_animParam,true);
            _isTriggerCall = false;
        }

        public virtual void Update()
        {
            
        }

        public virtual void Exit()
        {
            _renderer.SetParam(_animParam, false);
        }
        
        public virtual void AnimationEndTrigger() => _isTriggerCall = true;
    }
}
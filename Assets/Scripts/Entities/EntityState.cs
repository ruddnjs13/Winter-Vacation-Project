using Animations;

namespace Entities
{
    public abstract class EntityState
    {
        protected Entity Entity;
        
        protected AnimParamSO AnimParam;
        
        protected bool IsTriggerCall;
        
        protected EntityRenderer Renderer;

        protected EntityState(Entity entity, AnimParamSO animParam)
        {
            this.Entity = entity;
            this.AnimParam = animParam;
            Renderer = this.Entity.GetComponentInChildren<EntityRenderer>();
        }

        public virtual void Enter()
        {
            Renderer.SetParam(AnimParam,true);
            IsTriggerCall = false;
        }

        public virtual void Update()
        {
            
        }

        public virtual void Exit()
        {
            Renderer.SetParam(AnimParam, false);
        }
        
        public virtual void AnimationEndTrigger() => IsTriggerCall = true;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entities
{
    public abstract class Entity : MonoBehaviour
    {
        protected Dictionary<Type, IEntityComponent> _components = new Dictionary<Type, IEntityComponent>();

        protected virtual void Awake()
        {
            AddComponentToDictionary();
            ComponentInitialize();
            AfterInitialize();
        }

        private void AfterInitialize()
        {
            _components.Values.OfType<IAfterInit>().ToList().ForEach(compo => compo.AfterInit());
        }

        protected virtual void ComponentInitialize()
        {
            _components.Values.ToList().ForEach(component => component.Initialize(this));
        }

        private void AddComponentToDictionary()
        {
            GetComponentsInChildren<IEntityComponent>().ToList().ForEach(compo => _components.Add(compo.GetType(), compo));
        }

        public T GetCompo<T>(bool IsDerived = false) where T : IEntityComponent
        {
            if (_components.TryGetValue(typeof(T), out IEntityComponent component))
                return (T)component;
            
            if(IsDerived == false) return default(T);
            
            Type findType = _components.Keys.FirstOrDefault(type => type.IsSubclassOf(typeof(T)));
            if(findType != null)
                return (T)_components[findType];
            
            return default(T);
        }
        
    }
}
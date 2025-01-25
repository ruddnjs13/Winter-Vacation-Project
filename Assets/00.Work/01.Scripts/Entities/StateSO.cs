using Code.Animators;
using UnityEngine;

namespace _00.Work._01.Scripts.Entities
{
    [CreateAssetMenu(fileName = "State", menuName = "SO/FSM/State", order = 0)]
    public class StateSO : ScriptableObject
    {
        public string stateName;
        public string className;
        
        public AnimParamSO animParam;
    }
}
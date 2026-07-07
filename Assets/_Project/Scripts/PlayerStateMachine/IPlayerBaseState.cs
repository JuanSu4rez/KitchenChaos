using UnityEngine;

namespace _Project.Scripts.PlayerStateMachine
{
    public abstract class IPlayerBaseState 
    {
        public abstract void EnterState();
        public abstract void Update();
        
        public virtual void OnCollisionEnter() { }
    }
}

    
    

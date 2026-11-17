namespace _Project.Scripts.PlayerStateMachine
{
    internal abstract class IPlayerBaseState
    {
        internal virtual void EnterState() { }
        internal abstract void Update();
    }
}

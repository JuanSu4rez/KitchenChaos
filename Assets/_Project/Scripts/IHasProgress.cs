using System;

namespace _Project.Scripts
{
    // Anything whose preparation progress can be displayed (an ingredient now, a pot of soup later)
    public interface IHasProgress
    {
        event EventHandler<ProgressChangedEventArgs> OnProgressChanged;

        float ProgressNormalized { get; }
    }

    public class ProgressChangedEventArgs : EventArgs
    {
        public float progressNormalized;
    }
}

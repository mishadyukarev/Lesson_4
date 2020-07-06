using System;

namespace Geekbrains
{
    public interface ITimeRemaining
    {
        float Time { get; set; }
        bool IsTimeRemaining { get; set; }
        event EventHandler<RemoveUserEventArgs> StartTimerEventHandler;
    } 
    
    public sealed class RemoveUserEventArgs : EventArgs
    {
        public float Time { get; }
        public RemoveUserEventArgs(float time)
        {
            Time = time;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public sealed class TimeRemainingController : BaseController, IOnUpdate
    {
        private HashSet<ITimeRemaining> _timeRemainings;

        public TimeRemainingController()
        {
            _timeRemainings = new HashSet<ITimeRemaining>();
        }
        
        public void OnUpdate()
        {
            if (!IsActive)
            {
                return;
            }

            float deltaTime = Time.deltaTime;
            float timeScale = Time.timeScale;
            foreach (var obj in _timeRemainings)
            {
                if (obj.IsTimeRemaining)
                {
                     continue;
                }
                obj.Time -= deltaTime * timeScale;
                if (obj.Time <= 0.0f)
                {
                    CompletedTimeRemaining(obj);
                }
            }
        }

        private void CompletedTimeRemaining(ITimeRemaining value)
        {
            value.IsTimeRemaining = true;
        }

        public void Add(ITimeRemaining value)
        {
            if (_timeRemainings.Contains(value))
            {
                return;
            }
            _timeRemainings.Add(value);
            value.StartTimerEventHandler += ValueOnStartTimerEventHandler;
        }

        public void Remove(ITimeRemaining value)
        {
            if (!_timeRemainings.Contains(value))
            {
                return;
            }
            _timeRemainings.Remove(value);
            value.StartTimerEventHandler -= ValueOnStartTimerEventHandler;
        }

        private void ValueOnStartTimerEventHandler(object sender, RemoveUserEventArgs e)
        {
            if (sender is ITimeRemaining obj)
            {
                obj.Time = e.Time;
                obj.IsTimeRemaining = false;
            }
        }
    }
}

using System;

namespace Geekbrains
{
    public class Timer
    {
        private DateTime _start;
        private float _elapsed = -1;

        public TimeSpan Duration { get; private set; }

        public void Start(float elapsed)
        {
            _elapsed = elapsed;
            _start = DateTime.Now;
            Duration = TimeSpan.Zero;
        }

        public void Update()
        {
            if (_elapsed > 0)
            {
                Duration = DateTime.Now - _start;

                if (Duration.TotalSeconds > _elapsed)
                {
                    _elapsed = 0;
                }
            }
            else if (_elapsed == 0)
            {
                _elapsed = -1;
            }
        }

        public bool IsEvent() => _elapsed == 0;

        public int TotalSeconds()
        {
            return (int)(_elapsed - Duration.TotalSeconds);
        }
    }
}

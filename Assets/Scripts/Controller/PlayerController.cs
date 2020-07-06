namespace Geekbrains
{
    public class PlayerController : BaseController, IOnUpdate
    {
        private IMotor _motor;

        public PlayerController(IMotor motor)
        {
            _motor = motor;
        }

        public void OnUpdate()
        {
            if (!IsActive) return;
            _motor.Move();
        }
    }
}

using UnityEngine;

namespace BOG
{
    [CreateAssetMenu(fileName = "Movement Data", menuName = "ScriptableObjects/Movements/MovementScriptableObject", order = 1)]
    public class MovementScriptableObject : ScriptableObject, IHorizontalMovement, IVerticalMovement
    {
        [SerializeField] private float speed = 3f;
        [SerializeField] private float speedBoost = 2f;

        private readonly float defaultSpeed = 3f;

        public Vector3 CalculateHorizontalMovement(float horizontal, Transform transform)
        {
            var movement = new Vector3(0f, 0f, horizontal);

            if (movement.magnitude > 0)
            {
                movement.Normalize();
                movement *= speed * Time.deltaTime;
                transform.Translate(movement, Space.World);
            }
            return movement;
        }

        public void CalculateVerticalMovement()
        {
            throw new System.NotImplementedException();
        }

        internal void SpeedIncrement()
        {
            speed += speedBoost;
        }

        internal void SpeedDecrement()
        {
            speed -= speedBoost;
        }

        internal void ResetSpeed()
        {
            speed = defaultSpeed;
        }
    }
}

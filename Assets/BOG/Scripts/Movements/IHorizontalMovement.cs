using UnityEngine;

namespace BOG
{
    public interface IHorizontalMovement
    {
        public Vector3 CalculateHorizontalMovement(float horizontal, Transform transform);
    }
}

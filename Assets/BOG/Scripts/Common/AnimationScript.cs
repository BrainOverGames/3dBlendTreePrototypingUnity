using UnityEngine;

namespace BOG
{
    public class AnimationScript : MonoBehaviour
    {
        [SerializeField] private bool isAnimated = false;
        [SerializeField] private bool isRotating = false;
        [SerializeField] private Vector3 rotationAngle;
        [SerializeField] private float rotationSpeed;

        private void Update()
        {
            if (isAnimated)
            {
                if (isRotating)
                {
                    transform.Rotate(rotationSpeed * Time.deltaTime * rotationAngle);
                }
            }
        }
    }
}

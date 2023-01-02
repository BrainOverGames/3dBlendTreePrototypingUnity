using deVoid.Utils;
using UnityEngine;

namespace BOG
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private InputScriptableObject inputScriptableObject;
        [SerializeField] private MovementScriptableObject movementScriptableObject;

        private float horizontal;
        private Vector3 movement;
        private GameStateType currentGameState;

        private const string animatorVelocityZStr = "VelocityZ";
        private const string animatorTriggerStr = "isRunning";

        protected virtual void Awake()
        {
            movementScriptableObject.ResetSpeed();
            Signals.Get<GameStateUpdatedSignal>().AddListener(OnGameStateUpdated);
        }

        private void OnDestroy()
        {
            Signals.Get<GameStateUpdatedSignal>().RemoveListener(OnGameStateUpdated);
        }

        private void OnGameStateUpdated(GameStateType gameState)
        {
            currentGameState = gameState;
        }

        protected virtual void Update()
        {
            if (currentGameState == GameStateType.Started)
            {
                horizontal = inputScriptableObject.GetHorizontalInputAxis();
                movement = movementScriptableObject.CalculateHorizontalMovement(horizontal, transform);
                UpdateAnimAccordingToVelocity();
                UpdateAnimAccordingToInputKey();
            }
        }

        private void UpdateAnimAccordingToVelocity()
        {
            float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
            animator.SetFloat(animatorVelocityZStr, velocityZ, 0.1f, Time.deltaTime);
        }

        private void UpdateAnimAccordingToInputKey()
        {
            if (Input.GetKeyDown(inputScriptableObject.RunInputKey))
            {
                animator.SetTrigger(animatorTriggerStr);
                movementScriptableObject.SpeedIncrement();
            }

            if (Input.GetKeyUp(inputScriptableObject.RunInputKey))
            {
                animator.ResetTrigger(animatorTriggerStr);
                movementScriptableObject.SpeedDecrement();
            }
        }
    }
}

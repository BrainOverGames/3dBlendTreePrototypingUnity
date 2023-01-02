using UnityEngine;

namespace BOG
{
    [CreateAssetMenu(fileName = "Input Data", menuName = "ScriptableObjects/Inputs/InputScriptableObject", order = 1)]
    public class InputScriptableObject : ScriptableObject
    {
        [SerializeField] private InputAxisType inputAxis;
        [SerializeField] private KeyCode runInputKey;

        public InputAxisType InputAxis => inputAxis;
        public KeyCode RunInputKey => runInputKey;


        public float GetHorizontalInputAxis()
        {
            if (inputAxis != InputAxisType.None)
                return Input.GetAxis(inputAxis.ToString());
            else
            {
                Debug.LogError("Please provide input axis type in inspector");
                return -1;
            }
        }
    }
}

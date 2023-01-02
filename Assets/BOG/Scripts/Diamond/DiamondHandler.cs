using UnityEngine;
using deVoid.Utils;

namespace BOG
{
    public class DiamondHandler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Signals.Get<CharacterWonNameSignal>().Dispatch(other.gameObject.name);
            Signals.Get<GameStateUpdatedSignal>().Dispatch(GameStateType.GameOver);
        }
    }
}

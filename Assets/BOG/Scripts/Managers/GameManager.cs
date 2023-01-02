using deVoid.Utils;
using UnityEngine;

namespace BOG
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameStateType currentGameStateType = GameStateType.None;

        private void Awake()
        {
            currentGameStateType = GameStateType.NotStarted;
            Signals.Get<CountdownTimerEndSingal>().AddListener(OnCountDownTimerEnd);
            Signals.Get<GameStateUpdatedSignal>().AddListener(OnGameEnded);
        }

        private void OnDestroy()
        {
            Signals.Get<CountdownTimerEndSingal>().RemoveListener(OnCountDownTimerEnd);
            Signals.Get<GameStateUpdatedSignal>().RemoveListener(OnGameEnded);
        }

        private void OnCountDownTimerEnd()
        {
            currentGameStateType = GameStateType.Started;
            Signals.Get<GameStateUpdatedSignal>().Dispatch(currentGameStateType);
        }

        private void OnGameEnded(GameStateType gameStateType)
        {
            currentGameStateType = gameStateType;
        }
    }
}

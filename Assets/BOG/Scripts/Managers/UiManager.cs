using deVoid.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BOG
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private CountdownTimer countdownTimer;
        [SerializeField] private Button restartBtn;
        [SerializeField] private Text characterWonTxt;
        [SerializeField] private Text peopleReactionTxt;

        private void Start()
        {
            characterWonTxt.gameObject.SetActive(false);
            peopleReactionTxt.gameObject.SetActive(false);
            countdownTimer.Init();
            restartBtn.onClick.AddListener(OnRestartBtnClicked);
            Signals.Get<CharacterWonNameSignal>().AddListener(OnCharacterWon);
        }

        private void OnDestroy()
        {
            countdownTimer.DeInit();
            restartBtn.onClick.RemoveListener(OnRestartBtnClicked);
            Signals.Get<CharacterWonNameSignal>().RemoveListener(OnCharacterWon);
        }

        private void OnRestartBtnClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnCharacterWon(string characterWonName)
        {
            characterWonTxt.gameObject.SetActive(true);
            peopleReactionTxt.gameObject.SetActive(true);
            characterWonTxt.text = characterWonName + "\nWINS !!!";
            peopleReactionTxt.text = "People Cheering: \n" + "BRAVO " + characterWonName;
        }
    }
}

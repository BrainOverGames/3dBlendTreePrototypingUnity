using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using deVoid.Utils;

namespace BOG
{
    public class CountdownTimer : MonoBehaviour
    {
        [SerializeField] private int countdownTime;
        [SerializeField] private Text countdownTxt;

        internal void Init()
        {
            StartCoroutine(CountdownToStart());
        }

        internal void DeInit()
        {
        }

        IEnumerator CountdownToStart()
        {
            while(countdownTime > 0)
            {
                countdownTxt.text = countdownTime.ToString();
                yield return new WaitForSeconds(1f);
                countdownTime--;
            }

            countdownTxt.text = "GO!";

            yield return new WaitForSeconds(1f);

            countdownTxt.gameObject.SetActive(false);
            Signals.Get<CountdownTimerEndSingal>().Dispatch();
        }
    }
}

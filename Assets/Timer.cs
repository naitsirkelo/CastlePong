using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Timer : MonoBehaviour {

    public TMP_Text countdown;

    int seconds = 3;

    // Start is called before the first frame update
    void Start() {
        countdown = GetComponent<TMP_Text>();
        StartCoroutine("CountDown");
    }

    IEnumerator CountDown() {
        while (seconds > -2) {
            switch (seconds) {
                case  3: countdown.text = "3";   break;
                case  2: countdown.text = "2";   break;
                case  1: countdown.text = "1";   break;
                case  0: countdown.text = "Go!"; break;
                case -1: countdown.text = "";    break;
                default: break;
            }
            yield return new WaitForSeconds(1);
            seconds--;
        }
    }
}

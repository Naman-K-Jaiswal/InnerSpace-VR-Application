using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    // Update is called once per frame

    public void SetRemainingTime(){
        remainingTime = 181;
        timerText.gameObject.SetActive(true);
    }

    void Update()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
        if (remainingTime < 0) {
            timerText.gameObject.SetActive(false);
        }
        else {
            remainingTime -= Time.deltaTime;
        }
    }
}

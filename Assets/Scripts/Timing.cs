using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timing : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown chooseDropdown;
    public InputField hoursInputField;
    public InputField minutesInputField;
    public InputField secondsInputField;
    public Text countdownText;
    private AudioSource audio;
    public Button entryButton;
    public Button cancelButton;
    private float totalTime;
    private float timeRemaining;
    private bool isCountingDown = false;
    private int hours;
    private int minutes;
    private int seconds;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        hoursInputField.gameObject.SetActive(false);
        minutesInputField.gameObject.SetActive(false);
        secondsInputField.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(false);
        entryButton.gameObject.SetActive(false);
        cancelButton.gameObject.SetActive(false);
        if (chooseDropdown.value == 0&&isCountingDown == false)
        {
            hoursInputField.gameObject.SetActive(true);
            minutesInputField.gameObject.SetActive(true);
            secondsInputField.gameObject.SetActive(true);
            entryButton.gameObject.SetActive(true);
            hoursInputField.text = "0";
            minutesInputField.text = "0";
            secondsInputField.text = "0";
        }
        else if(chooseDropdown.value !=0)
        {
            hoursInputField.gameObject.SetActive(false);
            minutesInputField.gameObject.SetActive(false);
            secondsInputField.gameObject.SetActive(false);
            countdownText.gameObject.SetActive(false);
            entryButton.gameObject.SetActive(false);
            cancelButton.gameObject.SetActive(false);
        }
        entryButton.onClick.AddListener(enterTime);
        cancelButton.onClick.AddListener(cancelTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (chooseDropdown.value == 0&&isCountingDown == false)
        {
            hoursInputField.gameObject.SetActive(true);
            minutesInputField.gameObject.SetActive(true);
            secondsInputField.gameObject.SetActive(true);
            entryButton.gameObject.SetActive(true);
            countdownText.gameObject.SetActive(false);
            cancelButton.gameObject.SetActive(false);
        }
        else if(chooseDropdown.value !=0)
        {
            hoursInputField.gameObject.SetActive(false);
            minutesInputField.gameObject.SetActive(false);
            secondsInputField.gameObject.SetActive(false);
            countdownText.gameObject.SetActive(false);
            entryButton.gameObject.SetActive(false);
            cancelButton.gameObject.SetActive(false);
        }

        if (isCountingDown)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                StartCoroutine(PlaySoundCoroutine());
                isCountingDown = false;
                timeRemaining = 0;
            }
            else
            {
                int hoursRemaining = (int)(timeRemaining / 3600);
                int minutesRemaining = (int)((timeRemaining % 3600) / 60);
                int secondsRemaining = (int)(timeRemaining % 60);
                countdownText.text = string.Format("{0:00}:{1:00}:{2:00}", hoursRemaining, minutesRemaining, secondsRemaining);
            }
        }
        
    }




    private void enterTime()
    {
        isCountingDown = true;
        int hours = int.Parse(hoursInputField.text);
        int minutes = int.Parse(minutesInputField.text);
        int seconds = int.Parse(secondsInputField.text);
        // Debug.Log(hoursInputField.text+":"+minutesInputField.text+":"+secondsInputField.text);
        // Debug.Log(hours+":"+minutes+":"+seconds);
        hoursInputField.gameObject.SetActive(false);
        minutesInputField.gameObject.SetActive(false);
        secondsInputField.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(true);
        entryButton.gameObject.SetActive(false);
        cancelButton.gameObject.SetActive(true);
        totalTime = hours * 3600 + minutes * 60 + seconds;
        timeRemaining = totalTime;
        
    }

    private void cancelTime()
    {
        isCountingDown = false;
    }
    IEnumerator PlaySoundCoroutine()
    {
        audio.Play();

        yield return new WaitForSeconds(4f);

        audio.Stop();
    }
}

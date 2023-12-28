using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainButton : MonoBehaviour
{
    public Canvas canvas;

    public Canvas mood;

    public Canvas healthy;

    public Canvas favor;

    public Canvas energy;

    public Button entryButton;

    public Button moodButton;

    public Button healthyButton;

    public Button favorButton;

    public Button energyButton;

    public Button closeButton;

    private bool isOpen = true;
    // Start is called before the first frame update
    void Start()
    {
        entryButton.onClick.AddListener(showCanvas);
        moodButton.onClick.AddListener(showMood);
        // healthyButton.onClick.AddListener(showHealthy);
        favorButton.onClick.AddListener(showFavor);
        energyButton.onClick.AddListener(showEnergy);
        closeButton.onClick.AddListener(closeCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void showCanvas()
    {
        Debug.Log("open UI");
        canvas.gameObject.SetActive(isOpen);
        isOpen = !isOpen;
        mood.gameObject.SetActive(false);
        favor.gameObject.SetActive(false);
        energy.gameObject.SetActive(false);
    }

    private void showMood()
    {
        Debug.Log("open Mood");
        mood.gameObject.SetActive(true);
        favor.gameObject.SetActive(false);
        energy.gameObject.SetActive(false);
    }

    private void showHealthy()
    {
        Debug.Log("open Healthy");
        mood.gameObject.SetActive(false);
        favor.gameObject.SetActive(false);
        energy.gameObject.SetActive(false);
    }

    private void showFavor()
    {
        Debug.Log("open Favor");
        mood.gameObject.SetActive(false);
        favor.gameObject.SetActive(true);
        energy.gameObject.SetActive(false);
    }

    private void showEnergy()
    {
        Debug.Log("open Energy");
        mood.gameObject.SetActive(false);
        favor.gameObject.SetActive(false);
        energy.gameObject.SetActive(true);
    }

    private void closeCanvas()
    {
        Debug.Log("close");
        canvas.gameObject.SetActive(false);
        mood.gameObject.SetActive(false);
        favor.gameObject.SetActive(false);
        energy.gameObject.SetActive(false);
        isOpen = !isOpen;
    }
}

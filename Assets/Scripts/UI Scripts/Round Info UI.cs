using TMPro;
using UnityEngine;

public class RoundInfoUI : MonoBehaviour
{
    TextMeshProUGUI timerText;

    TextMeshProUGUI phaseText;

    RoundManager roundManager;

    private void Start() 
    {
        roundManager = GameObject.Find("Round Manager").GetComponent<RoundManager>();
        timerText = GameObject.Find("Timer Text").GetComponent<TextMeshProUGUI>();
        phaseText = GameObject.Find("Round Phase Text").GetComponent<TextMeshProUGUI>();
    }

    private void Update() 
    {
        string currentPhase = roundManager.getRoundPhase().ToString();
        float currentTimer = roundManager.getPhaseTimer();
        timerText.text = "Time Left: " + (int) currentTimer;
        phaseText.text = "Phase: " + currentPhase;
    }
}

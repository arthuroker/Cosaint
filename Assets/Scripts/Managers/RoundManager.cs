using UnityEngine;

public class RoundManager : MonoBehaviour
{

    private RoundPhase roundPhase;
    private int currentRound = 0;
    private float phaseTimer;

    public float shopPhaseDuration = 30f;
    public float roundOverDuration = 10f;


    public RoundPhase getCurrentRoundPhase() => roundPhase;
    public int getCurrentRound() => currentRound;
    public float getPhaseTimer() => phaseTimer;

    public enum RoundPhase
    {
        ShopPhase,
        EnemiesSpawning,
        EnemiesNoLongerSpawning,
        RoundOver,
        GameOver
    }


    public void setRoundPhase(RoundPhase roundPhase)
    {
        this.roundPhase = roundPhase;

           switch (roundPhase)
        {
            case RoundPhase.ShopPhase:
                phaseTimer = shopPhaseDuration;
                break;

            case RoundPhase.EnemiesSpawning:
                break;

            case RoundPhase.EnemiesNoLongerSpawning:
                phaseTimer = 0;
                break;

            case RoundPhase.RoundOver:
                Debug.Log($"Round {currentRound} is over!");
                break;

            case RoundPhase.GameOver:
                Debug.Log("Game Over!");
                break;
        }
    }

    public void setCurrentRound(int round) => currentRound = round;


    public void goToNextRound()
    {
        currentRound++;
        setRoundPhase(RoundPhase.ShopPhase);
        phaseTimer = shopPhaseDuration;
    }

    public void AdvancePhase()
    {
        switch (roundPhase)
        {
            case RoundPhase.ShopPhase:
                setRoundPhase(RoundPhase.EnemiesSpawning);
                break;

            case RoundPhase.EnemiesSpawning:
                setRoundPhase(RoundPhase.EnemiesNoLongerSpawning);
                break;

            case RoundPhase.EnemiesNoLongerSpawning:
                setRoundPhase(RoundPhase.RoundOver);
                phaseTimer = roundOverDuration;
                break;

            case RoundPhase.RoundOver:
                goToNextRound();
                break;
        }
    }



    private void Start() 
    {
        setRoundPhase(RoundPhase.ShopPhase);
        setCurrentRound(1);
    }

    private void Update()
    {

     if (roundPhase == RoundPhase.ShopPhase || roundPhase == RoundPhase.RoundOver)
     {
        phaseTimer -= Time.deltaTime;
       
        if (phaseTimer <= 0)
        {
            AdvancePhase();
        }
     }
    }

    



}

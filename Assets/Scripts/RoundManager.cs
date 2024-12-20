using UnityEngine;

public class RoundManager : MonoBehaviour
{

    private RoundPhase roundPhase;
    private int currentRound = 0;
    private float phaseTimer;

    public float shopPhaseDuration = 30f;
    public float enemySpawnDuration = 60f;


    public RoundPhase GetRoundStatus() => roundPhase;
    public int GetCurrentRound() => currentRound;
    public float GetPhaseTimer() => phaseTimer;

    public enum RoundPhase
    {
        ShopPhase,
        EnemiesSpawning,
        EnemiesNoLongerSpawning,
        RoundOver
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
                phaseTimer = enemySpawnDuration;
                //Something that Spawns Enemies
                break;

            case RoundPhase.EnemiesNoLongerSpawning:
                phaseTimer = 0;
                break;

            case RoundPhase.RoundOver:
                Debug.Log($"Round {currentRound} is over!");
                break;
        }
    }


    public void goToNextRound()
    {
        currentRound++;
        setRoundPhase(RoundPhase.ShopPhase);
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
                break;

            case RoundPhase.RoundOver:
                goToNextRound();
                break;
        }
    }

    private void Update()
    {

     if (roundPhase == RoundPhase.ShopPhase || roundPhase == RoundPhase.EnemiesSpawning)
     {
        phaseTimer -= Time.deltaTime;
       
        if (phaseTimer <= 0)
        {
            AdvancePhase();
        }
    }
}



}

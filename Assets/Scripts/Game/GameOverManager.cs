using System;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Health fighterOneHealth;
    [SerializeField] private Health fighterTwoHealth;

    public bool IsGameOver { get; private set; }
    
    public FighterID WinnerID { get; private set; }
    
    public event Action OnGameOver;
    
    private void OnEnable()
    {
        fighterOneHealth.OnDied += OnOneDied;
        fighterTwoHealth.OnDied += OnTwoDied;
    }

    private void OnDisable()
    {
        fighterOneHealth.OnDied -= OnOneDied;
        fighterTwoHealth.OnDied -= OnTwoDied;
    }

    private void OnOneDied(DeathArgs obj)
    {
        FighterID winnerID = fighterTwoHealth.GetComponent<FighterIdentifier>().FighterID;
        SetGameOver(winnerID);
    }
    
    private void OnTwoDied(DeathArgs obj)
    {
        FighterID winnerID = fighterOneHealth.GetComponent<FighterIdentifier>().FighterID;
        SetGameOver(winnerID);
    }

    private void SetGameOver(FighterID winnerID)
    {
        print("winner: " + winnerID);
        
        fighterOneHealth.OnDied -= OnOneDied;
        fighterTwoHealth.OnDied -= OnTwoDied;

        IsGameOver = true;
        WinnerID = winnerID;
        OnGameOver?.Invoke();
    }    
}

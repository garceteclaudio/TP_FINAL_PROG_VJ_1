using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //Aplicar patrón de Singleton para llevar el conteo de puntos.
    public static ScoreManager Instance { get; private set; }

    private int score;

    private void Awake()
    { 
        Instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Puntuación actual: " + score);
    }

    public int GetScore()
    {
        return score;
    }
}

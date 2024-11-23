using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //Aplicar patr�n de Singleton para llevar el conteo de puntos.
    public static ScoreManager Instance { get; private set; }

    private int score;

    private void Awake()
    { 
        Instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Puntuaci�n actual: " + score);
    }

    public int GetScore()
    {
        return score;
    }
}

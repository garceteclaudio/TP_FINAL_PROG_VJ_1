using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractionManager : MonoBehaviour
{
    public int requiredScore = 50;
    public GameObject zone;
    private EndingManager endingManager;

    private void Start()
    {
        endingManager = GetComponent<EndingManager>();

        //Iniciar la coroutine que eventualmente activará la zona de extracción.
        StartCoroutine(CheckScoreAndActivateZone());
    }

    private IEnumerator CheckScoreAndActivateZone()
    {
        while (true)
        {
            int currentScore = ScoreManager.Instance.GetScore();

            //Comprobar si el jugador ha alcanzado el puntaje requerido.
            if (currentScore >= requiredScore)
            {
                //En caso de haber alcanzado el puntaje habilitar la zona.
                zone.SetActive(true);

                //Llamar al método para mostrar los objetos del punto de extracción.
                endingManager.CheckEndGameConditions(currentScore, true);

                yield break;
            }
            else
            {
                //En caso de no haber alcanzado el puntaje mostrar un mensaje.
                Debug.Log("SOLDADO: (por radio) -Aquí Sombra Nueve, solicito extracción inmediata en la zona establecida. Cambio...");
            }

            yield return new WaitForSeconds(15f);
        }
    }
}

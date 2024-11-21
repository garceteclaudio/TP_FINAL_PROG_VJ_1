using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public Transform position1;
    public Transform position2;

    private void Start()
    {
        object1.SetActive(false);
        object2.SetActive(false);
    }

    public void CheckEndGameConditions(int score, bool isZoneActive)
    {
        //Verificar si se han alcanzado las condiciones para mostrar el helicóptero.
        if (score >= 50 && isZoneActive)
        {
            ShowEndGameObjects();
        }
    }

    private void ShowEndGameObjects()
    {
        //Métodos para mostrar el helicóptero y la cuerda en el mapa.
        object1.SetActive(true);
        object2.SetActive(true);

        object1.transform.position = position1.position;
        object2.transform.position = position2.position;

        Debug.Log("CONDUCTOR: (por radio) -Aquí Bravo Seis a Sombra Nueve, hemos llegado a la zona de extracción. Cambio.");
    }
}

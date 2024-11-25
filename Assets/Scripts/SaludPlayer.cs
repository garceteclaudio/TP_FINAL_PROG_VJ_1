using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaludPlayer : MonoBehaviour
{
    public float salud = 100;
    public float saludMax = 100;

    public Image BarraSalud;
    public Text TextoSalud;
    // Update is called once per frame
    void Update()
    {
        ActualizarInterfaz();
    }
    public void RecibirDa�o(float da�o)
    {
        salud -= da�o;
    }
    void ActualizarInterfaz()
    {
        BarraSalud.fillAmount = salud / saludMax;
        TextoSalud.text = "+ " + salud.ToString("f0");
    }
}

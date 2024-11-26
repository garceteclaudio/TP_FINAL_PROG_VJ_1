using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int maxImpactos;
    public Animator animator;
    public float tiempoDestruccion;

    public int impactosRecibidos;

    void Start()
    {
        Transform bossTransform = this.transform;
        bossTransform.position = new Vector3(bossTransform.position.x, 0f, bossTransform.position.z);
        animator = GetComponent<Animator>();
    }

    public void RecibirImpacto(bool isShot)
    {
        impactosRecibidos++;
        Debug.Log("Impactos recibidos por el Boss: " + impactosRecibidos);

        if (impactosRecibidos >= maxImpactos)
        {
            animator.SetTrigger("isDead");
            StartCoroutine(DestruirDespuesDeTiempo(tiempoDestruccion));
        }
    }

    IEnumerator DestruirDespuesDeTiempo(float tiempo)
    {
        Debug.Log("Iniciando corrutina para destruir el Boss después de " + tiempo + " segundos.");
        yield return new WaitForSeconds(tiempo);
        Debug.Log("Derrotamos al Boss.");
        Destroy(gameObject);
        SceneManager.LoadScene("Victoria");
    }
}





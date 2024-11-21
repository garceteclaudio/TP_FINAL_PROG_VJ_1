using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAnimator : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //Método para actualizar la animación de movimiento del soldado.
    public void UpdateMovementAnimation(float speed)
    {
        animator.SetFloat("Speed", speed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed = 5f;//velocidad de movimiento
    private Vector2 movement;//Vector2 direccion en la que vamos a trasladarnos
    private Rigidbody2D rb;//Referencia al controlador de personaje
    private Animator animator;
    private bool quieto = true;
    private bool horizontal = false;
    private bool vertical = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//Buscamos la referencia
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtener la entrada del jugador
        movement.x = Input.GetAxisRaw("Horizontal");//Verificamos las teclas si se estan precionando las horizontales
        movement.y = Input.GetAxisRaw("Vertical");//verificamos las teclas si se estan precionando las verticales
        animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));//Seteamos la variable vertical de tipo float con la direccion vertical que va entre -1 y 1
        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));//Seteamos la variable horizontal de tipo float con la direccion horizontal que va entre -1 y 1
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)//comprobamos si la direccion vertical y horizontal estan en 0 para saber que no se esta moviendo el personaje
            quieto = true;
        else
            quieto = false;
        animator.SetBool("quieto", quieto);//le indicamos al animator si el persoanje se esta moviendo o no

        if(Input.GetAxisRaw("Vertical") != 0)//determinamos si se esta moviendo en alguna direccion vertical o no
            vertical = true;
        else
            vertical = false;

        if(Input.GetAxisRaw("Horizontal") != 0)//determinamso si se esta moviendo en alguna direccion horizontal o no
            horizontal = true;
        else horizontal = false;

        animator.SetBool("hori", horizontal);
        animator.SetBool("Ver", vertical);
    }

    void FixedUpdate()
    {
        // Mover al jugador
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);//movemos al personaje segun las teclas apretadas la velocidad y el time delta time
    }
}

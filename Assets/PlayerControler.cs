using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed = 5f;//velocidad de movimiento
    private Vector2 movement;//Vector2 direccion en la que vamos a trasladarnos
    private Rigidbody2D rb;//Referencia al controlador de personaje

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//Buscamos la referencia
    }

    void Update()
    {
        // Obtener la entrada del jugador
        movement.x = Input.GetAxisRaw("Horizontal");//Verificamos las teclas si se estan precionando las horizontales
        movement.y = Input.GetAxisRaw("Vertical");//verificamos las teclas si se estan precionando las verticales
    }

    void FixedUpdate()
    {
        // Mover al jugador
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);//movemos al personaje segun las teclas apretadas la velocidad y el time delta time
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    private Animator anim;
    public Jugador scriptJugador;

    // Update is called once per frame
    private void Update()
    {
        anim = GetComponent<Animator>();
        scriptJugador = GetComponent<Jugador>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        //corre animacion de desaparecer sprite
        anim.SetTrigger("IsDeath");
        //corre funcion de stop que detiene la velocidad del jugador 
        stop();
        //invoca la funcion de volver a carga la escena despues de tal segundos
        Invoke("ReloadScene", 2);
    }

    private void stop()
    {
        scriptJugador.velocidad = 0;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

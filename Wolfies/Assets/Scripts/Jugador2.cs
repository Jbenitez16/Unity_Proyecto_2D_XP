using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador2 : MonoBehaviour
{
    
    private void Awake()
    {
        Awake_movimiento();
        obtenerComponentes();
    }

    // Update is called once per frame
    private void Update()
    {
        //siempre debe estar en el update para que la responsividad no tenga lag
        SensorPiso(); 
        LeerAxis();
        Update_Movimiento();
    }

    // este metodo se ejecuta 50 veces por segundo
    private void FixedUpdate()
    {
        FixedUpdate_Movimiento();
    }

    #region Componentes

    private Rigidbody2D rb;
    private Animator animator;

    private void obtenerComponentes()
    {
        //obtenemos el componente de Rigidbody del miosmo objeto donde esta la script
        rb = GetComponent<Rigidbody2D>();
        
        //obtenemos el hijo 0(1 de herarquia)
        Transform hijo = transform.GetChild(0);
        animator = hijo.GetComponent<Animator>();
    }


    #endregion


    //SerializedField sirve para mostrar el atrivuto en el editor, sin volverlo public
    [SerializeField] private float velocidad;
    [SerializeField] private float fuerzaSalto = 5;

    private float axisX;
    private Quaternion rotacionDerecha;
    private Quaternion rotacionIzquierda;

    private void Awake_movimiento()
    {
        //Vector3.zero = new Vector(0,0,0);
        rotacionDerecha = Quaternion.Euler(Vector3.zero);
        rotacionIzquierda = Quaternion.Euler(new Vector3(0, 180, 0));

    }
    private void LeerAxis()
    {
        //leemos el axiss
        axisX = Input.GetAxis("Horizontal_2");

    }

    private void Update_Movimiento()
    { 
        //si se presiona la tecla Space
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (enPiso)
            {
                //Vector.up = new Vector3(0,1)           
                Vector2 fuerza = Vector2.up * fuerzaSalto;

                rb.AddForce(fuerza, ForceMode2D.Impulse);
                Saltando = true;
            }
        }
    }


    private void FixedUpdate_Movimiento()
    {
        //hay movimiento
        if (axisX != 0)
        {
            //rotamos el player segun su axis
            transform.rotation = axisX > 0 ? rotacionDerecha : rotacionIzquierda;

            //obtenemos el movimiento
            float movX = axisX * velocidad * Time.fixedDeltaTime;

            //le pasamos a un vector
            Vector3 mov = new Vector2(movX, 0);

            //le sumamos el movimiento a la posicion actual      
            transform.position += mov;

            //animator.SetBool("Moviendose", true);
        }

        //no hay movimiento
        else
        {
            //animator.SetBool("Moviendose", false);
        }
    }

    [SerializeField] private Vector2 sensorPiso_tamaño;
    private bool enPiso = false;
    private bool Saltando = false;

    private void SensorPiso()
    {

        Vector2 centro = transform.position;
        Vector2 tamaño = sensorPiso_tamaño;
        LayerMask capa = LayerMask.GetMask("Default");
        var box = Physics2D.OverlapBoxAll(centro, tamaño, 0, capa);

        if (box.Length > 0)
        {
            enPiso = true;
        }
        else
        {
            enPiso = false;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = enPiso ? Color.yellow : Color.black;
        Gizmos.DrawWireCube(transform.position, sensorPiso_tamaño);
    }

}
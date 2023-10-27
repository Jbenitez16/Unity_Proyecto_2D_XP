using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonWolfie : MonoBehaviour
{
    public GameObject plataforma;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Se activo un nuevo objeto");
        plataforma.SetActive(true);
    }
}

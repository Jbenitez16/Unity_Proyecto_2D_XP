using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnCollideWithPlayer : MonoBehaviour
{
    public GameObject objeto;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{objeto.name} activado");
        objeto.SetActive(true);
    }
}

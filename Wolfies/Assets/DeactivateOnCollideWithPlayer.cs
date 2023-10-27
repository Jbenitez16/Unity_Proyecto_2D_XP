using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnCollideWithPlayer : MonoBehaviour
{
    public GameObject objeto;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{objeto.name} desactivado!");
            objeto.SetActive(false);
        }
    }
}

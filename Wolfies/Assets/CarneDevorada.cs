using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarneDevorada : MonoBehaviour
{
    public GameObject carne;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Carne Devorada!");
            carne.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jogador entrou na área de interação!");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
            {
                // Aqui você pode adicionar a lógica para interação com o jogador
                Debug.Log("Interagindo com o jogador!");
            }
    }

  private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Aqui você pode adicionar a lógica para quando o jogador sai da área de interação
            Debug.Log("Jogador saiu da área de interação!");
        }
    }
}

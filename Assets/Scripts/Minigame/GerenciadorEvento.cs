using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorEvento : MonoBehaviour
{
    public static event Action<int> AoClicarBotao;
    [SerializeField] private Canvas canvas;
    private float tempoEspera = 3f; // Tempo antes de reativar o Canvas

    public static void DispararEvento(int numeroDoBotao)
    {
        AoClicarBotao?.Invoke(numeroDoBotao);
    }

    private void AoClicarNoBotao()
    {
        Debug.Log("Método AoClicarNoBotao foi chamado."); // Log para depuração
        StartCoroutine(ExecutarAnimacao());
    }

    private IEnumerator ExecutarAnimacao()
    {
        // Desativar a visualização do Canvas
        if (canvas != null)
        {
            Debug.Log("Desativando o Canvas."); // Log para depuração
            canvas.enabled = false;
        }
        else
        {
            Debug.LogWarning("Canvas não está atribuído no Inspector."); // Log de aviso
        }

        // Esperar um tempo antes de reativar o Canvas
        yield return new WaitForSeconds(tempoEspera);

        // Reativar o Canvas
        if (canvas != null)
        {
            Debug.Log("Reativando o Canvas."); // Log para depuração
            canvas.enabled = true;
        }
    }
}
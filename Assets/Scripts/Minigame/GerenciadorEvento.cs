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
}
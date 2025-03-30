using System;
using UnityEngine;

public class GerenciadorEvento : MonoBehaviour
{
    public static event Action<int> AoClicarBotao;

    public static void DispararEvento(int numeroDoBotao)
    {
        AoClicarBotao?.Invoke(numeroDoBotao);
    }
}
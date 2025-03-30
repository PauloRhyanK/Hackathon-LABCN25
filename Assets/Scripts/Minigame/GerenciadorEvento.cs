using System;
using UnityEngine;

public class GerenciadorEvento : MonoBehaviour
{
    // Criamos um evento que passa o botão pressionado
    public static event Action<string> AoClicarBotao; // Passa o nome do botão

    // Função que dispara o evento, agora com o nome do botão
    public static void DispararEvento(string nomeBotao)
    {
        AoClicarBotao?.Invoke(nomeBotao);
    }
}
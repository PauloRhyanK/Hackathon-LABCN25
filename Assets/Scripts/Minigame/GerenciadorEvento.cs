using System;
using UnityEngine;

public class GerenciadorEvento : MonoBehaviour
{
    // Criamos um evento que passa o bot�o pressionado
    public static event Action<string> AoClicarBotao; // Passa o nome do bot�o

    // Fun��o que dispara o evento, agora com o nome do bot�o
    public static void DispararEvento(string nomeBotao)
    {
        AoClicarBotao?.Invoke(nomeBotao);
    }
}
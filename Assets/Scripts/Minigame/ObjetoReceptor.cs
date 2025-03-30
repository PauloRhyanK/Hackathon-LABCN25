using UnityEngine;

public class ObjetoReceptor : MonoBehaviour
{
    void OnEnable()
    {
        GerenciadorEvento.AoClicarBotao += ReagirAoClique;
    }

    void OnDisable()
    {
        GerenciadorEvento.AoClicarBotao -= ReagirAoClique;
    }

    void ReagirAoClique(string nomeBotao)
    {
        if (nomeBotao == "Botao1")
        {
            Debug.Log(gameObject.name + " reagiu ao Botão 1!");
        }
        else if (nomeBotao == "Botao2")
        {
            Debug.Log(gameObject.name + " reagiu ao Botão 2!");
        }
        else if (nomeBotao == "Botao3")
        {
            Debug.Log(gameObject.name + " reagiu ao Botão 3!");
        }
    }
}
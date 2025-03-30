using UnityEngine;
using UnityEngine.UI;

public class BotaoArvore : MonoBehaviour
{
    public Button botao;
    public string nomeBotao;

    void Start()
    {
        botao.onClick.AddListener(QuandoClicar);
    }

    void QuandoClicar()
    {
        GerenciadorEvento.DispararEvento(nomeBotao);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class BotaoArvore : MonoBehaviour
{
    [SerializeField] private int numeroDoBotao;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(QuandoClicar);
    }

    void QuandoClicar()
    {
        GerenciadorEvento.DispararEvento(numeroDoBotao, gameObject);
        gameObject.SetActive(false);
        // GerenciadorEvento.ContarBotoes();
    }
}

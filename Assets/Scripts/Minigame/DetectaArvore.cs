using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectaArvore : MonoBehaviour
{
    [SerializeField] private GameObject modeloArvore;
    [SerializeField] private int numeroDoModelo;
    [SerializeField] private Transform objetoLocalizacoes;
    [SerializeField] private GameObject panel;
    private List<Transform> listaPontos = new List<Transform>();
    private List<GameObject> listaPrefabs = new List<GameObject>();
    private bool arvoreFoiColocada;
    [SerializeField] private GameObject objetoEvento;
    [SerializeField] private float tempoInicial, tempoFinal;
    private string textoEvento;

    private void Start()
    {
        arvoreFoiColocada = false;
        switch (numeroDoModelo)
        {
            case 1:
                textoEvento = "Com a Auracaria, o Galha-Azul desperta em voo, um hino à biodiversidade que renova a vida...";
                break;
            case 2:
                textoEvento = "Na sombra da Casuarina, a chuva se faz prece, purificando o rio e firmando a terra";
                break;
            case 3:
                textoEvento = "A Faia inspira o céu: ar limpo, brisa suave, um abraço que transforma o calor em calma.";
                break;
        }
        foreach (Transform filho in objetoLocalizacoes)
        {
            listaPontos.Add(filho);
        }
    }

    private IEnumerator EventoArvores()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            ToastNotification.Show(textoEvento, 7);
            if (objetoEvento != null)
            {
                objetoEvento.SetActive(true);
                var scriptsEvento = objetoEvento.GetComponents<IScriptEvento>();
                foreach (var scriptEvento in scriptsEvento)
                {
                    if (scriptEvento != null)
                    {
                        yield return scriptEvento.ExecutarEvento();
                    }
                }
            }
            if (numeroDoModelo == 1)
            {
                yield return new WaitForSeconds(7);
            }
            panel.SetActive(true);
            GerenciadorEvento.ContarBotoes();
        }
    }

    void OnEnable()
    {
        GerenciadorEvento.AoClicarBotao += ReagirAoClique;
    }

    void OnDisable()
    {
        GerenciadorEvento.AoClicarBotao -= ReagirAoClique;
    }

    void ReagirAoClique(int numeroDoBotao, GameObject botaoClicado)
    {
        if (numeroDoBotao == numeroDoModelo && !arvoreFoiColocada)
        {
            foreach (Transform ponto in listaPontos)
            {
                GameObject arvoreColocada = Instantiate(modeloArvore, ponto.position, Quaternion.identity);
                arvoreColocada.transform.SetParent(ponto);
                listaPrefabs.Add(arvoreColocada);
            }
            arvoreFoiColocada = true;
            StartCoroutine(EventoArvores());
        }
    }
}

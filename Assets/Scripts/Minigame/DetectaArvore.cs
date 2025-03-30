using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class DetectaArvore : MonoBehaviour
{
    [SerializeField] private GameObject modeloArvore;
    [SerializeField] private int numeroDoModelo;
    [SerializeField] private Transform objetoLocalizacoes;
    [SerializeField] private GameObject caixaDeAlerta;
    [SerializeField] private TMP_Text textoAlerta;

    private List<Transform> listaPontos = new List<Transform>();
    private List<GameObject> listaPrefabs = new List<GameObject>();
    private bool arvoreFoiColocada;
    [SerializeField] private GameObject objetoEvento;
    [SerializeField] private float tempoInicial, tempoFinal;
    private string textoEvento;

    private void Start()
    {
        caixaDeAlerta.SetActive(false);
        arvoreFoiColocada = false;
        switch(numeroDoModelo){
            case 1:
                textoEvento = "Chuva";
            break;
            case 2:
                textoEvento = "Terremoto";
            break;
        }
        objetoEvento.SetActive(false);
        foreach (Transform filho in objetoLocalizacoes)
        {
            listaPontos.Add(filho);
        }
    }

    private IEnumerator EventoArvores(){
        yield return new WaitForSeconds(2);
        caixaDeAlerta.SetActive(true);
        textoAlerta.text = "O evento de " + textoEvento + " está prestes a acontecer";
        yield return new WaitForSeconds(tempoInicial);
        caixaDeAlerta.SetActive(false);
        textoAlerta.text = "";
        objetoEvento.SetActive(true);
        yield return new WaitForSeconds(tempoFinal);
        objetoEvento.SetActive(false);
    }


    void OnEnable()
    {
        GerenciadorEvento.AoClicarBotao += ReagirAoClique;
    }

    void OnDisable()
    {
        GerenciadorEvento.AoClicarBotao -= ReagirAoClique;
    }

    void ReagirAoClique(int numeroDoBotao)
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
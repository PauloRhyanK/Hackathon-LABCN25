using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorEvento : MonoBehaviour
{
    public static event Action<int, GameObject> AoClicarBotao;
    private static int botoesClicados = 0;
    [SerializeField] private GameObject imagemFinal;
    [SerializeField] private GameObject panel;

    public static void DispararEvento(int numeroDoBotao, GameObject botao)
    {
        AoClicarBotao?.Invoke(numeroDoBotao, botao);
    }

    private void OnEnable()
    {
        botoesClicados = 0;
        if (imagemFinal != null)
        {
            imagemFinal.SetActive(false);
        }
    }

    public static void ContarBotoes()
    {
        botoesClicados++;
        if (botoesClicados >= 3)
        {
            GameObject.FindObjectOfType<GerenciadorEvento>().MostrarImagemFinal();
        }
    }

    private void MostrarImagemFinal()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
        if (imagemFinal != null)
        {
            imagemFinal.SetActive(true);
        }
    }
}

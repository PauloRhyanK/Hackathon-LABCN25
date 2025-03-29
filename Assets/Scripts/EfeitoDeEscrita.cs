using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EfeitoDeEscrita : MonoBehaviour
{
    [SerializeField] private float velocidadeDeEscrita = 50f;
    public Coroutine Rodar(string textoParaEscrever, TMP_Text areaDoTexto){
        return StartCoroutine(TypeText(textoParaEscrever, areaDoTexto));
    }

    private IEnumerator TypeText(string textoParaEscrever, TMP_Text areaDoTexto){
        areaDoTexto.text = string.Empty;
        yield return new WaitForSeconds(1);

        float t = 0;
        int indiceLetra = 0;

        while(indiceLetra < textoParaEscrever.Length){
            t += Time.deltaTime * velocidadeDeEscrita;

            indiceLetra = Mathf.FloorToInt(t);
            indiceLetra = Mathf.Clamp(indiceLetra, 0, textoParaEscrever.Length);

            areaDoTexto.text = textoParaEscrever.Substring(0, indiceLetra);

            yield return null;
        }

        areaDoTexto.text = textoParaEscrever;
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

public class GerirResposta : MonoBehaviour
{
    [SerializeField] private RectTransform caixaDeResposta;
    [SerializeField] private RectTransform modeloBotaoResposta;
    [SerializeField] private RectTransform containerResposta;
    private DialogoUI dialogoUI;
    List<GameObject> tempBotaoResposta = new List<GameObject>();

    private void Start()
    {
        dialogoUI = GetComponent<DialogoUI>();
    }

    public void MostrarRespostas(Resposta[] respostas){
        float alturaCaixaDeResposta = 0;
        float larguraExtra = 0;
        modeloBotaoResposta.gameObject.SetActive(false);
        foreach(Resposta resposta in respostas){

            GameObject botaoResposta = Instantiate(modeloBotaoResposta.gameObject, containerResposta);
            botaoResposta.SetActive(true);
            botaoResposta.GetComponent<TMP_Text>().text = resposta.TextoResposta;
            larguraExtra = (resposta.TextoResposta.Length / 10) * 160;
            botaoResposta.GetComponent<Button>().onClick.AddListener(() => EscolherResposta(resposta));

            tempBotaoResposta.Add(botaoResposta);

            alturaCaixaDeResposta += modeloBotaoResposta.sizeDelta.y;
        }
        

        caixaDeResposta.sizeDelta = new Vector2(caixaDeResposta.sizeDelta.x + larguraExtra, alturaCaixaDeResposta);
        caixaDeResposta.gameObject.SetActive(true);
    }

    private void EscolherResposta(Resposta resposta){
        caixaDeResposta.gameObject.SetActive(false);

        foreach(GameObject button in tempBotaoResposta){
            Destroy(button);
        }
        tempBotaoResposta.Clear();
        dialogoUI.MostrarDialogo(resposta.ObjetoDialogo);
    }
}

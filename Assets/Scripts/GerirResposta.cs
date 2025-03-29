using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GerirResposta : MonoBehaviour
{
    [SerializeField] private RectTransform caixaDeResposta;
    [SerializeField] private RectTransform modeloBotaoResposta;
    [SerializeField] private RectTransform containerResposta;

    public void MostrarRespostas(Resposta[] respostas){
        float alturaCaixaDeResposta = 0;

        foreach(Resposta resposta in respostas){
            GameObject botaoResposta = Instantiate(modeloBotaoResposta.gameObject, containerResposta);
            botaoResposta.gameObject.SetActive(true);
            botaoResposta.GetComponent<TMP_Text>().text = resposta.TextoResposta;
            botaoResposta.GetComponent<Button>().onClick.AddListener(() => EscolherResposta(resposta));

            alturaCaixaDeResposta += modeloBotaoResposta.sizeDelta.y;
        }

        caixaDeResposta.sizeDelta = new Vector2(caixaDeResposta.sizeDelta.x, alturaCaixaDeResposta);
        caixaDeResposta.gameObject.SetActive(true);
    }

    private void EscolherResposta(Resposta resposta){

    }
}

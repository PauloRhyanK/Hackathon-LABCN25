using System.Collections;
using UnityEngine;
using TMPro;

public class DialogoUI : MonoBehaviour
{
    [SerializeField] private GameObject caixaDeDialogo;
    [SerializeField] private TMP_Text areaDoTexto;
    public bool estaAberto { get; private set; }
    private GerirResposta gerirResposta;

    private EfeitoDeEscrita efeitoDeEscrita;
    private void Start()
    {
        efeitoDeEscrita = GetComponent<EfeitoDeEscrita>();
        gerirResposta = GetComponent<GerirResposta>();
        FecharCaixaDeDialogo();
    }

    public void MostrarDialogo(ObjetoDialogo objetoDialogo){
        estaAberto = true;
        caixaDeDialogo.SetActive(true);
        StartCoroutine(EtapasDoDialogo(objetoDialogo));
    }

    private IEnumerator EtapasDoDialogo(ObjetoDialogo objetoDialogo){
        for(int i = 0; i <objetoDialogo.Dialogo.Length; i++){
            string dialogo = objetoDialogo.Dialogo[i];
            yield return efeitoDeEscrita.Rodar(dialogo, areaDoTexto);

            if(i == objetoDialogo.Dialogo.Length - 1 && objetoDialogo.temResposta) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        if(objetoDialogo.temResposta){
            gerirResposta.MostrarRespostas(objetoDialogo.Respostas);
        } else {
            FecharCaixaDeDialogo();
        }
        
    }

    private void FecharCaixaDeDialogo(){
        estaAberto = false;
        caixaDeDialogo.SetActive(false);
        areaDoTexto.text = string.Empty;
    }
}

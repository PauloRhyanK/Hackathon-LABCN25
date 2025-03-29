using System.Collections;
using UnityEngine;
using TMPro;

public class DialogoUI : MonoBehaviour
{
    [SerializeField] private GameObject caixaDeDialogo;
    [SerializeField] private TMP_Text areaDoTexto;
    [SerializeField] private ObjetoDialogo dialogoTest;
    
    private GerirResposta gerirResposta;

    private EfeitoDeEscrita efeitoDeEscrita;
    private void Start()
    {
        efeitoDeEscrita = GetComponent<EfeitoDeEscrita>();
        gerirResposta = GetComponent<GerirResposta>();
        FecharCaixaDeDialogo();
        MostrarDialogo(dialogoTest);
    }

    public void MostrarDialogo(ObjetoDialogo objetoDialogo){
        caixaDeDialogo.SetActive(true);
        StartCoroutine(EtapasDoDialogo(objetoDialogo));
    }

    private IEnumerator EtapasDoDialogo(ObjetoDialogo objetoDialogo){
        for(int i = 0; i <objetoDialogo.Dialogo.Length; i++){
            string dialogo = objetoDialogo.Dialogo[i];
            yield return efeitoDeEscrita.Rodar(dialogo, areaDoTexto);

            if(i == objetoDialogo.Dialogo.Length - 1 && objetoDialogo.Respostas != null && objetoDialogo.Respostas.Length > 0) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        FecharCaixaDeDialogo();
    }

    private void FecharCaixaDeDialogo(){
        caixaDeDialogo.SetActive(false);
        areaDoTexto.text = string.Empty;
    }
}

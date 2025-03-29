using System.Collections;
using UnityEngine;
using TMPro;

public class DialogoUI : MonoBehaviour
{
    [SerializeField] private GameObject caixaDeDialogo;
    [SerializeField] private TMP_Text areaDoTexto;
    [SerializeField] private ObjetoDialogo dialogoTest;
    
    private EfeitoDeEscrita efeitoDeEscrita;
    private void Start()
    {
        efeitoDeEscrita = GetComponent<EfeitoDeEscrita>();
        FecharCaixaDeDialogo();
        MostrarDialogo(dialogoTest);
    }

    public void MostrarDialogo(ObjetoDialogo objetoDialogo){
        caixaDeDialogo.SetActive(true);
        StartCoroutine(EtapasDoDialogo(objetoDialogo));
    }

    private IEnumerator EtapasDoDialogo(ObjetoDialogo objetoDialogo){
        foreach (string dialogo in objetoDialogo.Dialogo){
            yield return efeitoDeEscrita.Rodar(dialogo, areaDoTexto);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        FecharCaixaDeDialogo();
    }

    private void FecharCaixaDeDialogo(){
        caixaDeDialogo.SetActive(false);
        areaDoTexto.text = string.Empty;
    }
}

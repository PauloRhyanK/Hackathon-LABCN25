using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogoUI : MonoBehaviour
{
    [SerializeField] private GameObject caixaDeDialogo;
    [SerializeField] private TMP_Text areaDoTexto;
    public bool estaAberto { get; private set; }
    private GerirResposta gerirResposta;

    private EfeitoDeEscrita efeitoDeEscrita;

    private bool jaFechado = false;

    [SerializeField] private ObjetoDialogo dialogoAvo;
    [SerializeField] private string nomeDaCena;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Sonho" )
        {
            if (jaFechado)
            {
                SceneManager.LoadScene(nomeDaCena);
            }
        }

    }
    private void Start()
    {
        efeitoDeEscrita = GetComponent<EfeitoDeEscrita>();
        gerirResposta = GetComponent<GerirResposta>();
        FecharCaixaDeDialogo();
        if (SceneManager.GetActiveScene().name == "Sonho")
        {
            MostrarDialogo(dialogoAvo);
        }
        jaFechado = false;
    }

    public void MostrarDialogo(ObjetoDialogo objetoDialogo)
    {
        estaAberto = true;
        caixaDeDialogo.SetActive(true);
        StartCoroutine(EtapasDoDialogo(objetoDialogo));
    }

    private IEnumerator EtapasDoDialogo(ObjetoDialogo objetoDialogo)
    {
        for (int i = 0; i < objetoDialogo.Dialogo.Length; i++)
        {
            string dialogo = objetoDialogo.Dialogo[i];
            yield return efeitoDeEscrita.Rodar(dialogo, areaDoTexto);

            if (i == objetoDialogo.Dialogo.Length - 1 && objetoDialogo.temResposta) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        if (objetoDialogo.temResposta)
        {
            gerirResposta.MostrarRespostas(objetoDialogo.Respostas);
        }
        else
        {
            FecharCaixaDeDialogo(true);
        }

    }

    private void FecharCaixaDeDialogo(bool minigame = false)
    {
        estaAberto = false;
        caixaDeDialogo.SetActive(false);
        areaDoTexto.text = string.Empty;
        if(minigame == true)
        {
            jaFechado = true;
        }
        
    }
}

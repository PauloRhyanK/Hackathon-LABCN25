using UnityEngine;

public class Resposta
{
    [SerializeField] private string textoResposta;
    [SerializeField] private ObjetoDialogo objetoDialogo;
    [SerializeField] private Resposta[] respostas;

    public string TextoResposta => textoResposta;

    public ObjetoDialogo ObjetoDialogo => objetoDialogo;

    public Resposta[] Respostas => respostas;
}

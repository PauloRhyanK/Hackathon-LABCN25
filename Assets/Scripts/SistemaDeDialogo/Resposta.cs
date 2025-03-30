using UnityEngine;

[System.Serializable]
public class Resposta
{
    [SerializeField] private string textoResposta;
    [SerializeField] private ObjetoDialogo objetoDialogo;
    

    public string TextoResposta => textoResposta;

    public ObjetoDialogo ObjetoDialogo => objetoDialogo;

    
}

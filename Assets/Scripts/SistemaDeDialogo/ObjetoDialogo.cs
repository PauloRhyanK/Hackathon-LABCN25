using UnityEngine;

[CreateAssetMenu(menuName = "Dialogo/ObjetoDialogo")]
public class ObjetoDialogo : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogo;
    [SerializeField] private Resposta[] respostas;

    public string[] Dialogo => dialogo;

    public bool temResposta => Respostas != null && Respostas.Length > 0;

    public Resposta[] Respostas => respostas;
}

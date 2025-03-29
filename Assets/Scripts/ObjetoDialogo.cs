using UnityEngine;

[CreateAssetMenu(menuName = "Dialogo/ObjetoDialogo")]
public class ObjetoDialogo : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogo;

    public string[] Dialogo => dialogo;
}

using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteracaoDialogo
{
    [SerializeField] private ObjetoDialogo objetoDialogo;

    public void AtualizarObjetoDialogo(ObjetoDialogo objetoDialogo)
    {
        this.objetoDialogo = objetoDialogo;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out ControladorPersonagem player))
        {
            player.InteracaoD = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out ControladorPersonagem player))
        {
            if (player.InteracaoD is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.InteracaoD = null;
            }
        }
    }

    public void Interagir(ControladorPersonagem player)
    {
        player.DialogoUI.MostrarDialogo(objetoDialogo);
    }
}
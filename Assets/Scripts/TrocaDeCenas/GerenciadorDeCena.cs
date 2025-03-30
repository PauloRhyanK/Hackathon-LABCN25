using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorDeCena : MonoBehaviour
{
    public static Vector2 posicaoJogador = Vector2.zero; // Posição salva
    public static bool posicaoDefinida = false; // Verifica se já tem uma posição salva

    [SerializeField] private Transform pontoDeSpawn; // Local onde o jogador reaparece

    private void Awake()
    {
        // Verifica se há uma posição salva e move o jogador para lá
        if (posicaoDefinida)
        {
            GameObject jogador = GameObject.FindGameObjectWithTag("Player");
            if (jogador != null)
            {
                jogador.transform.position = posicaoJogador;
            }
        }
        else if (pontoDeSpawn != null) 
        {
            // Se for a primeira cena, usa o ponto de spawn inicial
            GameObject jogador = GameObject.FindGameObjectWithTag("Player");
            if (jogador != null)
            {
                jogador.transform.position = pontoDeSpawn.position;
            }
        }
    }
}

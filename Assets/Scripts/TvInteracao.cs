using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvInteracao : MonoBehaviour
{
    [SerializeField] private Sprite spriteTVLigada;
    
    private Sprite spriteTVDesligada;
    [SerializeField] private GameObject caixaDeDialogo;
    [SerializeField] private SpriteRenderer spr;
    private bool ligouTv;
    private int valor;
    // Start is called before the first frame update
    void Start()
    {
        ligouTv = false;
        spr = GetComponentInParent<SpriteRenderer>();
        spriteTVDesligada = spr.sprite;
    }

    private void OnTriggerStay2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        // Quando a caixa de diálogo está desligada e o jogador pressiona E
        if (!caixaDeDialogo.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            spr.sprite = spriteTVLigada; // Define a TV ligada
        }

        // Quando a caixa de diálogo está ligada, permanece com a TV ligada
        if (caixaDeDialogo.activeSelf)
        {
            spr.sprite = spriteTVLigada; // Mantém a TV ligada
        }

        // Quando a caixa de diálogo desativa novamente
        if (!caixaDeDialogo.activeSelf && spr.sprite == spriteTVLigada)
        {
            spr.sprite = spriteTVDesligada; // Define a TV como desligada
        }
    }
}
    
}

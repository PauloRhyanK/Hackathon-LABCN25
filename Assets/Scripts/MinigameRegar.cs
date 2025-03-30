using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MinigameRegar : MonoBehaviour
{
    [SerializeField] private Transform eixoSuperior;
    [SerializeField] private Transform eixoInferior;
    [SerializeField] private Transform regador;
    [SerializeField] private Transform limitador;
    [SerializeField] private SpriteRenderer limitadorSpriteRenderer;

    [SerializeField] private float intervaloMovimentoRegador = 3f;
    [SerializeField] private float tempoSuavizacaoRegador = 1f;
    [SerializeField] private float tamanhoLimitador = 0.1f;
    [SerializeField] private float poderLimitador = 0.5f;
    [SerializeField] private float poderPuxarLimitador = 0.01f;
    [SerializeField] private float gravidadeLimitador = 0.005f;

    private float posicaoRegador;
    private float destinoRegador;
    private float tempoRegador;
    private float velocidadeRegador;
    private float posicaoLimitador;
    private float velocidadeLimitador;

    [SerializeField] private Slider sliderForca; // Referência ao Slider
    [SerializeField] private Transform objetoEscalavel; // Objeto que terá a altura alterada
    [SerializeField] private float alturaMinima = 0.5f;
    [SerializeField] private float alturaMaxima = 2f;

    private void Start()
    {
        AjustarTamanhoLimitador();
       
    }


    private void Update()
    {
        AtualizarRegador();
        AtualizarLimitador();
        AtualizarSlider();
    }

    private void AjustarTamanhoLimitador()
    {
        Bounds b = limitadorSpriteRenderer.bounds;
        float yTamanho = b.size.y;
        Vector3 escala = limitador.localScale;
        float distancia = Vector3.Distance(eixoSuperior.position, eixoInferior.position);
        escala.y = (distancia / yTamanho * tamanhoLimitador);
        limitador.localScale = escala;
    }

    private void AtualizarLimitador()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocidadeLimitador += poderPuxarLimitador;
        }

        velocidadeLimitador -= gravidadeLimitador * Time.deltaTime;

        // Atualiza a posição e impede que o limitador fique preso
        posicaoLimitador += velocidadeLimitador;
        
        if (posicaoLimitador >= 0.99f || posicaoLimitador <= 0.01f)
        {
            velocidadeLimitador = -velocidadeLimitador * 0.5f; // Faz o limitador quicar nos extremos
        }

        posicaoLimitador = Mathf.Clamp(posicaoLimitador, 0.01f, 0.99f);
        limitador.position = Vector3.Lerp(eixoInferior.position, eixoSuperior.position, posicaoLimitador);
    }


    private void AtualizarRegador()
    {
        tempoRegador -= Time.deltaTime;
        if (tempoRegador <= 0f)
        {
            tempoRegador = Random.value * intervaloMovimentoRegador;
            destinoRegador = Random.value;
        }

        posicaoRegador = Mathf.SmoothDamp(posicaoRegador, destinoRegador, ref velocidadeRegador, tempoSuavizacaoRegador);
        regador.position = Vector3.Lerp(eixoInferior.position, eixoSuperior.position, posicaoRegador);
    }

    private void AtualizarSlider()
    {
        // Calcula a proximidade do regador com o limitador
        float distancia = Mathf.Abs(regador.position.y - limitador.position.y);
        float forca = Mathf.Clamp01(1 - distancia);

        // Atualiza o valor do slider
        sliderForca.value = forca;

        // Calcula a nova altura
        float novaAltura = Mathf.Lerp(alturaMinima, alturaMaxima, forca);
        
        // Calcula a diferença de altura
        float diferencaAltura = novaAltura - objetoEscalavel.localScale.y;

        // Aplica a nova altura, mantendo a base fixa
        objetoEscalavel.localScale = new Vector3(objetoEscalavel.localScale.x, novaAltura, objetoEscalavel.localScale.z);
        objetoEscalavel.position += new Vector3(0, diferencaAltura / 2, 0);
    }

}

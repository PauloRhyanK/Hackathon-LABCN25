using System.Collections;
using UnityEngine;

public class ControladorPassaros : MonoBehaviour
{
    private GameObject[] passaros;
    [SerializeField] private float intervaloEntrePassaros = 1f; // Tempo entre cada pássaro aparecer

    private void Awake()
    {
        // Obtém todos os filhos antes de desativar o objeto
        int totalFilhos = transform.childCount;

        if (totalFilhos == 0)
        {
            Debug.LogError("Não há filhos no objeto " + gameObject.name);
            return;
        }

        passaros = new GameObject[totalFilhos];

        for (int i = 0; i < totalFilhos; i++)
        {
            passaros[i] = transform.GetChild(i).gameObject;
            passaros[i].SetActive(false); // Desativa os pássaros corretamente
        }

        gameObject.SetActive(false); // Agora desativa o objeto só depois de configurar tudo
    }

    private void OnEnable()
    {
        if (passaros == null || passaros.Length == 0)
        {
            Debug.LogError("Nenhum pássaro encontrado no objeto: " + gameObject.name);
            return;
        }

        StartCoroutine(AtivarPassaros());
    }

    private IEnumerator AtivarPassaros()
    {
        gameObject.SetActive(true);

        foreach (GameObject passaro in passaros)
        {
            if (passaro != null)
            {
                passaro.SetActive(true);
                yield return new WaitForSeconds(intervaloEntrePassaros);
            }
            else
            {
                Debug.LogError("Um dos pássaros está nulo!");
            }
        }
    }
}

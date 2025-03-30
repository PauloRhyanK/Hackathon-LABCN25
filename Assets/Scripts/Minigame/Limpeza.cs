using System.Collections;
using UnityEngine;

public class Limpeza : MonoBehaviour, IScriptEvento
{
    [SerializeField] private GameObject particulaChuva;
    [SerializeField] private GameObject rio;
    private void Start()
    {
        rio.SetActive(false);

    }
    public IEnumerator ExecutarEvento()
    {
        if (particulaChuva != null)
        {
            particulaChuva.SetActive(true);
            yield return new WaitForSeconds(3);
            if (rio != null)
            {
                rio.SetActive(true);
            }
            yield return new WaitForSeconds(4);
            particulaChuva.SetActive(false);



            yield return null;
        }
    }
}
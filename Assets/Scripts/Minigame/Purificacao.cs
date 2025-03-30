using System.Collections;
using UnityEngine;

public class Purificacao : MonoBehaviour, IScriptEvento
{
    [SerializeField] private GameObject fumaca;
    //    [SerializeField] private GameObject fumaca2;
    [SerializeField] private GameObject fundo;

    private void Start()
    {
        fumaca.SetActive(true);
        fundo.SetActive(false);
        //fumaca2.SetActive(true);

    }
    public IEnumerator ExecutarEvento()
    {
        if (fumaca != null)
        {

            yield return new WaitForSeconds(2);
            if (fundo != null)
            {
                fundo.SetActive(true);
            }
            fumaca.SetActive(false);
            yield return new WaitForSeconds(2);
            //fumaca2.SetActive(false);




            yield return null;
        }
    }
}
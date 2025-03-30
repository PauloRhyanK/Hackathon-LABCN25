using System.Collections.Generic;
using UnityEngine;

public class ControladorPassaros : MonoBehaviour
{
    private List<GameObject> passaros = new List<GameObject>();

    private void Start()
    {
        foreach (Transform filho in transform)
        {
            passaros.Add(filho.gameObject);
            filho.gameObject.SetActive(false); 
        }   
    }

    private void OnEnable()
    {
        foreach (GameObject passaro in passaros)
        {
            passaro.SetActive(true);
        }
    }
}

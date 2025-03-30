using System.Collections.Generic;
using UnityEngine;

public class ControladorPassaros : MonoBehaviour
{
    private List<GameObject> passaros = new List<GameObject>();

    private void Start()
    {
        passaros.Add(gameObject);
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        foreach (var passaro in passaros)
        {
            passaro.SetActive(true);
        }
    }
}

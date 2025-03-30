using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaDeCenas : MonoBehaviour
{
    [SerializeField] private string nomeDaCena;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(nomeDaCena);
        }
    }
}

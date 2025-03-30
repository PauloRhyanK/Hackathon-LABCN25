using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonagem : MonoBehaviour
{
    [SerializeField] private DialogoUI dialogoUI;
    public DialogoUI DialogoUI => dialogoUI;
    public IInteracaoDialogo InteracaoD { get; set; }
    private Rigidbody2D personagemRigidbody2D;
    //private Animator    personagemAnimator;
    public float        personagemSpeed;
    private Vector2     personagemDirection;

    // Start is called before the first frame update
    void Start()
    {
        personagemRigidbody2D = GetComponent<Rigidbody2D>();
       //personagemAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (dialogoUI.estaAberto) return;

         if (Input.GetKeyDown(KeyCode.E))
        {
            InteracaoD?.Interagir(this);
        }
    }

    void FixedUpdate()
    {
        personagemDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        if(personagemDirection.sqrMagnitude > 0.1)
        {
            //personagemAnimator.SetFloat("AxisX", personagemDirection.x);
            
            //personagemAnimator.SetInteger("Movement", 1);
        }
        else
        {
            //personagemAnimator.SetInteger("Movement", 0);
        }
        
        personagemRigidbody2D.MovePosition(personagemRigidbody2D.position + personagemDirection * personagemSpeed * Time.fixedDeltaTime);

    }

    void Flip()
    {
        if(personagemDirection.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        else if(personagemDirection.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }  
    }
}

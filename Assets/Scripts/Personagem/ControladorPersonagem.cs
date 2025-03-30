using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonagem : MonoBehaviour
{
    [SerializeField] private DialogoUI dialogoUI;
    public DialogoUI DialogoUI => dialogoUI;
    public IInteracaoDialogo InteracaoD { get; set; }
    private Rigidbody2D personagemRigidbody2D;
    public float        personagemSpeed;
    private Vector2     personagemDirection;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        personagemRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

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
        if (dialogoUI.estaAberto) return;
        personagemDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        if(personagemDirection.x != 0){
            animator.SetBool("PodeAndar", true);
        } else{
            animator.SetBool("PodeAndar", false);
        }
        
        personagemRigidbody2D.MovePosition(personagemRigidbody2D.position + personagemDirection * personagemSpeed * Time.fixedDeltaTime);
        Flip();

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

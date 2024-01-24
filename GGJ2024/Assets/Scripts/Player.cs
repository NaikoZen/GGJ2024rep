using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade;
    public float forcaPulo;
    public float gravidade;

    private CharacterController characterController;
    private Vector3 velocity;

    private bool estaNoChao;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        DetectarChao();

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 direcao = new Vector3(h, 0f, v).normalized;

        Movimentar(direcao);
        Rotacionar(direcao);

        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            Pular();
        }

        AplicarGravidade();
    }

    void Movimentar(Vector3 direcao)
    {
        Vector3 movimento = direcao * velocidade;
        characterController.Move(movimento * Time.deltaTime);
    }

    void Rotacionar(Vector3 direcao)
    {
        if (direcao != Vector3.zero)
        {
            Quaternion novaRotacao = Quaternion.LookRotation(direcao);
            transform.rotation = Quaternion.Slerp(transform.rotation, novaRotacao, Time.deltaTime * 10f);
        }
    }

    void Pular()
    {
        velocity.y = Mathf.Sqrt(forcaPulo * -2f * gravidade);
    }

    void AplicarGravidade()
    {
        velocity.y += gravidade * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void DetectarChao()
    {
        estaNoChao = characterController.isGrounded;
        if (estaNoChao && velocity.y < 0)
        {
            velocity.y = -0.2f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    public CinemachineFreeLook cineFreeLook;
    public Transform cameraTransform;
    public float velocidade;
    public float forcaPulo;
    public float gravidade;

    //public float yAxis;
    //public float xAxis;

    private CharacterController characterController;
    private Vector3 velocity;

    private bool estaNoChao;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) // 1 representa o botão direito do mouse
        {
            cineFreeLook.m_YAxis.m_MaxSpeed = 4;
            cineFreeLook.m_XAxis.m_MaxSpeed = 500;

            Debug.Log("Botão direito do mouse pressionado");
        }
        else
        {
            cineFreeLook.m_YAxis.m_MaxSpeed = 0;
            cineFreeLook.m_XAxis.m_MaxSpeed = 0;
        }


        if (cameraTransform != null)
        {
            DetectarChao();

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            // Obtém a direção da câmera
            Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;

            // Calcula a direção de movimento usando a direção da câmera
            Vector3 direcao = v * cameraForward + h * cameraTransform.right;

            Movimentar(direcao);

            if (Input.GetButtonDown("Jump") && estaNoChao)
            {
                Pular();
            }

            AplicarGravidade();
        }
    }

    void Movimentar(Vector3 direcao)
    {
        if (direcao != Vector3.zero)
        {
            // Rotaciona o jogador na direção do movimento
            Quaternion novaRotacao = Quaternion.LookRotation(direcao);
            transform.rotation = Quaternion.Slerp(transform.rotation, novaRotacao, Time.deltaTime * 10f);
        }

        Vector3 movimento = direcao * velocidade;
        characterController.Move(movimento * Time.deltaTime);
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
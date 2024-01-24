using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDoPlayer : MonoBehaviour
{
   public Transform target; // Transform do personagem
    public Vector3 offset = new Vector3(0f, 3f, -5f); // Offset da posição da câmera em relação ao personagem
    public float smoothSpeed = 10f; // Velocidade suave de seguimento
    public float rotacaoSuave = 5f; // Velocidade suave de rotação da câmera

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 novaPosicao = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, novaPosicao, smoothSpeed * Time.deltaTime);

            Quaternion novaRotacao = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, novaRotacao, rotacaoSuave * Time.deltaTime);
        }
    }
}
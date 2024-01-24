using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interagir : MonoBehaviour
{
    public string mensagemInteracao = "Pressione E para interagir";
    public GameObject efeitoInteracao;
    public TextMeshProUGUI textoHUD;

    private bool jogadorPerto;

void Start()
    {
        if (textoHUD != null)
        {
            textoHUD.enabled = false;
        }
    }
    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            // Execute a ação de interação aqui
            Debug.Log("Interagindo com o objeto!");
            AtualizarTextoHUD(false);
            // Exemplo: Destruir o objeto após a interação
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            AtualizarTextoHUD(true);
            Debug.Log(mensagemInteracao);

            // Exemplo: Mostrar um efeito visual de interação
            if (efeitoInteracao != null)
            {
                Instantiate(efeitoInteracao, transform.position, Quaternion.identity);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AtualizarTextoHUD(false);
            jogadorPerto = false;
        }
    }

    void AtualizarTextoHUD(bool ativar)
    {
        if (textoHUD != null)
        {
            textoHUD.enabled = ativar;
            textoHUD.text = mensagemInteracao;
        }
    }
}
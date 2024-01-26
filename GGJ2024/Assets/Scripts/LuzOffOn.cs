using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class LuzOffOn : MonoBehaviour
{
   // public DragDrop dragDrop;
    public Animator animator;

    // public static float canosConectados;
    Collider colliderporta;
    // Guarde a referência do componente Light para evitar chamadas excessivas de GetComponent
    private Light luz;

    // Start is called before the first frame update
    void Start()
    {
       

        luz = GetComponent<Light>(); // Obtém o componente Light no início
        if (luz != null)
        {
            Debug.Log("Desligou");
            luz.enabled = false; // Desativa a luz no início
        }
    }

    // Update is called once per frame
    void Update()
    {   
       
        
        // Verifica se a luz é nula para evitar erros
        if (luz != null)
        {
           // Debug.Log("Chegou aq");
            // Ativa a luz se a condição for atendida
            if (DragDrop.canosConectados >= 1 )
            {
               // Debug.Log("Ligou");
                luz.enabled = true;
            }
            // Desativa a luz se a condição não for atendida
            if (GameManager.luzesAcesas == 1 && DragDrop.canosConectados == 1)
            {
                if (Vencer.porta < 1)
                {
                    animator.SetBool("Fechada", false);
                    luz.enabled = true;
                    Debug.Log("Venceu");
                }
               
            }
        }
    }
}
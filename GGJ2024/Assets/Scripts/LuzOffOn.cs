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
    // Guarde a refer�ncia do componente Light para evitar chamadas excessivas de GetComponent
    private Light luz;

    // Start is called before the first frame update
    void Start()
    {
       

        luz = GetComponent<Light>(); // Obt�m o componente Light no in�cio
        if (luz != null)
        {
            Debug.Log("Desligou");
            luz.enabled = false; // Desativa a luz no in�cio
        }
    }

    // Update is called once per frame
    void Update()
    {   
       
        
        // Verifica se a luz � nula para evitar erros
        if (luz != null)
        {
           // Debug.Log("Chegou aq");
            // Ativa a luz se a condi��o for atendida
            if (DragDrop.canosConectados >= 1 )
            {
               // Debug.Log("Ligou");
                luz.enabled = true;
            }
            // Desativa a luz se a condi��o n�o for atendida
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
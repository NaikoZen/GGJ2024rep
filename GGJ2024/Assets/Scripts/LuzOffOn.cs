using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class LuzOffOn : MonoBehaviour
{
   // public DragDrop dragDrop;
    public Animator animator;

    // public static float canosConectados;

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
                animator.SetBool("Fechada", false);
               // Debug.Log("Ligou");
                luz.enabled = true;
            }
            // Desativa a luz se a condi��o n�o for atendida
            else if (DragDrop.canosConectados < 12 )
            {
                luz.enabled = false;
            }
        }
    }
}
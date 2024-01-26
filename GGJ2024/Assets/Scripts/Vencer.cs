using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vencer : MonoBehaviour
{
    public static int porta;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       // Animator animator;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            porta = 1;
            Debug.Log("tocou");
            animator.SetBool("Fechada", true);
            Invoke("TrocadeCena", 3f);


        }
    }

    void TrocadeCena()
    {
        
        GameManager.luzesAcesas = 0;
        DragDrop.canosConectados = 0;
        Vencer.porta = 0;
        SceneManager.LoadScene("GameKallebe");
    }

}

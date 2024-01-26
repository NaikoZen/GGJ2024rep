using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vencer : MonoBehaviour
{
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
            Debug.Log("tocou");
            animator.SetBool("Fechada", true);
            Invoke("TrocadeCena", 3f);


        }
    }

    void TrocadeCena()
    {
        SceneManager.LoadScene("GameKallebe");
    }

}

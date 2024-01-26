using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DefeatCutController : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        // Iniciar a reprodução da cutscene
        videoPlayer.Play();
    }

    void Update()
    {
        // Verificar se a cutscene terminou
        if (!videoPlayer.isPlaying)
        {
            // Transitar para a cena de vitória
            SceneManager.LoadScene(888);
        }
    }
}

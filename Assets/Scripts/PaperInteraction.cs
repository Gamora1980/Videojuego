using UnityEngine;
using UnityEngine.SceneManagement; // Importa SceneManager
using TMPro;

public class PaperInteraction : MonoBehaviour
{
    public GameObject promptUI; // Referencia al objeto de texto UI
    private TextMeshProUGUI promptText; // Referencia al componente de texto

    private void Start()
    {
        promptText = promptUI.GetComponent<TextMeshProUGUI>();
        promptUI.SetActive(false); // Oculta el mensaje al inicio
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowInteractionPrompt();
        }
    }

    private void ShowInteractionPrompt()
    {
        promptUI.SetActive(true); // Muestra el mensaje
        StartCoroutine(WaitForInput());
    }

    private System.Collections.IEnumerator WaitForInput()
    {
        bool inputReceived = false;

        while (!inputReceived)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                inputReceived = true;
                StartMinigame();
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                inputReceived = true;
                ClosePrompt();
            }
            yield return null;
        }
    }

    private void StartMinigame()
    {
        Debug.Log("Entrando al minijuego...");
        SceneManager.LoadScene("MinigameScene"); // Cambia a la escena del minijuego
    }

    private void ClosePrompt()
    {
        promptUI.SetActive(false); // Oculta el mensaje
        Debug.Log("Minijuego cerrado.");
    }
}

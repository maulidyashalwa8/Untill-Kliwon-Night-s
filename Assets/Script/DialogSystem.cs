using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Jika Anda menggunakan UI Text biasa
using UnityEngine.SceneManagement;

public class DialogSystem : MonoBehaviour
{
    public Text dialogText; // UI Text, gunakan jika menggunakan UI Text biasa
   

    public string[] dialogLines; // Array dialog yang akan diputar
    private int currentLine = 0; // Baris dialog yang sedang diputar
    public float typingSpeed = 0.05f; // Kecepatan pengetikan teks

    private bool isTyping = false;

    void Start()
    {
        if(dialogLines.Length > 0)
        {
            StartCoroutine(TypeDialog(dialogLines[currentLine]));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Tekan Space untuk dialog berikutnya
        {
            if (!isTyping)
            {
                NextLine();
            }
            else
            {
                // Skip to the end of the current line
                StopAllCoroutines();
                dialogText.text = dialogLines[currentLine];
                isTyping = false;
            }
        }
    }

    void NextLine()
    {
        currentLine++;
        if (currentLine < dialogLines.Length)
        {
            StartCoroutine(TypeDialog(dialogLines[currentLine]));
        }
        else
        {
            dialogText.text = ""; // Mengosongkan teks setelah dialog selesai
            SceneManager.LoadScene("Game1");
            Time.timeScale = 1f;
    
        }
    }

    IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }
}

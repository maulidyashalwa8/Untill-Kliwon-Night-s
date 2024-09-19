using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogSystem : MonoBehaviour
{
    public Text dialogText;

    public GameObject dialogPanel;
   
    public string[] dialogLines;
    private int currentLine = 0;
    public float typingSpeed = 0.05f;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isTyping)
            {
                NextLine();
            }
            else
            {
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
            EndDialog();
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

    void EndDialog()
    {
        dialogText.text = "";

        SceneManager.LoadScene("Play");
        Time.timeScale = 1f;

    }
}

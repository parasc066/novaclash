using UnityEngine;
using TMPro;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines;
    [SerializeField] TMP_Text dialogueText;

    int currentLine = 0;

    public void NextDialogueLine()
    {
        currentLine = currentLine + 1;// currentLine++
        dialogueText.text = timelineTextLines[currentLine];
    }
}

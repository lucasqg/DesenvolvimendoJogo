using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour {

    public TMP_Text TituloText;
    public TMP_Text DialogText;

    public Animator animator;

    private Queue<string> sentences;

    // Use this for initialization
    void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        animator.SetBool("IsOpen", true);

        TituloText.text = dialog.Nome;

        sentences.Clear();

        foreach (string sentence in dialog.setences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        DialogText.text = "";
        
        foreach(char letra in sentence.ToCharArray())
        {
            DialogText.text += letra;
            yield return null;
        }
    }

    public void EndDialog()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("Acabou");

        this.GetComponent<LoadCene>().OnStart();
    }
}

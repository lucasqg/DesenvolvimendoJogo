using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public Text TituloText;
    public Text DialogText;

    public Image SwapImage;
    public Sprite toSwap;

    public Animator animator;
    public Animator CameraFocus;

    public GameObject Ativa;

    private Queue<string> sentences;
    bool seg = true;

    // Use this for initialization
    void Start() {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            DisplayNextSentence();
        }
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

        FadeManager.Instance.Fade(true, 1.25f);
        Debug.Log("acabou");

        StartCoroutine(wait());

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        SwapImage.GetComponent<Image>().sprite = toSwap;
        FadeManager.Instance.Fade(false, 3);

        yield return new WaitForSeconds(1.5f);
        Ativa.SetActive(true);
        CameraFocus.SetBool("AtivaZoom", true);

        yield return new WaitForSeconds(4);

        this.GetComponent<LoadCene>().OnStart();
    }
}

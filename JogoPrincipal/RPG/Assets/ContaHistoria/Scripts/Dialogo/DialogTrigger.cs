using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

    public Dialog dialog;

    private void Start()
    {
        FadeManager.Instance.Fade(false, 3);
        StartCoroutine(wait());
    }

    public void TriggerDialog()
    {
        this.GetComponent<DialogManager>().StartDialog(dialog);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);


        TriggerDialog();
    }
}

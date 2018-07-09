using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuaçãoHistoria : MonoBehaviour
{
    public Dialog dialog;

    public void Trigger()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);


        this.GetComponent<DialogManager>().StartDialog(dialog);
    }
}

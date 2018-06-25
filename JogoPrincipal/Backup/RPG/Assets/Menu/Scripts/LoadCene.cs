using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCene : MonoBehaviour {
    [Header("Nome da cena que quer carregar")]
    public string Load;
    [Header("Nome da cena Atual")]
    public string ceneAtual;
    [Space(10)]
    public Texture texturaFundo;
    public Texture barraLoad;
    public string textoLoad = "Progresso do Carregamendo da Cena:";
    public Color cor = Color.white;
    public Font Fonte;
    [Space(10)]
    [Range(0.5f, 3.0f)]
    public float tamanhoTexto = 1.5f;
    [Range(1, 10)]
    public int larguraBarra = 8;
    [Range(1, 10)]
    public int alturaBarra = 2;
    [Range(-4.5f, -4.5f)]
    public float deslocarBarra = 4;
    [Range(-8, 4)]
    public float deslocarTextoX = 2;
    [Range(-4.5f, 4.5f)]
    public float deslocarTextoY = 3;
    

    private bool mostraLoad = false;
    private int progressoLoad = 0;



    IEnumerator cenaLoad (string cena)
    {
        mostraLoad = true;

        AsyncOperation Loadding = Application.LoadLevelAsync (cena);

        while (!Loadding.isDone)
        {
            progressoLoad = (int)(Loadding.progress*100);
            yield return null;
        }
    }

    private void OnGUI()
    {
        if(mostraLoad == true)
        {
            GUI.contentColor = cor;
            GUI.skin.font = Fonte;
            GUI.skin.label.fontSize = (int)(Screen.height / 50 * tamanhoTexto);

            //Textura do Fundo
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texturaFundo);

            //Texto do Load
            float movXText = (Screen.height / 10) * deslocarTextoX;
            float movYText = (Screen.height / 10) * deslocarTextoY;

            GUI.Label(new Rect(Screen.width / 2 + movXText, Screen.height / 2 + movYText, Screen.width, Screen.height), textoLoad + " " + progressoLoad + "%");

            //BarraLoad
            float larguraBar = Screen.width * (larguraBarra / 10.0f);
            float alturaBar = Screen.height/50 * alturaBarra;
            float deslocYBar = Screen.height / 10 * deslocarBarra;

            GUI.DrawTexture(new Rect(Screen.width / 2 - larguraBar / 2, Screen.height / 2 - (alturaBar / 2) + deslocYBar, larguraBar * (progressoLoad / 100.00f), alturaBar), barraLoad);

        }
    }

    private void Start()
    {
        if (ceneAtual == "LoadMenu")
        {
            StartCoroutine(cenaLoad(Load));
        }
    }

    public void OnStart()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);


        StartCoroutine(cenaLoad(Load));
    }
}
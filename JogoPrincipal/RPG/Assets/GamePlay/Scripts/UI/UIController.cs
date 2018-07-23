using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public GameObject TexTMissao, HUD, miniMapa;
    public Slider sliderLife;
    public Slider sliderStamina;
    public Slider sliderMana;
    public Slider sliderMonster;
    public Slider sloderExp, skill2, skill3, skill4, skill5, skill6;
    public Text messageItemToTake;
    public Text atributosItens;
    public ContoleDeInventario inventario;
    public float defaultTimeScale;
    public bool naoUtilizavel = false;
    public static UIController instancer;
    public GameObject objectSliderMana, objectSliderStamina, objectSliderMonster; // usado para ocultar o slider em player behaviour!
    public float timeToShowMessage;
    private float currentTimeToShowMessage;
    public int tempoLoad = 1500;
    public int ContadorDeTempo = 0;
    public bool ativo = true;
    public Image destruction;
    public GameObject inventarioDoVendedor;
    public GameObject pontos;
    // Use this for initialization
    void Start () {
        abrirInventario();
        Time.timeScale = defaultTimeScale;
        messageItemToTake.gameObject.SetActive(false);
        instancer = this;
        objectSliderMonster.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        AbrirStatusPontos();
        ContadorDeTempo += 1;
        if(ContadorDeTempo < tempoLoad && ativo)
        {
            inventario.gameObject.SetActive(!inventario.gameObject.activeSelf); // liga e desliga o inventario

            inventarioDoVendedor.gameObject.SetActive(false);
            ativo = false;
            Destroy(destruction.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.I) && !inventarioDoVendedor.activeSelf)
        {
            miniMapa.gameObject.SetActive(!miniMapa.gameObject.activeSelf);
            HUD.gameObject.SetActive(!HUD.gameObject.activeSelf);
            TexTMissao.gameObject.SetActive(!TexTMissao.gameObject.activeSelf);
            inventario.gameObject.SetActive(!inventario.gameObject.activeSelf); // liga e desliga o inventario
            if (inventario.gameObject.activeSelf)//CONDICIONAL QUE PAUSE O GAME.
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = defaultTimeScale;
            }
        }
        if (messageItemToTake.gameObject.activeSelf)
        {
            currentTimeToShowMessage += Time.deltaTime;
            if (currentTimeToShowMessage > timeToShowMessage)
            {
                messageItemToTake.gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && inventario.gameObject.activeSelf && !inventarioDoVendedor.activeSelf)
        {
            inventario.gameObject.SetActive(!inventario.gameObject.activeSelf); // liga e desliga o inventario
            Time.timeScale = defaultTimeScale;
        }
        testaPotion();
    }
    public void testaPotion()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            inventario.VerificaPotionHP();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inventario.VerificaPotionStamina();
        }
    }

    public void AbrirStatusPontos()
    {
        if (pontos.activeSelf && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.K)))
        {
            pontos.SetActive(false);
            //espera para fechar
        }
        else if(!pontos.activeSelf && Input.GetKeyDown(KeyCode.K))
        {
            pontos.SetActive(true);
        }
    }

    public void abrirInventario()
    {
        inventario.gameObject.SetActive(true);
        inventarioDoVendedor.gameObject.SetActive(true);
        
        if (inventario.gameObject.activeSelf)//CONDICIONAL QUE PAUSE O GAME.
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = defaultTimeScale;
        }
    }
    public void ShowMessageTakeItem()
    {
        if (naoUtilizavel)
        {
            messageItemToTake.text = "Item não utilizavel para determinada classe!";
            messageItemToTake.gameObject.SetActive(true);
            currentTimeToShowMessage = 0;
        }
        else {
            messageItemToTake.text = "Pressione [E] para pegar o item";
            messageItemToTake.gameObject.SetActive(true);
            currentTimeToShowMessage = 0;
        }
    }
    public void SetLife(float maxLife, float currentLife)
    {
        float newPositionSlider = (currentLife * 1) / maxLife;
        sliderLife.value = newPositionSlider;
        
    }
    public void SetSkill2(float maxStamina, float currentStamina)
    {
        float newPositionSlider = currentStamina * 1 / maxStamina;
        skill2.value = newPositionSlider;
    }
    public void SetSkill3(float maxStamina, float currentStamina)
    {
        float newPositionSlider = currentStamina * 1 / maxStamina;
        skill3.value = newPositionSlider;
    }
    public void SetSkill4(float maxStamina, float currentStamina)
    {
        float newPositionSlider = currentStamina * 1 / maxStamina;
        skill4.value = newPositionSlider;
    }
    public void SetSkill5(float maxStamina, float currentStamina)
    {
        float newPositionSlider = currentStamina * 1 / maxStamina;
        skill5.value = newPositionSlider;
    }
    public void SetSkill6(float maxStamina, float currentStamina)
    {
        float newPositionSlider = currentStamina * 1 / maxStamina;
        skill6.value = newPositionSlider;
    }
    public void SetStamina(float maxStamina, float currentStamina)
    {
        float newPositionSlider = currentStamina * 1 / maxStamina;
        sliderStamina.value = newPositionSlider;
    }
    public void SetMana(float maxMana, float currentMana)
    {
        float newPositionSlider = currentMana * 1 / maxMana;
        sliderMana.value = newPositionSlider;
    }
    
    public void SetLifeMonster(float maxVida, float currentLife)
    {
        float newPositionSlider = currentLife * 1 / maxVida;
        sliderMonster.value = newPositionSlider;
    }

    public void SetExperiencia(float maxExp, float currentExp)
    {
        float newPositionSlider = currentExp * 1 / maxExp;
        sloderExp.value = newPositionSlider;
    }
}

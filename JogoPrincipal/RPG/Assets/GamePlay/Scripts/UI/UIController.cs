using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {
    public Slider sliderLife;
    public Slider sliderStamina;
    public Slider sliderMana;
    public Slider sliderMonster;
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
        ContadorDeTempo += 1;
        if(ContadorDeTempo < tempoLoad && ativo)
        {
            inventario.gameObject.SetActive(!inventario.gameObject.activeSelf); // liga e desliga o inventario
            ativo = false;
            Destroy(destruction.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.I) && !inventarioDoVendedor.activeSelf)
        {
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

    }
    public void abrirInventario()
    {
        inventario.gameObject.SetActive(true);
        
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

    }
}

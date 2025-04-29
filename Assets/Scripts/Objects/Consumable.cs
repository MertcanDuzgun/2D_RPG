using UnityEngine;
using System.Collections;
using TMPro;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using Unity.VisualScripting;


public class Consumable : MonoBehaviour
{
    [SerializeField] private int totalConsumed;
    [SerializeField] private int maxQuantity;
    [SerializeField] private int currentQuantity;
    [SerializeField] private string effectName;
    [SerializeField] private string effectType;
    [SerializeField] private double effectAmount;
    [SerializeField] private bool ifTimedType;
    [SerializeField] private bool ifConsumed;
    [SerializeField] private int elixirDuration;
    [SerializeField] private string description;

    private GameObject consumableDetailsConsumeButton;
    private GameObject gameController;
    private GameObject uiController;
    private GameObject sceneConsumables;

    //Do not deactivate game object, simply deactivate the components you want inactive.
    //If you wish to make the object disappear, deactivate the renderer. If it is a specific script, deactivate that script, etc.


    private void Start()
    {
        this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { showConsumableDetails(); });
        this.GetComponent<UnityEngine.UI.Button>().enabled = false;

        gameController = GameObject.FindGameObjectWithTag("GameController");
        sceneConsumables = GameObject.FindGameObjectWithTag("sceneConsumables");
        uiController = GameObject.FindGameObjectWithTag("UIController");
        consumableDetailsConsumeButton = GameObject.FindGameObjectWithTag("cnsDtCnsBt");
    }

    private void Update()
    {
        if(currentQuantity > maxQuantity)
        {
            Debug.Log("Current quantity was higher than maxQuantity then currentQuantity was set to maxQuantity -Consumable-");
            currentQuantity = maxQuantity;
        }
        else if(currentQuantity == 0)
        {
            this.GetComponent<Button>().enabled = false;
            this.GetComponent<Image>().enabled = false;
            this.transform.parent = sceneConsumables.transform;
        }
        else if(currentQuantity < 0)
        {
            Debug.Log("Consumable quantity lower than zero!");
        }
    }

    public void isConsumed() 
    {
        if (currentQuantity > 0)
        {
            if (ifTimedType == true)
            {
                if (ifConsumed == false)
                {
                    //EffectActivated();
                    currentQuantity--;
                    totalConsumed++;
                    uiController.GetComponent<UI_Controller>().setConsumableDetails(
                        this.GetComponent<UnityEngine.UI.Image>().sprite, this.name, description, currentQuantity.ToString(), maxQuantity.ToString(), getConsumableType(), getEffect(), getDuration().ToString());
                }
                else
                {
                    /* warningText.GetComponent<TextMeshProUGUI>().text = "You have already consumed this potion. Please wait until ongoing effect is finished";
                    warning.SetActive(true);*/
                }
            }
            else
            {
                effect(effectName);
                currentQuantity--;
                totalConsumed++;
                uiController.GetComponent<UI_Controller>().setConsumableDetails(
                        this.GetComponent<UnityEngine.UI.Image>().sprite, this.name, description, currentQuantity.ToString(), maxQuantity.ToString(), getConsumableType(), getEffect(), getDuration().ToString());
            }
        }
        else
        {
            /*warningText.GetComponent<TextMeshProUGUI>().text = "You don't have enough items.";
            warning.SetActive(true);*/
        }
    }

    public void showConsumableDetails()
    {
        uiController.GetComponent<UI_Controller>().activateConsumableDetails();
        uiController.GetComponent<UI_Controller>().setConsumableDetails(
                        this.GetComponent<UnityEngine.UI.Image>().sprite, this.name, description, currentQuantity.ToString(), maxQuantity.ToString(), getConsumableType(), getEffect(), getDuration().ToString());
        consumableDetailsConsumeButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { isConsumed(); });
    }

    public void hideConsumableDetails()
    {
        uiController.GetComponent<UI_Controller>().deactivateConsumableDetails();
    }

    /*IEnumerator EffectActivated()
    {
        for (; ; )
        {
            if (ifConsumed == false) 
            {
                effect(effectName);
                Debug.Log("Consumable Effect is activated.");
                yield return new WaitForSeconds(potionDuration);
                ifConsumed = true;
            }
            else
            {
                StopCoroutine(EffectActivated());
            }
            
        }
    }*/

    private void effect(string nameOfEffect)
    {
        if (nameOfEffect == "Strength")
        {
            Debug.Log("Strength stat is changed upon usage of consumable.");
            double strength = gameController.GetComponent<GameController>().getStrength();
            gameController.GetComponent<GameController>().setStrength(applyEffectType(strength));
        }
        else if(nameOfEffect == "Agility")
        {
            Debug.Log("Agility stat is changed upon usage of consumable.");
            gameController.GetComponent<GameController>().setAgility(applyEffectType(gameController.GetComponent<GameController>().getAgility()));
        }
        else if (nameOfEffect == "Endurance")
        {
            Debug.Log("Endurance stat is changed upon usage of consumable.");
            gameController.GetComponent<GameController>().setEndurance(applyEffectType(gameController.GetComponent<GameController>().getEndurance()));
        }
        else if (nameOfEffect == "Dexterity")
        {
            Debug.Log("Dexterity stat is changed upon usage of consumable.");
            gameController.GetComponent<GameController>().setDexterity(applyEffectType(gameController.GetComponent<GameController>().getDexterity()));
        }
        else if (nameOfEffect == "Intelligence")
        {
            Debug.Log("Intelligence stat is changed upon usage of consumable.");
            gameController.GetComponent<GameController>().setIntelligence(applyEffectType(gameController.GetComponent<GameController>().getIntelligence()));
        }
        else if (nameOfEffect == "Wisdom")
        {
            Debug.Log("Wisdom stat is changed upon usage of consumable.");
            gameController.GetComponent<GameController>().setWisdom(applyEffectType(gameController.GetComponent<GameController>().getWisdom()));
        }
        else if (nameOfEffect == "Vitality")
        {
            Debug.Log("Vitality stat is changed upon usage of consumable.");
            gameController.GetComponent<GameController>().setVitality(applyEffectType(gameController.GetComponent<GameController>().getVitality()));
        }
        else
        {
            /*warningText.GetComponent<TextMeshProUGUI>().text = "Unknown potion type. Please report your situation as a bug. I will fix it as soon as possible.";
            warning.SetActive(true);*/
        }
    }

    private double applyEffectType(double input)
    {
        if(effectType == "Add")
        {
            Debug.Log("Effect type applied.");
            Debug.Log("Current value of stat is: ");
            Debug.Log(input + effectAmount);

            return input + effectAmount;
        }
        else if(effectType == "Subtract")
        {
            Debug.Log("Effect type applied.");
            Debug.Log("Current value of stat is: ");
            Debug.Log(input - effectAmount);

            return input - effectAmount;
        }
        else if(effectType == "Multiply")
        {
            Debug.Log("Effect type applied.");
            Debug.Log("Current value of stat is: ");
            Debug.Log(input * effectAmount);

            return input * effectAmount;
        }
        else if(effectType == "Divide")
        {
            Debug.Log("Effect type applied.");
            Debug.Log("Current value of stat is: ");
            Debug.Log(input / effectAmount);

            return input / effectAmount;
        }
        else
        {
           /* warningText.GetComponent<TextMeshProUGUI>().text = "Unknown effect type. Please report your situation as a bug. I will fix it as soon as possible.";
            warning.SetActive(true);*/
            return 0;
        }
    }

    public string getDescription()
    {
        return description;
    }

    public int getMaxQuantity()
    {
        return maxQuantity;
    }
    
    public string getConsumableType()
    {
        if( ifTimedType== true)
        {
            return "Timed";
        }
        else
        {
            return "One-time";
        }
    }

    public string getEffect()
    {
        string effect = "";
        switch (effectType)
        {
            case "Add":
                effect = "+" + effectAmount.ToString()+ " " + effectName.ToString();
                break;
            case "Subtract":
                effect = "-" + effectAmount.ToString()+ " " + effectName.ToString();
                break;
            case "Multiply":
                effect = "*" + effectAmount.ToString()+ " " + effectName.ToString();
                break;
            case "Divide":
                effect = "/" + effectAmount.ToString() + " " + effectName.ToString();
                break;
        }
        return effect;
    }

    public int getDuration()
    {
        return elixirDuration;
    }

    public int getCurrentQuantity()
    {
        return currentQuantity;
    }

    public void increaseQuantity(int quantity)
    {
        if ((currentQuantity + quantity) < maxQuantity)
        {
            currentQuantity += quantity;
        }
        else
        {
            /*warningText.GetComponent<TextMeshProUGUI>().text = "You can't own more items than maximum quantity allowed.";
            warning.SetActive(true);*/
        }
    }

    public void decreaseQuantity(int quantity)
    { 
       
        if (currentQuantity - quantity >= 0) 
        {
            currentQuantity -= quantity;
        }
        /*else
        {
            warningText.GetComponent<TextMeshProUGUI>().text = "You don't have enough items.";
            warning.SetActive(true);
        }*/
    }
}
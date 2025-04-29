using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class Equipment : MonoBehaviour
{
    [SerializeField] private int maxQuantity;
    [SerializeField] private int currentQuantity;
    [SerializeField] private string[] effectName;
    [SerializeField] private string[] effectType;
    [SerializeField] private double[] effectAmount;
    [SerializeField] private bool isEquipped;
    [SerializeField] private string equipmentSlotName;
    [SerializeField] private string description;

    [SerializeField] private GameObject childEquipment;

    private GameObject gameController;
    private GameObject sceneEquipments;
    private GameObject equipmentSlot;
    private GameObject uiController;
    private GameObject equipmentDetailsEquipButton;

    void Start()
    {
        this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { showEquipmentDetails(); });
        this.GetComponent<UnityEngine.UI.Button>().enabled = false;

        gameController = GameObject.FindGameObjectWithTag("GameController");
        sceneEquipments = GameObject.FindGameObjectWithTag("OBJECTS");
        equipmentSlot = GameObject.FindGameObjectWithTag(equipmentSlotName);
        uiController = GameObject.FindGameObjectWithTag("UIController");
        equipmentDetailsEquipButton = GameObject.FindGameObjectWithTag("eqpDtCnsBt");
    }

    private void Update()
    {
        if (currentQuantity > maxQuantity)
        {
            currentQuantity = maxQuantity;
            Debug.Log("Current quantity was higher than maxQuantity then currentQuantity was set to maxQuantity -Equipment-");
        }
        else if (currentQuantity == 0)
        {
            this.GetComponent<UnityEngine.UI.Button>().enabled = false;
            this.GetComponent<UnityEngine.UI.Image>().enabled = false;
            this.transform.parent = sceneEquipments.transform;
        }
        else if (currentQuantity < 0)
        {
            Debug.Log("Consumable quantity lower than zero!");
        }        
    }

    public void equip()
    {
        if (equipmentSlot.transform.childCount == 0 && isEquipped == false)
        {
            for (int i = 0; i < effectName.Length; i++)
            {
                if (effectName[i] == "Strength")
                {
                    Debug.Log("Strength stat is changed upon usage of consumable.");
                    double strength = gameController.GetComponent<GameController>().getStrength();
                    gameController.GetComponent<GameController>().setStrength(applyEffectType(strength, effectType[i], effectAmount[i]));
                }
                else if (effectName[i] == "Agility")
                {
                    Debug.Log("Agility stat is changed upon usage of consumable.");
                    double agility = gameController.GetComponent<GameController>().getAgility();
                    gameController.GetComponent<GameController>().setAgility(applyEffectType(agility, effectType[i], effectAmount[i]));
                }
                else if (effectName[i] == "Endurance")
                {
                    Debug.Log("Endurance stat is changed upon usage of consumable.");
                    double endurance = gameController.GetComponent<GameController>().getEndurance();
                    gameController.GetComponent<GameController>().setEndurance(applyEffectType(endurance, effectType[i], effectAmount[i]));
                }
                else if (effectName[i] == "Dexterity")
                {
                    Debug.Log("Dexterity stat is changed upon usage of consumable.");
                    double dexterity = gameController.GetComponent<GameController>().getDexterity();
                    gameController.GetComponent<GameController>().setDexterity(applyEffectType(dexterity, effectType[i], effectAmount[i]));
                }
                else if (effectName[i] == "Intelligence")
                {
                    Debug.Log("Intelligence stat is changed upon usage of consumable.");
                    double intelligence = gameController.GetComponent<GameController>().getIntelligence();
                    gameController.GetComponent<GameController>().setIntelligence(applyEffectType(intelligence, effectType[i], effectAmount[i]));
                }
                else if (effectName[i] == "Wisdom")
                {
                    Debug.Log("Wisdom stat is changed upon usage of consumable.");
                    double wisdom = gameController.GetComponent<GameController>().getWisdom();
                    gameController.GetComponent<GameController>().setWisdom(applyEffectType(wisdom, effectType[i], effectAmount[i]));
                }
                else if (effectName[i] == "Vitality")
                {
                    Debug.Log("Vitality stat is changed upon usage of consumable.");
                    double vitality = gameController.GetComponent<GameController>().getVitality();
                    gameController.GetComponent<GameController>().setVitality(applyEffectType(vitality, effectType[i], effectAmount[i]));
                }
                else
                {
                    Debug.Log("Unknown status type. -Equipment-");
                }
            }

            isEquipped = true;

            childEquipment.transform.parent = equipmentSlot.transform;
            childEquipment.transform.localPosition = Vector3.zero;
        }
        else if(isEquipped == true)
        {
            unequip();
        }
    }

    public void unequip()
    {
        if (currentQuantity > 0)
        {
            isEquipped = false;

            for (int i = 0; i < effectName.Length; i++)
            {
                if (effectName[i] == "Strength")
                {
                    Debug.Log("Strength stat is changed upon usage of consumable.");
                    double strength = gameController.GetComponent<GameController>().getStrength();
                    gameController.GetComponent<GameController>().setStrength(removeEffectType(strength, effectType[i], effectAmount[i]));
                }
                else if (effectName[i] == "Agility")
                {
                    Debug.Log("Agility stat is changed upon usage of consumable.");
                    double agility = gameController.GetComponent<GameController>().getAgility();
                    gameController.GetComponent<GameController>().setAgility(removeEffectType(agility, effectType[i], effectAmount[i]));
                }
                else if (effectName[i] == "Endurance")
                {
                    Debug.Log("Endurance stat is changed upon usage of consumable.");
                    double endurance = gameController.GetComponent<GameController>().getEndurance();
                    gameController.GetComponent<GameController>().setEndurance(removeEffectType(endurance, effectType[i], effectAmount[i]));
                }
                else if (effectName[i] == "Dexterity")
                {
                    Debug.Log("Dexterity stat is changed upon usage of consumable.");
                    double dexterity = gameController.GetComponent<GameController>().getDexterity();
                    gameController.GetComponent<GameController>().setDexterity(removeEffectType(dexterity, effectType[i], effectAmount[i]));
                }
                else if (effectName[i] == "Intelligence")
                {
                    Debug.Log("Intelligence stat is changed upon usage of consumable.");
                    double intelligence = gameController.GetComponent<GameController>().getIntelligence();
                    gameController.GetComponent<GameController>().setIntelligence(removeEffectType(intelligence, effectType[i], effectAmount[i]));
                }
                else if (effectName[i] == "Wisdom")
                {
                    Debug.Log("Wisdom stat is changed upon usage of consumable.");
                    double wisdom = gameController.GetComponent<GameController>().getWisdom();
                    gameController.GetComponent<GameController>().setWisdom(removeEffectType(wisdom, effectType[i], effectAmount[i]));
                }
                else if (effectName[i] == "Vitality")
                {
                    Debug.Log("Vitality stat is changed upon usage of consumable.");
                    double vitality = gameController.GetComponent<GameController>().getVitality();
                    gameController.GetComponent<GameController>().setVitality(removeEffectType(vitality, effectType[i], effectAmount[i]));
                }
                else
                {
                    Debug.Log("Unknown status type. -Equipment-");
                }
            }

            childEquipment.GetComponent<EquipmentChild>().turnBackToParentEquipment();
            childEquipment.GetComponent<UnityEngine.UI.Button>().enabled = false;
            childEquipment.GetComponent<UnityEngine.UI.Image>().enabled= false;
        }
    }

    public void showEquipmentDetails()
    {
        uiController.GetComponent<UI_Controller>().activateEquipmentDetails();
        uiController.GetComponent<UI_Controller>().setEquipmentDetails(
                        this.GetComponent<UnityEngine.UI.Image>().sprite, this.name, description, currentQuantity.ToString(), maxQuantity.ToString(), getEquipmentEffect1(), getEquipmentEffect2(), getEquipmentEffect3());
        equipmentDetailsEquipButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { equip(); });
    }

    public void hideEquipmentDetails()
    {
        uiController.GetComponent<UI_Controller>().deactivateEquipmentDetails();
    }

    public string getEquipmentEffect1()
    {
        string effect = "";
        double amount = getEffectAmount1();
        string name = getEffectName1();
        string type = getEffectType1();

        switch (type)
        {
            case "Add":
                effect = "+" + amount.ToString() + " " + name.ToString();
                break;
            case "Subtract":
                effect = "-" + amount.ToString() + " " + name.ToString();
                break;
            case "Multiply":
                effect = "*" + amount.ToString() + " " + name.ToString();
                break;
            case "Divide":
                effect = "/" + amount.ToString() + " " + name.ToString();
                break;
        }
        Debug.Log(effect);
        Debug.Log("Effect1");
        return effect;
    }

    public string getEquipmentEffect2()
    {
        string effect = "";
        double amount = getEffectAmount2();
        string name = getEffectName2();
        string type = getEffectType2();

        switch (type)
        {
            case "Add":
                effect = "+" + amount.ToString() + " " + name.ToString();
                break;
            case "Subtract":
                effect = "-" + amount.ToString() + " " + name.ToString();
                break;
            case "Multiply":
                effect = "*" + amount.ToString() + " " + name.ToString();
                break;
            case "Divide":
                effect = "/" + amount.ToString() + " " + name.ToString();
                break;
        }
        Debug.Log(effect);
        Debug.Log("Effect2");
        return effect;
    }

    public string getEquipmentEffect3()
    {
        string effect = "";
        double amount = getEffectAmount3();
        string name  = getEffectName3();
        string type = getEffectType3();

        switch (type)
        {
            case "Add":
                effect = "+" + amount.ToString() + " " + name.ToString();
                break;
            case "Subtract":
                effect = "-" + amount.ToString() + " " + name.ToString();
                break;
            case "Multiply":
                effect = "*" + amount.ToString() + " " + name.ToString();
                break;
            case "Divide":
                effect = "/" + amount.ToString() + " " + name.ToString();
                break;
        }
        Debug.Log(effect); 
        Debug.Log("Effect3");
        return effect;
    }

    public double getEffectAmount1()
    {
        return effectAmount[0];
    }
    public double getEffectAmount2()
    {
        return effectAmount[1];
    }
    public double getEffectAmount3()
    {
        return effectAmount[2];
    }

    public string getEffectType1()
    {
        return effectType[0];
    }
    public string getEffectType2()
    {
        return effectType[1];
    }
    public string getEffectType3()
    {
        return effectType[2];
    }

    public string getEffectName1()
    {
        return effectName[0];
    }
    public string getEffectName2()
    {
        return effectName[1];
    }
    public string getEffectName3()
    {
        return effectName[2];
    }

    private double removeEffectType(double input, string effectType, double effectAmount)
    {
        if (effectType == "Add")
        {
            Debug.Log("Effect type applied.");
            Debug.Log("Current value of stat is: ");
            Debug.Log(input - effectAmount);

            return input - effectAmount;
        }
        else if (effectType == "Subtract")
        {
            Debug.Log("Effect type applied.");
            Debug.Log("Current value of stat is: ");
            Debug.Log(input + effectAmount);

            return input + effectAmount;
        }
        else if (effectType == "Multiply")
        {
            Debug.Log("Effect type applied.");
            Debug.Log("Current value of stat is: ");
            Debug.Log(input / effectAmount);

            return input / effectAmount;
        }
        else if (effectType == "Divide")
        {
            Debug.Log("Effect type applied.");
            Debug.Log("Current value of stat is: ");
            Debug.Log(input * effectAmount);

            return input * effectAmount;
        }
        else
        {
            Debug.Log("Unknown effect type. -Equipment-");
            /* warningText.GetComponent<TextMeshProUGUI>().text = "Unknown effect type. Please report your situation as a bug. I will fix it as soon as possible.";
             warning.SetActive(true);*/
            return 0;
        }
    }

    private double applyEffectType(double input, string effectType, double effectAmount)
    {

        if (effectType == "Add")
        {
            Debug.Log("Effect type applied.");
            Debug.Log("Current value of stat is: ");
            Debug.Log(input + effectAmount);

            return input + effectAmount;
        }
        else if (effectType == "Subtract")
        {
            Debug.Log("Effect type applied.");
            Debug.Log("Current value of stat is: ");
            Debug.Log(input - effectAmount);

            return input - effectAmount;
        }
        else if (effectType == "Multiply")
        {
            Debug.Log("Effect type applied.");
            Debug.Log("Current value of stat is: ");
            Debug.Log(input * effectAmount);

            return input * effectAmount;
        }
        else if (effectType == "Divide")
        {
            Debug.Log("Effect type applied.");
            Debug.Log("Current value of stat is: ");
            Debug.Log(input / effectAmount);

            return input / effectAmount;
        }
        else
        {
            Debug.Log("Unknown effect type. -Equipment-");
            /* warningText.GetComponent<TextMeshProUGUI>().text = "Unknown effect type. Please report your situation as a bug. I will fix it as soon as possible.";
             warning.SetActive(true);*/
            return 0;
        }
    }

    public int getCurrentQuantity()
    {
        return currentQuantity;
    }

    public bool getIsEquipped()
    {  
        return isEquipped;
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

        if ((currentQuantity - quantity) > 0)
        {
            currentQuantity -= quantity;
        }
        else if((currentQuantity - quantity) == 0 && isEquipped == true) 
        {
            // Put warning or some info here YOU CANNOT SELL EQUIPPED ITEM
        }
        else if((currentQuantity - quantity) == 0 && isEquipped == false)
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
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEditor.Search;
using UnityEngine.UIElements;
using UnityEngine.U2D;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lifeSpanText;
    [SerializeField] private GameObject gameCtrl;
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject warning;
    [SerializeField] private GameObject warningText;

    // Inventory related.
    [SerializeField] private GameObject inventoryButton;
    [SerializeField] private GameObject Inventory;
    [SerializeField] private GameObject showInventoryButton;
    [SerializeField] private GameObject hideInventoryButton;
    [SerializeField] private GameObject characterScreenButton;
    [SerializeField] private GameObject CharacterScreen;

    //CharacterScreen stat related.
    [SerializeField] private TextMeshProUGUI mainStatValueVitality;
    [SerializeField] private TextMeshProUGUI mainStatValueStrength;
    [SerializeField] private TextMeshProUGUI mainStatValueAgility;
    [SerializeField] private TextMeshProUGUI mainStatValueEndurance;
    [SerializeField] private TextMeshProUGUI mainStatValueDexterity;
    [SerializeField] private TextMeshProUGUI mainStatValueIntelligence;
    [SerializeField] private TextMeshProUGUI mainStatValueWisdom;

    //Cultivation related.
    [SerializeField] private GameObject cultivationScreen;
    [SerializeField] private GameObject cultivationScreenShowButton;
    [SerializeField] private GameObject cultivationScreenHideButton;

    //Body part.
    [SerializeField] private GameObject cultivationScreenBody;
    [SerializeField] private GameObject bodyButton;
    [SerializeField] private GameObject spiritButton;
    [SerializeField] private GameObject mindButton;
    [SerializeField] private TextMeshProUGUI bodyCultivationLevelName;
    [SerializeField] private TextMeshProUGUI bodyCultivationLevel;
    [SerializeField] private TextMeshProUGUI bodyCultivationRequiredEnergyText;
    [SerializeField] private TextMeshProUGUI bodyCultivationCurrentEnergyText;
    [SerializeField] private TextMeshProUGUI bodyCultivationEnergyToLevelUpText;
    [SerializeField] private UnityEngine.UI.Image bodyCultivationProgressBar;

    //Consumable Details.
    [SerializeField] private GameObject consumableDetails;
    [SerializeField] private GameObject consumableDetailsImage;
    [SerializeField] private GameObject consumableDetailsName;
    [SerializeField] private GameObject consumableDetailsDescription;
    [SerializeField] private GameObject consumableDetailsConsumeButton;
    [SerializeField] private GameObject consumableDetailsCloseButton;
    [SerializeField] private GameObject consumableDetailsCurrentQuantity;
    [SerializeField] private GameObject consumableDetailsMaxQuantity;
    [SerializeField] private GameObject consumableDetailsConsumableType;
    [SerializeField] private GameObject consumableDetailsConsumableEffect;
    [SerializeField] private GameObject consumableDetailsConsumableDuration;

    //Equipment Details
    [SerializeField] private GameObject equipmentDetails;
    [SerializeField] private GameObject equipmentDetailsImage;
    [SerializeField] private GameObject equipmentDetailsName;
    [SerializeField] private GameObject equipmentDetailsDescription;
    [SerializeField] private GameObject equipmentDetailsEquipButton;
    [SerializeField] private GameObject equipmentDetailsCloseButton;
    [SerializeField] private GameObject equipmentDetailsCurrentQuantity;
    [SerializeField] private GameObject equipmentDetailsMaxQuantity;
    [SerializeField] private GameObject equipmentDetailsEquipmentFirstEffect;
    [SerializeField] private GameObject equipmentDetailsEquipmentSecondEffect;
    [SerializeField] private GameObject equipmentDetailsEquipmentThirdEffect;

    //Material Details
    [SerializeField] private GameObject materialDetails;
    [SerializeField] private GameObject materialDetailsImage;
    [SerializeField] private GameObject materialDetailsName;
    [SerializeField] private GameObject materialDetailsDescription;
    [SerializeField] private GameObject materialDetailsCloseButton;
    [SerializeField] private GameObject materialDetailsCurrentQuantity;
    [SerializeField] private GameObject materialDetailsMaxQuantity;
    [SerializeField] private GameObject materialDetailsRarity;
    [SerializeField] private GameObject materialDetailsType;
    [SerializeField] private GameObject materialDetailsUsage;


    private double lifeSpanDay;
    private double lifeSpanYear;

    private void Start()
    {

    }

    private void Update()
    {
        setLifeSpanTexts();

        setCharacterScreenStatValues();

        setBodyCultivationScreenValues();
    }

    public void setConsumableDetails(Sprite sprite, string str1, string str2, string str3, string str4, string str5, string str6,string str7)
    {
        consumableDetailsImage.GetComponent<UnityEngine.UI.Image>().sprite = sprite;
        consumableDetailsName.GetComponent<TextMeshProUGUI>().text = str1;
        consumableDetailsDescription.GetComponent<TextMeshProUGUI>().text = str2;
        consumableDetailsCurrentQuantity.GetComponent<TextMeshProUGUI>().text = str3;
        consumableDetailsMaxQuantity.GetComponent<TextMeshProUGUI>().text = str4;
        consumableDetailsConsumableType.GetComponent<TextMeshProUGUI>().text = str5;
        consumableDetailsConsumableEffect.GetComponent<TextMeshProUGUI>().text = str6;
        consumableDetailsConsumableDuration.GetComponent<TextMeshProUGUI>().text = str7;
    }

    public void setEquipmentDetails(Sprite sprite, string str1, string str2, string str3, string str4, string str5, string str6, string str7)
    {
        equipmentDetailsImage.GetComponent<UnityEngine.UI.Image>().sprite = sprite;
        equipmentDetailsName.GetComponent<TextMeshProUGUI>().text = str1;
        equipmentDetailsDescription.GetComponent<TextMeshProUGUI>().text = str2;
        equipmentDetailsCurrentQuantity.GetComponent<TextMeshProUGUI>().text = str3;
        equipmentDetailsMaxQuantity.GetComponent<TextMeshProUGUI>().text = str4;
        equipmentDetailsEquipmentFirstEffect.GetComponent<TextMeshProUGUI>().text = str5;
        equipmentDetailsEquipmentSecondEffect.GetComponent<TextMeshProUGUI>().text = str6;
        equipmentDetailsEquipmentThirdEffect.GetComponent<TextMeshProUGUI>().text = str7;
    }

    public void setMaterialDetails(Sprite sprite, string str1, string str2, string str3, string str4, string str5, string str6, string str7)
    {
        materialDetailsImage.GetComponent<UnityEngine.UI.Image>().sprite = sprite;
        materialDetailsName.GetComponent<TextMeshProUGUI>().text = str1;
        materialDetailsDescription.GetComponent<TextMeshProUGUI>().text = str2;
        materialDetailsCurrentQuantity.GetComponent<TextMeshProUGUI>().text = str3;
        materialDetailsMaxQuantity.GetComponent<TextMeshProUGUI>().text = str4;
        materialDetailsRarity.GetComponent<TextMeshProUGUI>().text = str5;
        materialDetailsType.GetComponent<TextMeshProUGUI>().text = str6;
        materialDetailsUsage.GetComponent<TextMeshProUGUI>().text = str7;
    }

    public void activateConsumableDetails()
    {
        for (int i = 0; i < consumableDetails.transform.childCount; i++)
        {
            consumableDetails.transform.GetChild(i).gameObject.SetActive(true);
        }

        consumableDetailsConsumeButton.GetComponent<UnityEngine.UI.Image>().enabled = true;
        consumableDetailsConsumeButton.GetComponent<UnityEngine.UI.Button>().enabled = true;
        consumableDetailsConsumeButton.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void activateEquipmentDetails()
    {
        for (int i = 0; i < equipmentDetails.transform.childCount; i++)
        {
            equipmentDetails.transform.GetChild(i).gameObject.SetActive(true);
        }

        equipmentDetailsEquipButton.GetComponent<UnityEngine.UI.Image>().enabled = true;
        equipmentDetailsEquipButton.GetComponent<UnityEngine.UI.Button>().enabled = true;
        equipmentDetailsEquipButton.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void activateMaterialDetails()
    {
        for (int i = 0; i < materialDetails.transform.childCount; i++)
        {
            materialDetails.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void deactivateConsumableDetails() 
    {
        for (int i = 0; i < consumableDetails.transform.childCount; i++)
        {
            if(consumableDetails.transform.GetChild(i).tag != "cnsDtCnsBt")
            {
                consumableDetails.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        consumableDetailsConsumeButton.GetComponent<UnityEngine.UI.Image>().enabled = false;
        consumableDetailsConsumeButton.GetComponent<UnityEngine.UI.Button>().enabled = false;
        consumableDetailsConsumeButton.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void deactivateEquipmentDetails()
    {
        for (int i = 0; i < equipmentDetails.transform.childCount; i++)
        {
            if (equipmentDetails.transform.GetChild(i).tag != "eqpDtCnsBt")
            {
                equipmentDetails.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        equipmentDetailsEquipButton.GetComponent<UnityEngine.UI.Image>().enabled = false;
        equipmentDetailsEquipButton.GetComponent<UnityEngine.UI.Button>().enabled = false;
        equipmentDetailsEquipButton.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void deactivateMaterialDetails()
    {
        for (int i = 0; i < materialDetails.transform.childCount; i++)
        {   
            materialDetails.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void showCultivationScreen()
    {
        hideCharacterScreen();
        hideInventory();

        cultivationScreen.SetActive(true);
        cultivationScreenShowButton.SetActive(false);
        cultivationScreenHideButton.SetActive(true);
    }

    public void hideCultivationScreen()
    {
        cultivationScreen.SetActive(false);
        cultivationScreenShowButton.SetActive(true);
        cultivationScreenHideButton.SetActive(false);
    }

    public void setBodyCultivationScreenValues()
    {
        if(cultivationScreenBody.activeSelf == true)
        {
            bodyCultivationLevelName.text = body.GetComponent<Body>().getCurrentMajorCultivationLevel().GetComponent<MajorCultivationLevel>().getEnergyLevelName();
            switch (body.GetComponent<Body>().getCurrentMinorCultivationLevel().GetComponent<MinorCultivationLevel>().getEnergyLevel())
            {
                case 9:
                    bodyCultivationLevel.text = "Ninth Level";
                    break;
                case 8:
                    bodyCultivationLevel.text = "Eigth Level";
                    break;
                case 7:
                    bodyCultivationLevel.text = "Seventh Level";
                    break;
                case 6:
                    bodyCultivationLevel.text = "Sixth Level";
                    break;
                case 5:
                    bodyCultivationLevel.text = "Fifth Level";
                    break;
                case 4:
                    bodyCultivationLevel.text = "Fourth Level";
                    break;
                case 3:
                    bodyCultivationLevel.text = "Third Level";
                    break;
                case 2:
                    bodyCultivationLevel.text = "Second Level";
                    break;
                case 1:
                    bodyCultivationLevel.text = "First Level";
                    break;
                default:
                    Debug.Log("Energy Level was not between 1-9. -UI Controller-Trying to set body cultivation screen text values-");
                    break;
            }
            bodyCultivationRequiredEnergyText.text = body.GetComponent<Body>().getMaxEnergy().ToString();
            bodyCultivationCurrentEnergyText.text = body.GetComponent<Body>().getCurrentEnergy().ToString();
            bodyCultivationEnergyToLevelUpText.text = (body.GetComponent<Body>().getMaxEnergy() - body.GetComponent<Body>().getCurrentEnergy()).ToString();

            float fillAmount = (float)(body.GetComponent<Body>().getCurrentEnergy()) / (float)(body.GetComponent<Body>().getMaxEnergy());
            bodyCultivationProgressBar.fillAmount = fillAmount;
        }
    }
    
    public void setCharacterScreenStatValues()
    {
        mainStatValueVitality.text = gameCtrl.GetComponent<GameController>().getVitality().ToString();
        mainStatValueStrength.text = gameCtrl.GetComponent<GameController>().getStrength().ToString();
        mainStatValueAgility.text = gameCtrl.GetComponent<GameController>().getAgility().ToString();
        mainStatValueEndurance.text = gameCtrl.GetComponent<GameController>().getEndurance().ToString();
        mainStatValueDexterity.text = gameCtrl.GetComponent<GameController>().getDexterity().ToString();
        mainStatValueIntelligence.text = gameCtrl.GetComponent<GameController>().getIntelligence().ToString();
        mainStatValueWisdom.text = gameCtrl.GetComponent<GameController>().getWisdom().ToString();
    }

    public void setLifeSpanTexts()
    {
        //Get Lifespan Day
        lifeSpanDay = gameCtrl.GetComponent<GameController>().getLifeSpanDays() % 300;
        // Get Lifespan Year.
        lifeSpanYear = gameCtrl.GetComponent<GameController>().getLifeSpanYears();
        //Set text
        lifeSpanText.text = lifeSpanYear.ToString() + " Years   " + lifeSpanDay.ToString() + " Days";
    }

    public void showWarning()
    {
        warning.SetActive(true);
    }
    public void hideWarning()
    {
        warningText.GetComponent<TextMeshProUGUI>().text = "You cannot do this action right now.";
        warning.SetActive(false);
    }

    public void showInventory()
    {
        hideCharacterScreen();
        hideCultivationScreen();
        
        Inventory.SetActive(true);
        showInventoryButton.SetActive(false);
        hideInventoryButton.SetActive(true);
        inventoryButton.SetActive(true);
        characterScreenButton.SetActive(true);
    }

    public void hideInventory()
    {
        Inventory.SetActive(false);
        showInventoryButton.SetActive(true);
        hideInventoryButton.SetActive(false);
        inventoryButton.SetActive(false);
        characterScreenButton.SetActive(false);
    }

    public void showCharacterScreen()
    {
        for (int i = 0; i < CharacterScreen.transform.childCount; i++)
        {
            CharacterScreen.transform.GetChild(i).gameObject.SetActive(true);

            if(CharacterScreen.transform.GetChild(i).GetComponent<UnityEngine.UI.Image>() != null)
            {
                CharacterScreen.transform.GetChild(i).GetComponent<UnityEngine.UI.Image>().enabled = true;

                if(CharacterScreen.transform.GetChild(i).childCount > 0)
                {
                    CharacterScreen.transform.GetChild(i).GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = true;
                    //CharacterScreen.transform.GetChild(i).GetChild(0).GetComponent<UnityEngine.UI.Button>().enabled = true;
                }
            }
        }
    }

    public void hideCharacterScreen()
    {
        for (int i = 0; i < CharacterScreen.transform.childCount; i++)
        {
            CharacterScreen.transform.GetChild(i).gameObject.SetActive(false);
            if (CharacterScreen.transform.GetChild(i).GetComponent<UnityEngine.UI.Image>() != null)
            {
                CharacterScreen.transform.GetChild(i).GetComponent<UnityEngine.UI.Image>().enabled = false;

                if (CharacterScreen.transform.GetChild(i).childCount > 0)
                {
                    CharacterScreen.transform.GetChild(i).GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = false;
                    //CharacterScreen.transform.GetChild(i).GetChild(0).GetComponent<UnityEngine.UI.Button>().enabled = false;
                }
            }
        }
    }

    public void showInventoryAndHideCharacterScreen()
    {
        Inventory.SetActive(true);
        for (int i = 0; i < CharacterScreen.transform.childCount; i++)
        {
            CharacterScreen.transform.GetChild(i).gameObject.SetActive(false);
            if (CharacterScreen.transform.GetChild(i).GetComponent<UnityEngine.UI.Image>() != null)
            {
                CharacterScreen.transform.GetChild(i).GetComponent<UnityEngine.UI.Image>().enabled = false;

                if (CharacterScreen.transform.GetChild(i).childCount > 0)
                {
                    CharacterScreen.transform.GetChild(i).GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = false;
                    //CharacterScreen.transform.GetChild(i).GetChild(0).GetComponent<UnityEngine.UI.Button>().enabled = false;
                }
            }
        }
    }

    public void hideInventoryAndShowCharacterScreen()
    {
        Inventory.SetActive(false);
        for (int i = 0; i < CharacterScreen.transform.childCount; i++)
        {
            CharacterScreen.transform.GetChild(i).gameObject.SetActive(true);
            if (CharacterScreen.transform.GetChild(i).GetComponent<UnityEngine.UI.Image>() != null)
            {
                CharacterScreen.transform.GetChild(i).GetComponent<UnityEngine.UI.Image>().enabled = true;

                if (CharacterScreen.transform.GetChild(i).childCount > 0)
                {
                    CharacterScreen.transform.GetChild(i).GetChild(0).GetComponent<UnityEngine.UI.Image>().enabled = true;
                    //CharacterScreen.transform.GetChild(i).GetChild(0).GetComponent<UnityEngine.UI.Button>().enabled = true;
                }
            }
        }
    }
}
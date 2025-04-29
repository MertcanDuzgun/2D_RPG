using UnityEngine;
using System.Collections;
using TMPro;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using Unity.VisualScripting;

public class Material : MonoBehaviour
{
    [SerializeField] private int maxQuantity;
    [SerializeField] private int currentQuantity;
    [SerializeField] private string description;
    [SerializeField] private string rarity;
    [SerializeField] private string type;
    [SerializeField] private string usage;

    private GameObject gameController;
    private GameObject uiController;
    private GameObject sceneMaterials;

    private void Start()
    {
        this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { showMaterialDetails(); });
        this.GetComponent<UnityEngine.UI.Button>().enabled = false;

        gameController = GameObject.FindGameObjectWithTag("GameController");
        sceneMaterials = GameObject.FindGameObjectWithTag("sceneMaterials");
        uiController = GameObject.FindGameObjectWithTag("UIController");
    }

    private void Update()
    {
        if (currentQuantity > maxQuantity)
        {
            Debug.Log("Current quantity was higher than maxQuantity then currentQuantity was set to maxQuantity -Consumable-");
            currentQuantity = maxQuantity;
        }
        else if (currentQuantity == 0)
        {
            this.GetComponent<Button>().enabled = false;
            this.GetComponent<Image>().enabled = false;
            this.transform.parent = sceneMaterials.transform;
        }
        else if (currentQuantity < 0)
        {
            Debug.Log("Consumable quantity lower than zero!");
        }
    }

    public void showMaterialDetails()
    {
        uiController.GetComponent<UI_Controller>().activateMaterialDetails();
        uiController.GetComponent<UI_Controller>().setMaterialDetails(
                        this.GetComponent<UnityEngine.UI.Image>().sprite, this.name, description, currentQuantity.ToString(), maxQuantity.ToString(), getRarity(), getType(),getUsage());
    }

    public void hideMaterialDetails()
    {
        uiController.GetComponent<UI_Controller>().deactivateMaterialDetails();
    }

    public string getType()
    {
        return type;
    }

    public string getRarity()
    {
        return rarity;
    }

    public string getUsage()
    {
        return usage;
    }

    public string getDescription()
    {
        return description;
    }

    public int getMaxQuantity()
    {
        return maxQuantity;
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

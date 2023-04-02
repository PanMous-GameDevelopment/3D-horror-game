using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Health UI")]
    public Image healthBarImage;
    [SerializeField] private Slider healthBarSlider;

    [Header("Stamina UI")]
    public Image staminaBarImage;
    [SerializeField] private Slider staminaBarSlider;

    [Header("Inventory UI")]
    public GameObject inventoryUI;
    public AudioSource bagOpenAudio;
    public AudioSource bagCloseAudio;

    [Header("Interaction UI")]
    public Camera mainCamera;
    public float interactionDistance = 2f;
    public GameObject interactionUI;

    public static bool inventoryIsOpen = false;

    [Header("Contract UI")]
    public GameObject contractText;
    public GameObject contract;
    public AudioSource contractAudio;
    private bool contractIsOpen = false;

    private void OnEnable()
    {
        FirstPersonController.OnDamage += UpdateHealth;
        FirstPersonController.OnHeal += UpdateHealth;
        FirstPersonController.OnStaminaChange += UpdateStamina;
    }

    private void OnDisable()
    {
        FirstPersonController.OnDamage -= UpdateHealth;
        FirstPersonController.OnHeal -= UpdateHealth;
        FirstPersonController.OnStaminaChange -= UpdateStamina;
    }

    private void Start()
    {
        UpdateHealth(100);       
    }

    void Update()
    {
        // Contract.
        if (Input.GetKeyDown(KeyCode.R))
        {
            contractText.SetActive(false);

            if (contractIsOpen == false) // Opens the contract UI.
            {
                contractAudio.Play();
                contract.SetActive(true);
                contractIsOpen = true;
            }
            else if (contractIsOpen == true) // Closes the contract UI.
            {
                contractAudio.Play();
                contract.SetActive(false);
                contractIsOpen = false;
            }
        }

        // Inventory.
        if (Input.GetKeyDown(KeyCode.Tab))
        { 
            if (inventoryIsOpen == false) // Opens the inventory UI.
            {
                OpenInventory();
                inventoryIsOpen = true;
            }
            else if (inventoryIsOpen == true) // Closes the inventory UI.
            {
                CloseInventory();
                Debug.Log("Inventory is Closed");
                inventoryIsOpen = false;
            }
        }

        DetectInteractableObject();
    }

    private void UpdateHealth(float currentHealth)
    {
        
        healthBarSlider.value = currentHealth; // Controls the health bar.
    }

    private void UpdateStamina(float currentStamina)
    {

        staminaBarSlider.value = currentStamina; // Controls the stamina bar.
    }

    void OpenInventory()
    {
        inventoryUI.SetActive(true);
        bagOpenAudio.Play();
    }

    void CloseInventory()
    {
        inventoryUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        bagCloseAudio.Play();
    }

    // Detect any interactable objects in front of the player.
    void DetectInteractableObject()
    {
        Ray ray = mainCamera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitInteractable = false;

        if (Physics.Raycast(ray, out hit, interactionDistance)) // Cast raycast.
        {
            if ((hit.collider.gameObject.layer == 8) || (hit.collider.gameObject.layer == 9)) // If the object is of layer 8 or 9 then activate the interaction UI.
                hitInteractable = true;
        }

        interactionUI.SetActive(hitInteractable);
    }

}

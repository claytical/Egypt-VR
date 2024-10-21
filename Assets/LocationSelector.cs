using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Location
{
    public string locationName;
    public Sprite thumbnail;
    public Transform worldPosition;
}




public class LocationSelector : MonoBehaviour
{
    public List<Location> locations;  // List of locations
    public Image thumbnailImage;      // Reference to the UI Image for the thumbnail
    public TextMeshProUGUI locationNameText;     // Reference to the UI Text for the name
    public Transform player;          // Reference to the player’s transform for teleportation

    private int currentIndex = 0;     // Track the current location index

    void Start()
    {
        UpdateLocationUI();  // Initialize the UI with the first location's details
    }

    public void OnNextLocation()
    {
        currentIndex = (currentIndex + 1) % locations.Count;
        UpdateLocationUI();
    }

    public void OnPreviousLocation()
    {
        currentIndex = (currentIndex - 1 + locations.Count) % locations.Count;
        UpdateLocationUI();
    }

    public void TeleportToLocation()
    {
        if (player != null)
        {
            player.position = locations[currentIndex].worldPosition.position;
        }
    }

    private void UpdateLocationUI()
    {
        locationNameText.text = locations[currentIndex].locationName;
        thumbnailImage.sprite = locations[currentIndex].thumbnail;
    }
}

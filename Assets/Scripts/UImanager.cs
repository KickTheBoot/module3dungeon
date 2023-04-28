using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class UImanager : MonoBehaviour
{
    [SerializeField] UIDocument document;

    TextElement healthText, keyText;
    [HideInInspector]
    public PlayerCharacter trackedPlayer;





    // Start is called before the first frame update
    void Start()
    {
        VisualElement container = document.rootVisualElement.Q<VisualElement>("GUI");
        healthText = document.rootVisualElement.Q<TextElement>(name:"Health");
        keyText = document.rootVisualElement.Q<TextElement>(name:"Keys");
    }

    void Update()
    {
        healthText.text = $"Health: {trackedPlayer.health.health}/{trackedPlayer.health.maxHealth}";
        keyText.text = $"Keys: {trackedPlayer.KeyCount}";
    }
}

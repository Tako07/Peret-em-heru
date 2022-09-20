using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Statua : MonoBehaviour
{
    public bool isOpen;
    [SerializeField] GameObject arrowPanel;
    [SerializeField] GameObject dialogPanel;
    [SerializeField] TMP_Text helpText;
    [SerializeField] int arrowQuantity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openUIPanel(){
        arrowPanel.GetComponent<RadomArrowDirections>().arrowQuantity = arrowQuantity;
        arrowPanel.GetComponent<RadomArrowDirections>().interactableObject = "statua";
        helpText.text = "<i>Intenta recordar... memoriza y anota el orden correcto</i>";
        arrowPanel.SetActive(true);
        dialogPanel.SetActive(true);
    }
}
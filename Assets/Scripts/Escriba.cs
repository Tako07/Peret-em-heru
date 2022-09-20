using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Escriba : MonoBehaviour
{
    // Start is called before the first frame update
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
        arrowPanel.GetComponent<RadomArrowDirections>().interactableObject = "escriba";
        helpText.text = "<i>Intenta recordar... memoriza y anota el orden correcto</i>";
        arrowPanel.SetActive(true);
        dialogPanel.SetActive(true);
        Debug.Log("working");
    }
}

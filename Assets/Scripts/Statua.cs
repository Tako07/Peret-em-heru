using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statua : MonoBehaviour
{
    public bool isOpen;
    [SerializeField] GameObject arrowPanel;
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
        arrowPanel.SetActive(true);
    }
}
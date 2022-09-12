using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
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
        arrowPanel.SetActive(true);
    }
}

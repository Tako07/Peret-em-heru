using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escriba : MonoBehaviour
{
    // Start is called before the first frame update
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

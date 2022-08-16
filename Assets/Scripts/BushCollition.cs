using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushCollition : MonoBehaviour
{
    [SerializeField] GameObject panel;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collition");
        if (panel != null)
            panel.SetActive(true);
    }
}

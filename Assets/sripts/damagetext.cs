using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class damagetext : MonoBehaviour
{
    public int damage = 0;
    [SerializeField] private TextMeshProUGUI texts;
    // Start is called before the first frame update
    void Start()
    {
        texts.text = "-"+damage.ToString();
    }

    void distroy()
    {
        Destroy(gameObject);
    }

    
}

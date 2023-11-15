using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class settext : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI thistext;
    [SerializeField] private string intneeded;
    // Start is called before the first frame update
    void Start()
    {
        thistext.text = gettext(intneeded).ToString();
    }

    int gettext(string prefabstr)
    {
        return PlayerPrefs.GetInt(prefabstr,0);
    }
    void Update()
    {
        thistext.text = gettext(intneeded).ToString();
    }
}

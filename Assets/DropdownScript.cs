using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownScript : MonoBehaviour
{

    private Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = this.GetComponent<Dropdown>();
        dropdown.ClearOptions();
        List<Dropdown.OptionData> optionsList = new List<Dropdown.OptionData>();
        optionsList.Add(new Dropdown.OptionData("TestValue"));
        dropdown.AddOptions(optionsList);
        dropdown.RefreshShownValue();
    }

    public void ReadValue()
    {
        Debug.Log(dropdown.options[dropdown.value].text);
    }
}

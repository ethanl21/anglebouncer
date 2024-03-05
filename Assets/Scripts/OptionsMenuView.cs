using UnityEngine;
using UnityEngine.UIElements;

public class OptionsMenuView : MonoBehaviour
{
    private UIDocument _uiDocument;
    
    private void OnEnable()
    {
        // Get the UI document component
        _uiDocument = GetComponent<UIDocument>();
        var root = _uiDocument.rootVisualElement;
        
        var tabsRadioButtons = root.Q<RadioButtonGroup>("TabsRadioButtonGroup");
        tabsRadioButtons.RegisterValueChangedCallback(evt => OnTabsValueChanged(evt.previousValue, evt.newValue));
    }
    
    private void OnTabsValueChanged(int previousValue, int newValue)
    {
        var root = _uiDocument.rootVisualElement;
        var tabItemContainer = root.Q<VisualElement>("TabItemContainer");
        
        // Hide the tab item at index previousValue
        var previousTabItem = tabItemContainer.ElementAt(previousValue);
        previousTabItem.style.display = DisplayStyle.None;
        
        // Show the tab item at index newValue
        var newTabItem = tabItemContainer.ElementAt(newValue);
        newTabItem.style.display = DisplayStyle.Flex;
    }
}

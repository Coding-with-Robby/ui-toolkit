using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PanelRenderer))]
public class NewMonoBehaviourScript : MonoBehaviour
{
    private PanelRenderer panelRenderer;
    private VisualElement rootEL;

    private void Awake()
    {
        panelRenderer = GetComponent<PanelRenderer>();
    }

    private void OnEnable()
    {
        if (panelRenderer == null)
        {
            panelRenderer = GetComponent<PanelRenderer>();
        }

        panelRenderer.RegisterUIReloadCallback(HandleUILoad);
    }

    private void OnDisable()
    {
        panelRenderer.UnregisterUIReloadCallback(HandleUILoad);
    }

    private void HandleUILoad(
        PanelRenderer _,
        VisualElement rootElement,
        int __)
    {
        rootEL = rootElement;

        List<VisualElement> boxes =
            rootEL.Query(className: "box").ToList();

        foreach (VisualElement box in boxes)
        {
            box.AddToClassList("bg-orange");

            Label label123 =
                box.Q<Label>(className: "text");

            label123.name = "new-name";
            label123.text = "Box!!!!";
        }
    }
}

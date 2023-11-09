using System;
using UnityEngine;
using UnityEngine.UIElements;

public class LoginManager : MonoBehaviour
{
    [SerializeField] private UIDocument uiDoc;
    private VisualElement rootEl;
    private TextField emailEl;
    private TextField passwordEl;
    private Button buttonEl;

    private void OnEnable()
    {
        rootEl = uiDoc.rootVisualElement;
        emailEl = rootEl.Q<TextField>(className: "login-email");
        passwordEl = rootEl.Q<TextField>(className: "login-password");
        buttonEl = rootEl.Q<Button>(className: "login-button");

        passwordEl.isPasswordField = true;

        buttonEl.RegisterCallback<ClickEvent>(HandleSubmit);
    }

    private void HandleSubmit(ClickEvent evt)
    {
        string email = emailEl.value;
        string password = passwordEl.value;
        Debug.Log($"{email} / {password}");
    }
}
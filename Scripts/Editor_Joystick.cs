using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Editor_Joystick
{
    static GameObject canvasObj;
    static Canvas canvas;
    static CanvasScaler cScaler;

    static Sprites_Model model;
    static GameObject eventSystem;

    static GameObject joystickBG;
    static RectTransform joystickBgRect;
    static Image joystickBgImage;

    static GameObject joystickHandler;
    static RectTransform joystickHandlerRect;
    static Image joystickHandlerImage;

    static Sprite joystickBackground, joystickHandlerSprite;

    [MenuItem("Tools/Joystick")]
    static void Init()
    {
        canvasObj = new GameObject();
        canvas = canvasObj.AddComponent<Canvas>();
        cScaler = canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();
        CreateEventSystem();

        canvasObj.name = "Canvas";
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        cScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        cScaler.referenceResolution = new Vector2(Screen.width, Screen.height);

        model = canvasObj.AddComponent<Sprites_Model>();
        joystickBackground = model.background;
        joystickHandlerSprite = model.handler;

        CreateJoystickBG(Screen.width / 5.0f);

    }

    static void CreateEventSystem()
    {
        eventSystem = new GameObject();
        eventSystem.name = "EventSystem";
        eventSystem.AddComponent<EventSystem>();
        eventSystem.AddComponent<StandaloneInputModule>();
    }

    static void CreateJoystickBG(float size)
    {
        joystickBG = new GameObject();
        joystickBG.name = "JoystickBG";
        joystickBG.transform.SetParent(canvasObj.transform);
        joystickBgRect = joystickBG.AddComponent<RectTransform>();
        joystickBgImage = joystickBG.AddComponent<Image>();

        joystickBgRect.anchoredPosition = Vector2.zero;
        joystickBgRect.sizeDelta = new Vector2(size, size);
        joystickBgImage.sprite = joystickBackground;
        CreateJoystickHandler(size / 2.0f);
    }

    static void CreateJoystickHandler(float size)
    {
        joystickHandler = new GameObject();
        joystickHandler.name = "Handler";
        joystickHandler.transform.SetParent(joystickBG.transform);
        joystickHandlerRect = joystickHandler.AddComponent<RectTransform>();
        joystickHandlerImage = joystickHandler.AddComponent<Image>();

        joystickHandlerRect.anchoredPosition = Vector2.zero;
        joystickHandlerRect.sizeDelta = new Vector2(size, size);
        joystickHandlerImage.sprite = joystickHandlerSprite;

        joystickHandler.AddComponent<Joystick>();
    }
}

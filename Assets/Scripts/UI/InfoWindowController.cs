using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoWindowController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textComponent;
    private CanvasGroup canvasGroup;

    private Queue<string> messageQueue = new Queue<string>();
    private bool isShowingMessage = false;

    private void Awake()
    {
        TutorialManager.TutorialEvent += TutorialManager_TutorialEvent;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void TutorialManager_TutorialEvent(TutorialEventArgs e)
    {
        PushMessage(e.TutorialText);
    }

    /// <summary>
    /// ��������� ��������� � ������� ������ �� �����
    /// </summary>
    public void PushMessage(string message)
    {
        if (isShowingMessage)
        {
            messageQueue.Enqueue(message);
            return;
        }
        textComponent.text = message;

        Show();
        isShowingMessage = true;
    }

    /// <summary>
    /// ������� ��������� ��������� � �������, ��� �������� ����, ���� ������� �����������.
    /// </summary>
    public void PassMessage()
    {
        isShowingMessage = false;
        Hide();

        if (messageQueue.Count > 0)
        {
            PushMessage(messageQueue.Dequeue());
        }
    }

    /// <summary>
    /// ���������� ���� ����������
    /// </summary>
    public void Show()
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// �������� ���� ����������
    /// </summary>
    public void Hide()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}

using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class QuizManagement : MonoBehaviour
{
    private readonly string[] _topicList = {"Kinematics"};

    private readonly Dictionary<string, QuestionLoader> _topicToQuestion = new Dictionary<string, QuestionLoader>();
    private Question[] _currentQuestions;
    private int _currentQuestionIndex;
    private double _currentAnswer;

    [FormerlySerializedAs("questionUIText")] public TextMeshProUGUI questionUiText;
    public TextMeshProUGUI correctText;
    public Button checkAnswerButton;
    public TMP_InputField answerInputText;
    public GameObject panel;

    private Image PanelImage => panel.GetComponent<Image>();

    void Start()
    {
        foreach (var topic in _topicList)
        {
            _topicToQuestion[topic] = new QuestionLoader($"Questions/{topic}");
        }
        
        checkAnswerButton.onClick.AddListener(OnCheckAnswerClick);
        questionUiText.alignment = TextAlignmentOptions.Center;
        
        panel.SetActive(false);
        
        SetCurrentQuestions("Kinematics");
    }

    void SetCurrentQuestions(string topic)
    {
        _currentQuestions = _topicToQuestion[topic].Questions;

        _currentQuestionIndex = 0;
        questionUiText.text = _currentQuestions[0].text;

        _currentAnswer = Convert.ToDouble(_currentQuestions[0].ans);
    }

    void OnCheckAnswerClick()
    {
        double userAnswer;
        panel.SetActive(true);

        if (!Double.TryParse(answerInputText.text.Trim(), out userAnswer))
        {
            HandleIncorrectAnswer();
            return;
        }

        var answerTolerance = Math.Abs(_currentAnswer * 0.05);
        print($"Expecting answer: {_currentAnswer}");
        if (Math.Abs(userAnswer - _currentAnswer) > answerTolerance)
        {
            HandleIncorrectAnswer();
            return;
        }
        
        PanelImage.color = new Color32(0, 183, 14, 100);
        correctText.color = Color.white;
        correctText.text = "Correct";
        
        _currentQuestionIndex++;

        if (_currentQuestionIndex == _currentQuestions.Length)
        {
            
        }
        questionUiText.text = _currentQuestions[_currentQuestionIndex].text;
        _currentAnswer = Convert.ToDouble(_currentQuestions[_currentQuestionIndex].ans);
    }

    void HandleIncorrectAnswer()
    {
        PanelImage.color = new Color32(248, 0, 29, 100);
        correctText.color = Color.white;
        correctText.text = "Incorrect";
    }
}

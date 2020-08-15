using System;
using System.Linq;
using System.Text;
using MoonSharp.Interpreter;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class SerializedQuestions
{
    public Question[] questions;
}

[Serializable]
public class Question
{
    public string text;
    public string ans;
}

public class QuestionLoader 
{
    private readonly Script _script;
    public Question[] Questions { get; }

    public QuestionLoader(string questionsFile, bool doNotSeed = false)
    {
        _script = new Script();

        var jsonData = Resources.Load<TextAsset>(questionsFile);
        Debug.Log(jsonData);
        Questions = JsonUtility.FromJson<SerializedQuestions>(jsonData.text).questions;

        if (!doNotSeed)
        {
            _script.DoString("math.randomseed(os.time())");
        }
        
        foreach (var question in Questions)
        {
            question.text = ParseAndGetQuestion(question.text);
            question.ans = ParseAndGetAnswer(question.ans);
        }
    }

    public DynValue RunString(string input) => _script.DoString(input);

    private double ParseAndRunStatements(string statements)
    {
        var statementArray = statements.Split(';');
        var expressionToReturn = statementArray.Last();
        
        foreach (var statement in statementArray.Take(statementArray.Length - 1))
        {
            _script.DoString(statement);
        }

        var result = _script.Globals.Get(expressionToReturn);

        return result.Number;
    }

    private string ParseAndGetQuestion(string question)
    {
        var sb = new StringBuilder();

        var i = 0;
        while (i < question.Length)
        {
            if (question[i] == '$')
            {
                var nextDollarSign = question.IndexOf('$', i + 1);
                var statementsLength = nextDollarSign - i - 1;
                var statements = question.Substring(i + 1, statementsLength);

                sb.Append($"{ParseAndRunStatements(statements):0.00}");
                
                i = nextDollarSign + 1;
            }
            else
            {
                sb.Append(question[i]);
                i++;
            }
        }

        return sb.ToString();
    }

    private string ParseAndGetAnswer(string statement)
    {
        var answer = _script.DoString(statement);
        return $"{_script.Globals.Get("ans").Number:0.00}";
    }
}

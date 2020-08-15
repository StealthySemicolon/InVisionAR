using System.Linq;
using System.Text;
using MoonSharp.Interpreter;

public class LuaWrapper 
{
    private Script _script;

    public LuaWrapper(bool doNotSeed = false)
    {
        _script = new Script();


        if (!doNotSeed)
        {
            _script.DoString("math.randomseed(os.time())");
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

        var result = _script.DoString(expressionToReturn);

        return result.Number;
    }

    public string ParseQuestion(string question)
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

                sb.Append(ParseAndRunStatements(statements));
                
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

}

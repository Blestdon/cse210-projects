using System;
using System.Collections.Generic;

class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "How did I see the hand of the Lord in my life today?"
    };

    private HashSet<string> _usedPrompts = new HashSet<string>();

    public string GetRandomPrompt()
    {
        var availablePrompts = _prompts.FindAll(p => !_usedPrompts.Contains(p));
        if (availablePrompts.Count == 0)
        {
            _usedPrompts.Clear();
            availablePrompts = new List<string>(_prompts);
        }

        Random rnd = new Random();
        string prompt = availablePrompts[rnd.Next(availablePrompts.Count)];
        _usedPrompts.Add(prompt);
        return prompt;
    }
}

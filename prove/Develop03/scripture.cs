using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        foreach (string part in text.Split(' '))
        {
            _words.Add(new Word(part));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<int> availableWords = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                availableWords.Add(i);
            }
        }

        for (int i = 0; i < numberToHide && availableWords.Count > 0; i++)
        {
            int randomIndex = _random.Next(availableWords.Count);
            int wordIndex = availableWords[randomIndex];

            _words[wordIndex].Hide();
            availableWords.RemoveAt(randomIndex);
        }
    }


    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(w => w.DisplayText()));
        return $"{_reference.GetReference()} - {text}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
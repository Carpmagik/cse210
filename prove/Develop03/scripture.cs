using System;

public class Scripture
{
    private Reference _reference;
    private string _text;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _text = text;
    }

    public void Display()
    {
        Console.WriteLine($"{_reference.GetReference()} - {_text}");
    }
}
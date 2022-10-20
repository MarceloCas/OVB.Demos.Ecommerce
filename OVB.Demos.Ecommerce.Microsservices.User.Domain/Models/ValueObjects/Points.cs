﻿namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

public class Points
{
    private int Value { get; }

    public Points(int value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public int GetValue()
    {
        return Value;
    }
}

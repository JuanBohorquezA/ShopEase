using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEase.Domain.Exceptions;

public class FluentValidationException : Exception
{
    public IEnumerable<string> Errors { get; }

    public FluentValidationException(IEnumerable<string> errors) : base(CreateErrorMessage(errors))
    {
        Errors = errors;
    }

    private static string CreateErrorMessage(IEnumerable<string> errors)
    {
        var sb = new StringBuilder();
        foreach (var error in errors)
        {
            sb.AppendLine(error);
        }
        return sb.ToString();
    }
}

﻿using Microsoft.CodeAnalysis;

#nullable enable

namespace Microsoft.DocAsCode.Dotnet;

internal static partial class SymbolUrlResolver
{
    public static string? GetSymbolUrl(ISymbol symbol, Compilation compilation)
    {
        return GetMicrosoftLearnUrl(symbol)
            ?? GetPdbSourceLinkUrl(compilation, symbol);
    }
}

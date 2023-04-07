﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using YamlDotNet.Serialization;

namespace Microsoft.DocAsCode.Dotnet;

[Serializable]
internal class AttributeFilterInfo
{
    [YamlMember(Alias = "uid")]
    public string Uid { get; set; }

    [YamlMember(Alias = "ctorArguments")]
    public List<string> ConstructorArguments { get; set; }

    [YamlMember(Alias = "ctorNamedArguments")]
    public Dictionary<string, string> ConstructorNamedArguments { get; set; } = new Dictionary<string, string>();

    public bool ContainedIn(SymbolFilterData symbol)
    {
        bool result = false;
        var attributes = symbol.Attributes;
        foreach (var attribute in attributes)
        {
            if (Uid != attribute.Id)
            {
                continue;
            }

            // arguments need to be a total match of the config
            if (ConstructorArguments != null && !ConstructorArguments.SequenceEqual(attribute.ConstructorArguments))
            {
                continue;
            }

            // namedarguments need to be a superset of the config
            if (!ConstructorNamedArguments.Except(attribute.ConstructorNamedArguments).Any())
            {
                result = true;
                break;
            }
        }

        return result;
    }
}

﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace Microsoft.DocAsCode.Build.ManagedReference.BuildOutputs;

[Serializable]
public class ApiLanguageValuePair
{
    [YamlMember(Alias = "lang")]
    [JsonProperty("lang")]
    public string Language { get; set; }

    [YamlMember(Alias = "value")]
    [JsonProperty("value")]
    public string Value { get; set; }
}
﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FileGenerator.Native
{
    [DataContract]
    internal sealed class MagickCleanupMethod
    {
        [DataMember(Name = "arguments")]
        private List<string> _arguments = new List<string>();

        [DataMember(Name = "name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<string> Arguments
        {
            get
            {
                if (_arguments is not null)
                {
                    foreach (var argument in _arguments)
                    {
                        yield return argument;
                    }
                }
            }
        }
    }
}

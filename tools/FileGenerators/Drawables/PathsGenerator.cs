﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.Reflection;

namespace FileGenerator.Drawables
{
    internal sealed class PathsGenerator : DrawableCodeGenerator
    {
        private PathsGenerator()
            : base(false)
        {
        }

        public static void Generate()
        {
            var generator = new PathsGenerator();
            generator.CreateWriter(PathHelper.GetFullPath(@"src\Magick.NET\Drawables\Paths\Generated\Paths.cs"));
            generator.WriteStart("ImageMagick");
            generator.WritePaths();
            generator.WriteEnd();
            generator.CloseWriter();
        }

        protected override void WriteUsing()
        {
            WriteLine("using System.Collections.Generic;");
            WriteQuantumType();
        }

        private void WritePath(ConstructorInfo constructor)
        {
            var name = constructor.DeclaringType!.Name.Substring(4);
            var parameters = constructor.GetParameters();

            foreach (var commentLine in Types.GetCommentLines(constructor, "Paths"))
                WriteLine(commentLine);
            Write("public IPaths<QuantumType> " + name + "(");
            WriteParameterDeclaration(parameters);
            WriteLine(")");
            WriteStartColon();
            Write("_paths.Add(new " + constructor.DeclaringType.Name + "(");
            WriteParameters(parameters);
            WriteLine("));");
            WriteLine("return this;");
            WriteEndColon();
            WriteLine();
        }

        private void WritePath(ConstructorInfo[] constructors)
        {
            foreach (var constructor in constructors)
            {
                WritePath(constructor);
            }
        }

        private void WritePaths()
        {
            WriteLine(@"[System.CodeDom.Compiler.GeneratedCode(""Magick.NET.FileGenerator"", """")]");
            WriteLine("public sealed partial class Paths");
            WriteStartColon();

            foreach (var path in Types.GetPathConstructorss())
            {
                WritePath(path);
            }

            WriteEndColon();
        }
    }
}

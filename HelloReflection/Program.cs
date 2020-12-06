using ILCompiler.Reflection.ReadyToRun;
using System;
using System.Reflection.Metadata;

namespace HelloReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadyToRunReader r = new ReadyToRunReader(new MyAssemblyResolver(), @"C:\temp\System.Private.CoreLib.dll");
            foreach (var method in r.Methods)
            {
                Console.WriteLine(method.SignatureString);
            }
        }
    }

    class MyAssemblyResolver : IAssemblyResolver
    {
        public IAssemblyMetadata FindAssembly(MetadataReader metadataReader, AssemblyReferenceHandle assemblyReferenceHandle, string parentFile)
        {
            throw new NotImplementedException();
        }

        public IAssemblyMetadata FindAssembly(string simpleName, string parentFile)
        {
            throw new NotImplementedException();
        }
    }
}


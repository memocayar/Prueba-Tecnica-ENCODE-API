using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services;

public class HelloWorldService : IHelloWorldService
{
    public String GetHelloWord()
    {
        return "Hello World!";
    }
}

public interface IHelloWorldService
{
    string GetHelloWord();
}

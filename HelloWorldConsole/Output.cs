using System;

namespace HelloWorldConsole
{
    public class Output
    {
        public virtual void Export(string msg)
        {
        }
    }

    public class ConsoleOutput: Output
    {
        public override void Export(string msg)
        {
            base.Export(msg);

            Console.WriteLine(msg);

        }
    }
}

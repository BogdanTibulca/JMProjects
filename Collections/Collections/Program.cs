using System;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectArray obj = new ObjectArray();
            obj.Add(1);
            obj.Add(true);
            obj.Add("test");
            obj.Add('c');
            obj.Add(23);
            obj.Add(false);

            foreach (object o in obj.ObjectElements())
            {
                Console.WriteLine(o);
            }
        }
    }
}

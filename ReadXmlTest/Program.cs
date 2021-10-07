using System;
using Password.Model;
using System.IO;

using System.Xml;

namespace ReadXmlTest
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlTextReader reader = new XmlTextReader(@"C:\#csprojects\PasswordStorage\SampleFiles\ReadStorage.xml");

            while (reader.Read())
            {
                string offset = new string(' ', reader.Depth);
                if(reader.NodeType == XmlNodeType.Element)
                { 

                    Console.Write($"{offset}<{reader.LocalName}");
                    if (reader.HasAttributes)
                    {
                        
                        Console.WriteLine();
                        int counter = reader.AttributeCount;
                        for (int i = 0; i < counter; i++)
                        {
                            reader.MoveToAttribute(i);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{offset} {reader.Name}={reader.Value}");
                            Console.ResetColor();
                        }
                        Console.WriteLine($"{offset} >");
                    }
                    else
                    {
                        Console.WriteLine($">");
                    }

                    
                }
                if(reader.NodeType == XmlNodeType.EndElement)
                {
                    Console.WriteLine($"{offset}</{reader.LocalName}>");
                }
                
                
                if(reader.NodeType == XmlNodeType.Text)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{offset} {reader.Value.Trim('\n')}");
                    Console.ResetColor();
                }
            }

            Console.ReadKey();
        }
    }
}

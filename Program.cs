using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CompareXMLKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 2)
            {
                var file1Name = args[0];
                var file2Name = args[1];
                List<string> result = new List<string>();           
                XmlDocument doc1 = new XmlDocument();
                doc1.Load(file1Name);
                XmlDocument doc2 = new XmlDocument();
                doc2.Load(file2Name);

                Dictionary<string, string> dict1 = new Dictionary<string, string>();
                foreach (XmlNode item in doc1.ChildNodes[1].ChildNodes[0].ChildNodes)
                    dict1[item.Attributes["name"].Value] = item.Attributes["name"].Value;
                foreach (XmlNode item in doc2.ChildNodes[1].ChildNodes[0].ChildNodes)
                {
                    if (!dict1.ContainsKey(item.Attributes["name"].Value))
                        result.Add(item.Attributes["name"].Value);
                }

                File.WriteAllLines(Guid.NewGuid().ToString() + ".txt", result.ToArray());

            } else
            {
                Console.WriteLine("need 2 files");
            }
        }
    }
}

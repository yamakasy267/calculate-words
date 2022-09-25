using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;


namespace ConsoleApplication3
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var dict = new Dictionary<int, string>();
            var lincetdict = new Dictionary<int, int>();
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.InitialDirectory = "C://";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePath = dlg.FileName;
                var fileStream = dlg.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream, Encoding.GetEncoding(1251)))
                {
                    string text;
                    while ((text = reader.ReadLine()) != null)
                    {
                        string[] arr = text.Split();
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (!dict.ContainsValue(arr[i]))
                            {
                                dict.Add(dict.Count + 1, arr[i]);
                                lincetdict.Add(lincetdict.Count + 1, 1);
                            }
                            else
                            {
                                var key = dict.First(x => x.Value == arr[i]).Key;
                                lincetdict[key] = lincetdict[key] + 1;
                            }
                        }
                        
                    }
                    reader.Close();
                    
                }
                using (StreamWriter writer = new StreamWriter("D:\\my project\\test", Encoding.GetEncoding(1251)))
                {

                }
            }
            else
            {
                Console.WriteLine("NOt file");
            }
        }
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zbast
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != null)
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("ZAC's BAS Tool");
                    Console.WriteLine("");
                    Console.WriteLine("Created by: TheZACAtac");
                    Console.WriteLine("Version: Beta");
                    Console.WriteLine("");
                    Console.WriteLine("Commands:");
                    Console.WriteLine("zbast decode SOURCE [DESTINATION]");
                    Console.WriteLine("  -Decodes SOURCE (a .bas file) into a text-based version and");
                    Console.WriteLine("   saves the file as a .txt. If DESTINATION is not defined, ");
                    Console.WriteLine("   then destination file is SOURCE.txt");
                    Console.WriteLine("zbast encode SOURCE [DESTINATION]");
                    Console.WriteLine("  -Encodes SOURCE (a .txt file) into a .bas. If DESTINATION ");
                    Console.WriteLine("   is not defined, then destination file is SOURCE.bas");
                    Console.WriteLine("zbast dump SOURCE");
                    Console.WriteLine("  -Dumps the data found within SOURCE (a .bas file).");
                }
                if ((args.Length >= 1) & (args.Length <=3))
                {
                    if (args[0].ToLower() == "decode")
                    {
                        if (args.Length == 1)
                        {
                            Console.WriteLine("Error: No file defined");
                        }
                        if (args.Length >= 2)
                        {
                            string Fsource = args[1];
                            string Fdest = "";
                            if (args.Length == 3)
                            {
                                Fdest = args[2];
                            }
                            if (args.Length == 2)
                            {
                                Fdest = Fsource + ".txt";
                            }
                            Console.WriteLine("Decode \""+ Fsource+ "\" --> \"" + Fdest+ "\"");
                            float Entrya = 0.0F;
                            float Entryb = 0.0F;
                            float Entryc = 0.0F;
                            float Entryd = 0.0F;
                            float Entrye = 0.0F;
                            if (!File.Exists(Fsource))
                            {
                                Console.WriteLine("Error: Source file does not exist");
                            }
                            if (File.Exists(Fdest))
                            {
                                Console.WriteLine("Error: Destination file already exists");
                            }
                            if (File.Exists(Fsource) & !File.Exists(Fdest))
                            {
                                using (BinaryReader b = new BinaryReader(
                                    File.Open(Fsource, FileMode.Open)))
                                {

                                    int length = (int)b.BaseStream.Length;

                                    if (length == 20)
                                    {
                                        int Aa = b.ReadByte();
                                        int Ab = b.ReadByte();
                                        int Ac = b.ReadByte();
                                        int Ad = b.ReadByte();
                                        int Ba = b.ReadByte();
                                        int Bb = b.ReadByte();
                                        int Bc = b.ReadByte();
                                        int Bd = b.ReadByte();
                                        int Ca = b.ReadByte();
                                        int Cb = b.ReadByte();
                                        int Cc = b.ReadByte();
                                        int Cd = b.ReadByte();
                                        int Da = b.ReadByte();
                                        int Db = b.ReadByte();
                                        int Dc = b.ReadByte();
                                        int Dd = b.ReadByte();
                                        int Ea = b.ReadByte();
                                        int Eb = b.ReadByte();
                                        int Ec = b.ReadByte();
                                        int Ed = b.ReadByte();

                                        byte[] Floater = new byte[] { (byte)Aa, (byte)Ab, (byte)Ac, (byte)Ad };
                                        var Floaters = Floater.Reverse().ToArray();
                                        Entrya = BitConverter.ToSingle(Floaters, 0);
                                        Floater = new byte[] { (byte)Ba, (byte)Bb, (byte)Bc, (byte)Bd };
                                        Floaters = Floater.Reverse().ToArray();
                                        Entryb = BitConverter.ToSingle(Floaters, 0);
                                        Floater = new byte[] { (byte)Ca, (byte)Cb, (byte)Cc, (byte)Cd };
                                        Floaters = Floater.Reverse().ToArray();
                                        Entryc = BitConverter.ToSingle(Floaters, 0);
                                        Floater = new byte[] { (byte)Da, (byte)Db, (byte)Dc, (byte)Dd };
                                        Floaters = Floater.Reverse().ToArray();
                                        Entryd = BitConverter.ToSingle(Floaters, 0);
                                        Floater = new byte[] { (byte)Ea, (byte)Eb, (byte)Ec, (byte)Ed };
                                        Floaters = Floater.Reverse().ToArray();
                                        Entrye = BitConverter.ToSingle(Floaters, 0);
                                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@Fdest, true))
                                        {
                                            file.WriteLine("#This is what a BAS text file looks like.");
                                            file.WriteLine("#Only the variables speed, unknown1, unknown2, unknown3, unknown4 can be encoded.");
                                            file.WriteLine("#All other variables will be skipped and the user will be informed about the unknown variable.");
                                            file.WriteLine("#The variables speed, unknown1, unknown2, unknown3, unknown4 do not have to be defined and default to 0.");
                                            file.WriteLine("#Variables can be defined more than once, but only the last definition will be encoded.");
                                            file.WriteLine("#Commands are separated by a new line.");
                                            file.WriteLine("#Only comments, definitions, and blank lines can exist within a BAS text file.");
                                            file.WriteLine("#The encoder only reads definitions.");
                                            file.WriteLine("#The encoder interprets lines with beginning spaces as if the beginning spaces did not exist.");
                                            file.WriteLine("# Examples: ");
                                            file.WriteLine("# \"  speed=25\" = \"speed=25\"");
                                            file.WriteLine("# \"   #comment\" = \"#comment\"");
                                            file.WriteLine("# \"   \" = \"\"");
                                            file.WriteLine("#The syntax for a defintion is as follows: <variable>=<value>");
                                            file.WriteLine("#Spaces may exist between the variable and equals sign as well as in between the value and equals sign, but a space cannot be included within a variable or value as this will return a syntax error.");
                                            file.WriteLine("# Examples: ");
                                            file.WriteLine("#  Acceptable:");
                                            file.WriteLine("#  speed=25");
                                            file.WriteLine("#  speed =25");
                                            file.WriteLine("#  speed = 25");
                                            file.WriteLine("#  unknown1=25");
                                            file.WriteLine("#  Unacceptable:");
                                            file.WriteLine("#  spe ed=2 5");
                                            file.WriteLine("#  speed=2 5");
                                            file.WriteLine("#  sp eed=2 5");
                                            file.WriteLine("#  unknown 1=25");
                                            file.WriteLine("#Definitions may have spaces at the end of the line as they will be interpretted as if they did not exist.");
                                            file.WriteLine("# Examples: ");
                                            file.WriteLine("# \"speed=25   \" = \"speed=25\"");
                                            file.WriteLine("# \"unknown1=25 \" = \"unknown1=25\"");
                                            file.WriteLine("#Lines using incorrect syntax will be skipped and the user will be informed about the line of the syntax error.");
                                            file.WriteLine("speed=" + Entrya.ToString());
                                            file.WriteLine("unknown1=" + Entryb.ToString());
                                            file.WriteLine("unknown2=" + Entryc.ToString());
                                            file.WriteLine("unknown3=" + Entryd.ToString());
                                            file.WriteLine("unknown4=" + Entrye.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (args[0].ToLower() == "encode")
                    {
                        if (args.Length == 1)
                        {
                            Console.WriteLine("Error: No file defined");
                        }
                        if (args.Length >= 2)
                        {
                            string Fsource = args[1];
                            string Fdest = "";
                            if (args.Length == 3)
                            {
                                Fdest = args[2];
                            }
                            if (args.Length == 2)
                            {
                                Fdest = Fsource + ".bas";
                            }
                            Console.WriteLine("Encode \"" + Fsource + "\" --> \"" + Fdest + "\"");
                            float Entrya = 0.0F;
                            float Entryb = 0.0F;
                            float Entryc = 0.0F;
                            float Entryd = 0.0F;
                            float Entrye = 0.0F;
                            if (!File.Exists(Fsource))
                            {
                                Console.WriteLine("Error: Source file does not exist");
                            }
                            if (File.Exists(Fdest))
                            {
                                Console.WriteLine("Error: Destination file already exists");
                            }
                            if (File.Exists(Fsource) & !File.Exists(Fdest))
                            {
                                string[] lines = System.IO.File.ReadAllLines(@Fsource);
                                for (int n = 0; n < lines.Length; n = n + 1)
                                {
                                    string sttr = lines[n];
                                    if (sttr != "")
                                    {
                                        while ((sttr.Substring(0, 1) == " "))
                                        {
                                            sttr = sttr.Substring(1);
                                        }
                                    }
                                    if (sttr != "")
                                    {
                                        if ((sttr.Substring(0, 1) != "#"))
                                        {
                                            int CountStringOccurrences(string text, string pattern)
                                            {
                                                // Loop through all instances of the string 'text'.
                                                int count = 0;
                                                int i = 0;
                                                while ((i = text.IndexOf(pattern, i)) != -1)
                                                {
                                                    i += pattern.Length;
                                                    count++;
                                                }
                                                return count;
                                            }
                                            while (sttr.Substring(sttr.Length - 1, 1) == " ")
                                            {
                                                sttr = sttr.Substring(0, sttr.Length - 1);
                                            }
                                            while (CountStringOccurrences(sttr, " =") > 0)
                                            {
                                                sttr = sttr.Replace(" =", "=");
                                            }
                                            while (CountStringOccurrences(sttr, "= ") > 0)
                                            {
                                                sttr = sttr.Replace("= ", "=");
                                            }
                                            if ((CountStringOccurrences(sttr, " ") > 0) |
                                                (CountStringOccurrences(sttr, "=") != 1)
                                                )
                                            {
                                                Console.WriteLine("Error: Syntax error on line " + (n + 1).ToString());
                                            }
                                            else
                                            {
                                                string lvar = (sttr.Substring(0, sttr.IndexOf("=")));
                                                string lval = (sttr.Substring(sttr.IndexOf("=") + 1));
                                                bool StringOnlyNumbers(string ttext)
                                                {
                                                    ttext = ttext.Replace(".", "");
                                                    ttext = ttext.Replace("0", "");
                                                    ttext = ttext.Replace("1", "");
                                                    ttext = ttext.Replace("2", "");
                                                    ttext = ttext.Replace("3", "");
                                                    ttext = ttext.Replace("4", "");
                                                    ttext = ttext.Replace("5", "");
                                                    ttext = ttext.Replace("6", "");
                                                    ttext = ttext.Replace("7", "");
                                                    ttext = ttext.Replace("8", "");
                                                    ttext = ttext.Replace("9", "");
                                                    if (ttext == "")
                                                    {
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        return false;
                                                    }
                                                }
                                                if (!StringOnlyNumbers(lval))
                                                {
                                                    Console.WriteLine("Error: Syntax error on line " + (n + 1).ToString());
                                                }
                                                else
                                                {
                                                    if (
                                                        (lvar != "speed") &
                                                        (lvar != "unknown1") &
                                                        (lvar != "unknown2") &
                                                        (lvar != "unknown3") &
                                                        (lvar != "unknown4")
                                                        )
                                                    {
                                                        Console.WriteLine("Error: Unknown variable on line " + (n + 1).ToString());
                                                    }
                                                    if (lvar == "speed")
                                                    {
                                                        Entrya = float.Parse(lval);
                                                    }
                                                    if (lvar == "unknown1")
                                                    {
                                                        Entryb = float.Parse(lval);
                                                    }
                                                    if (lvar == "unknown2")
                                                    {
                                                        Entryc = float.Parse(lval);
                                                    }
                                                    if (lvar == "unknown3")
                                                    {
                                                        Entryd = float.Parse(lval);
                                                    }
                                                    if (lvar == "unknown4")
                                                    {
                                                        Entrye = float.Parse(lval);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                byte[] Savebytes = null;
                                Savebytes = new byte[20];

                                byte[] hexier = BitConverter.GetBytes(Entrya);
                                byte[] hexy = hexier.Reverse().ToArray();
                                Savebytes[0] = hexy[0];
                                Savebytes[1] = hexy[1];
                                Savebytes[2] = hexy[2];
                                Savebytes[3] = hexy[3];
                                hexier = BitConverter.GetBytes(Entryb);
                                hexy = hexier.Reverse().ToArray();
                                Savebytes[4] = hexy[0];
                                Savebytes[5] = hexy[1];
                                Savebytes[6] = hexy[2];
                                Savebytes[7] = hexy[3];
                                hexier = BitConverter.GetBytes(Entryc);
                                hexy = hexier.Reverse().ToArray();
                                Savebytes[8] = hexy[0];
                                Savebytes[9] = hexy[1];
                                Savebytes[10] = hexy[2];
                                Savebytes[11] = hexy[3];
                                hexier = BitConverter.GetBytes(Entryd);
                                hexy = hexier.Reverse().ToArray();
                                Savebytes[12] = hexy[0];
                                Savebytes[13] = hexy[1];
                                Savebytes[14] = hexy[2];
                                Savebytes[15] = hexy[3];
                                hexier = BitConverter.GetBytes(Entrye);
                                hexy = hexier.Reverse().ToArray();
                                Savebytes[16] = hexy[0];
                                Savebytes[17] = hexy[1];
                                Savebytes[18] = hexy[2];
                                Savebytes[19] = hexy[3];

                                File.WriteAllBytes(Fdest, Savebytes);
                            }
                        }
                    }
                    if (args[0].ToLower() == "dump")
                    {
                        if (args.Length == 1)
                        {
                            Console.WriteLine("Error: No file defined");
                        }
                        if (args.Length == 2)
                        {
                            string Fsource = args[1];
                            float Entrya = 0.0F;
                            float Entryb = 0.0F;
                            float Entryc = 0.0F;
                            float Entryd = 0.0F;
                            float Entrye = 0.0F;
                            Console.WriteLine("Dump \"" + Fsource + "\"");
                            if (File.Exists(Fsource))
                            {
                                using (BinaryReader b = new BinaryReader(
                                    File.Open(Fsource, FileMode.Open)))
                                {

                                    int length = (int)b.BaseStream.Length;

                                    if (length == 20)
                                    {
                                        int Aa = b.ReadByte();
                                        int Ab = b.ReadByte();
                                        int Ac = b.ReadByte();
                                        int Ad = b.ReadByte();
                                        int Ba = b.ReadByte();
                                        int Bb = b.ReadByte();
                                        int Bc = b.ReadByte();
                                        int Bd = b.ReadByte();
                                        int Ca = b.ReadByte();
                                        int Cb = b.ReadByte();
                                        int Cc = b.ReadByte();
                                        int Cd = b.ReadByte();
                                        int Da = b.ReadByte();
                                        int Db = b.ReadByte();
                                        int Dc = b.ReadByte();
                                        int Dd = b.ReadByte();
                                        int Ea = b.ReadByte();
                                        int Eb = b.ReadByte();
                                        int Ec = b.ReadByte();
                                        int Ed = b.ReadByte();

                                        byte[] Floater = new byte[] { (byte)Aa, (byte)Ab, (byte)Ac, (byte)Ad };
                                        var Floaters = Floater.Reverse().ToArray();
                                        Entrya = BitConverter.ToSingle(Floaters, 0);
                                        Floater = new byte[] { (byte)Ba, (byte)Bb, (byte)Bc, (byte)Bd };
                                        Floaters = Floater.Reverse().ToArray();
                                        Entryb = BitConverter.ToSingle(Floaters, 0);
                                        Floater = new byte[] { (byte)Ca, (byte)Cb, (byte)Cc, (byte)Cd };
                                        Floaters = Floater.Reverse().ToArray();
                                        Entryc = BitConverter.ToSingle(Floaters, 0);
                                        Floater = new byte[] { (byte)Da, (byte)Db, (byte)Dc, (byte)Dd };
                                        Floaters = Floater.Reverse().ToArray();
                                        Entryd = BitConverter.ToSingle(Floaters, 0);
                                        Floater = new byte[] { (byte)Ea, (byte)Eb, (byte)Ec, (byte)Ed };
                                        Floaters = Floater.Reverse().ToArray();
                                        Entrye = BitConverter.ToSingle(Floaters, 0);
                                        Console.WriteLine("");
                                        Console.WriteLine("Variable:        Value:");
                                        Console.WriteLine("----------------------------------");
                                        Console.WriteLine("Speed            " + Entrya.ToString());
                                        Console.WriteLine("Unknown1         " + Entryb.ToString());
                                        Console.WriteLine("Unknown2         " + Entryc.ToString());
                                        Console.WriteLine("Unknown3         " + Entryd.ToString());
                                        Console.WriteLine("Unknown4         " + Entrye.ToString());
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error: File does not exist");
                            }
                        }
                        if (args.Length == 3)
                        {
                            Console.WriteLine("SYNTAX ERROR");
                        }
                    }
                }
                if (args.Length >= 4)
                {
                    Console.WriteLine("SYNTAX ERROR");
                }
            }
        }
    }
}

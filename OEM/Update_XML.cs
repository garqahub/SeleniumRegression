using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace SeleniumRegression
{
    class Update_XML
    {
        public static void XMLEdit(String tag, String id)
        {
            String oldId = "";
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                //it will change the id to ALL the connected devices
                if ((d.IsReady == true) && (d.DriveType == DriveType.Removable))
                {
                    //Console.WriteLine("Drive {0}", d.Name);
                    //Console.WriteLine("File type: {0}", d.DriveType);

                    String filePath = d.RootDirectory + "Garmin\\GarminDevice.xml";
                    //Console.WriteLine();

                    if (File.Exists(filePath))
                    {
                        //Modify as you wish depending on what you want to modify in the file.
                        //This example will search for the id and will stop when it will find it .
                        StreamReader reader = new StreamReader(File.OpenRead(filePath));

                        string fileContent = reader.ReadToEnd();
                        //Console.WriteLine(fileContent);
                        reader.Close();

                        //Modify this line if you want to change the values of other tag . 
                        Match match = Regex.Match(fileContent, "<" + tag + ">.*</" + tag + ">");
                        oldId = match.Value;

                        //Console.WriteLine("OLD ID: " + oldId);

                        fileContent = fileContent.Replace(oldId, "<" + tag + ">" + id + "</" + tag + ">");

                        StreamWriter writer = new StreamWriter(File.OpenWrite(filePath));
                        writer.Write(fileContent);
                        writer.Close();

                    }
                }
            }
        }

        public static void WriteXML(String XML_name)
        {
            StreamReader XMLreader = new StreamReader(File.OpenRead("..\\..\\" + XML_name + ".txt"));

            string XMLContent = XMLreader.ReadToEnd();

            XMLreader.Close();

            //Console.WriteLine(XMLContent);

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                //it will change the id to ALL the connected devices
                if ((d.IsReady == true) && (d.DriveType == DriveType.Removable))
                {
                    String filePath = d.RootDirectory + "Garmin\\GarminDevice.xml";

                    if (File.Exists(filePath))
                    {

                        StreamWriter writer = new StreamWriter(filePath);
                        writer.Write(XMLContent);

                        writer.Flush();
                        writer.Close();
                    }
                }
            }
        }
    }
}

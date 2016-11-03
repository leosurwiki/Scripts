using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace Assets
{
    public static class XmlSerializer
    {
        public static void SaveToXml(string filePath, object sourceObj)
        {
            if (sourceObj != null)
            {
                Type type = sourceObj.GetType();

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = 
                        new System.Xml.Serialization.XmlSerializer(type);
                    xmlSerializer.Serialize(writer, sourceObj);
                }
            }
        }

    }
    [XmlRootAttribute("GameRecord", Namespace = "Game.Game", IsNullable = false)]
    public class XMLGameRecord
    {
        [XmlAttribute("GameTag")]
        public string GameTag
        {
            get;
            set;
        }

        [XmlArrayAttribute("Frames")]
        public List<XMLFrame> Frames
        {
            get;
            set;
        }
        public XMLGameRecord()
        {
            Frames = new List<XMLFrame>();
        }
    }
    [XmlRootAttribute("Frame")]
    public class XMLFrame
    {
        [XmlAttribute("TimePoint")]
        public int TimePoint
        {
            get;
            set;
        }
        [XmlAttribute("Money")]
        public int Money
        {
            get;
            set;
        }
        [XmlArrayAttribute("EnemyDis")]
        public List<float> EnemyDis
        {
            get;
            set;
        }

        public XMLFrame()
        {
            EnemyDis = new List<float>();
        }
    }
}


//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 18.12.2007
//
//  Projekt.......: PicBrowser
//  Name..........: EXIF.cs
//  Aufgabe/Fkt...: Klasse zum kapseln des Zugriffs auf die EXIF- Daten
//                  
//
//
//
//
//<unit_environment>
//------------------------------------------------------------------
//  Zielmaschine..: PC 
//  Betriebssystem: Windows XP mit .NET 2.0
//  Werkzeuge.....: Visual Studio 2005
//  Autor.........: Martin Korneffel (mko)
//  Version 1.0...: 
//
// </unit_environment>
//
//<unit_history>
//------------------------------------------------------------------
//
//  Version.......: 1.1
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 13.6.2011
//  Änderungen....: Auslesen der EXIF- Infos aus BMP im Konstruktor implementiert.
//                  Verschoben aus dem Projekt PicBrowser in das Projekt DmsCore
//
//</unit_history>
//</unit_header>        

using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using System.Drawing.Imaging;

namespace DMS
{
    public class EXIF
    {
        public enum IFD_TAGS
        {
            ImageWidth = 256,
            ImageHeigth = 257,
            BitsPerPixel = 258,
            SamplesPerPixel = 277,
            RecordingTime = 306,
            CameraManufacturer = 271,
            CameraModel = 272,
            ExposureTime = 33434,
            ISO = 34855,
            SubjectDistance = 37382,
            Flash = 37385,
            FocalLength = 37386,
            FocalLength35 = 41989,
            Contrast = 41992,
            Saturation = 41993,
            Sharpness = 41994,
            SceneCaptureType = 41990,
            SensingMethod = 41495
        }

        public enum IFD_TYPES
        {
            Byte = 1,
            ASCII = 2,
            SHORT = 3,
            LONG = 4,
            RATIONAL = 5,
            undefined = 6,
            SLONG = 9,
            SRATIONAL = 10
        }

        public enum ExifSceneCaptureTypes
        {
            Standard = 0,
            Landscape = 1,
            Portrait = 2,
            NightScene = 3            
        }

        public enum ExifSensingMethod
        {
            Undefined = 1,
            OneChipColorAreaSensor = 2,
            TwoChipColorAreaSensor = 3,
            ThreeChipColorAreaSensor = 4,
            ColorSequentialAreaSensor = 5,
            TrilinearSensor = 6,
            ColorSequentialLinearSensor = 7
        }


        public string Path {get; set;}        
        public bool Flash {get; set;}
        public DateTime RecordingTime {get;set;}
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public double FocalLength { get; set; }
        public double FocalLength35 { get; set; }
        public double ExposureTime { get; set; }
        public ExifSceneCaptureTypes SceneCaptureType { get; set; }
        public ExifSensingMethod SensingMethod { get; set; }


        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="bmp">Bitmap, aud der die Exif- Daten zu entnehmen sind</param>
        public EXIF(System.Drawing.Image bmp)
        {

            // Auslesen der Metadaten
            foreach (System.Drawing.Imaging.PropertyItem item in bmp.PropertyItems)
            {
                switch ((DMS.EXIF.IFD_TAGS)item.Id)
                {
                    case DMS.EXIF.IFD_TAGS.ImageHeigth:
                        ImageHeight = DMS.EXIF.GetImageHeight(item);
                        break;
                    case DMS.EXIF.IFD_TAGS.ImageWidth:
                        ImageWidth = DMS.EXIF.GetImageWidth(item);
                        break;
                    case DMS.EXIF.IFD_TAGS.RecordingTime:
                        RecordingTime = DMS.EXIF.GetRecordingTime(item);
                        break;
                    case DMS.EXIF.IFD_TAGS.FocalLength:
                        FocalLength = DMS.EXIF.GetFocalLength(item);
                        break;
                    case EXIF.IFD_TAGS.FocalLength35:
                        FocalLength35 = DMS.EXIF.GetFocalLength35(item);
                        break;
                    case DMS.EXIF.IFD_TAGS.Flash:
                        Flash = DMS.EXIF.GetFlash(item);
                        break;
                    case DMS.EXIF.IFD_TAGS.ExposureTime:
                        ExposureTime = DMS.EXIF.GetExposureTime(item);
                        break;
                    default: ;
                        break;
                }
            }
        }

        class EXIF_Exception : ApplicationException
        {
            public IFD_TAGS tag;
            public EXIF_Exception(IFD_TAGS tag)
            {
                this.tag = tag;
            }
        }

        public static int GetImageWidth(PropertyItem item)
        {
            return ReadExifInt(IFD_TAGS.ImageWidth, item);
        }

        public static int GetImageHeight(PropertyItem item)
        {
            return ReadExifInt(IFD_TAGS.ImageHeigth, item);
        }

        public static ExifSceneCaptureTypes GetSceneCaptureTypes(PropertyItem item)
        {
            return (ExifSceneCaptureTypes) ReadExifInt(IFD_TAGS.SceneCaptureType, item);
        }

        public static ExifSensingMethod GetSensingMethod(PropertyItem item)
        {
            return (ExifSensingMethod)ReadExifInt(IFD_TAGS.SensingMethod, item);
        }

        private static int ReadExifInt(IFD_TAGS tag, PropertyItem item)
        {
            if (item.Id != (int)tag)
                throw new EXIF_Exception(tag);

            using (System.IO.MemoryStream mem = new System.IO.MemoryStream(item.Value))
            {
                System.IO.BinaryReader reader = new System.IO.BinaryReader(mem);
                if (item.Type == (int)IFD_TYPES.SHORT)
                    return (int)reader.ReadUInt16();
                else if (item.Type == (int)IFD_TYPES.LONG)
                    return (int)reader.ReadUInt32();
                else
                    throw new EXIF_Exception(tag);
            }
        }

        public static DateTime GetRecordingTime(PropertyItem item)
        {
            if (item.Id != (int)IFD_TAGS.RecordingTime || item.Type != (int)IFD_TYPES.ASCII)
                throw new EXIF_Exception(IFD_TAGS.RecordingTime);

            using (System.IO.MemoryStream mem = new System.IO.MemoryStream(item.Value))
            {
                System.IO.BinaryReader reader = new System.IO.BinaryReader(mem);
                string txtDatum = "";

                // Datumsteil einlesen
                while (reader.PeekChar() != '\0' && reader.PeekChar() != ' ')
                    txtDatum += reader.ReadChar();
                txtDatum = txtDatum.Replace(':', '-');

                // Zeitteil einlesen
                while (reader.PeekChar() != '\0')
                    txtDatum += reader.ReadChar();

                DateTime datum = Convert.ToDateTime(txtDatum);
                return datum;
            }
        }

        public static double GetFocalLength(PropertyItem item)
        {
            return ReadRational(IFD_TAGS.FocalLength, item);
        }

        public static double GetFocalLength35(PropertyItem item)
        {
            return ReadRational(IFD_TAGS.FocalLength35, item);

        }

        public static bool GetFlash(PropertyItem item)
        {
            if (item.Id != (int)IFD_TAGS.Flash || item.Type != (int)IFD_TYPES.SHORT)
                throw new EXIF_Exception(IFD_TAGS.Flash);

            using (System.IO.MemoryStream mem = new System.IO.MemoryStream(item.Value))
            {
                System.IO.BinaryReader reader = new System.IO.BinaryReader(mem);
                ushort fl = reader.ReadUInt16();
                fl &= 0x01;
                if (fl == 0x01)
                    return true;
                else
                    return false;

            }
        }

        public static double GetExposureTime(PropertyItem item)
        {
            return ReadRational(IFD_TAGS.ExposureTime, item);
        }

        public static double GetSubjectDistance(PropertyItem item)
        {           

            return ReadRational(IFD_TAGS.SubjectDistance, item);
        }

        private static double ReadRational(IFD_TAGS tag, PropertyItem item)
        {
            if (item.Id != (int)tag)
                throw new EXIF_Exception(tag);

            using (System.IO.MemoryStream mem = new System.IO.MemoryStream(item.Value))
            {
                System.IO.BinaryReader reader = new System.IO.BinaryReader(mem);
                uint nom;
                uint denom;

                if (item.Type == (int)IFD_TYPES.RATIONAL)
                {
                    nom = reader.ReadUInt32();
                    denom = reader.ReadUInt32();

                    if (nom == uint.MaxValue)
                        return double.PositiveInfinity;
                    if (nom == 0)
                        return double.NaN;

                    return nom / denom;
                }
                else if (item.Type == (int)IFD_TYPES.SHORT)
                {
                    nom = reader.ReadUInt16();

                    if (nom == ushort.MaxValue)
                        return double.PositiveInfinity;
                    if (nom == 0)
                        return double.NaN;

                    return nom;

                }
                else
                    throw new EXIF_Exception(tag);

            }
        }


    }
}

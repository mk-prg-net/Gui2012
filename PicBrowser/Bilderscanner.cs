using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using System.Windows.Forms;

namespace DMS
{
    class Bilderscanner : DMS.DirTree
    {
        TreeView tView;

        // Stapelpeicher zur Protokollierung beim rekursiven abstieg
        Stack<TreeNode> Stapel = new Stack<TreeNode>();

        public Bilderscanner(TreeView refTreeView)
        {
            // Auf den Treeview aus dem Formular zeigen
            tView = refTreeView;            
        }
        //public Bilderscanner(mko.CLog log)
        //    : base(log)
        //{ }

        protected override bool BeginScanDir(string path)
        {
            // Startnode der Treeview
            TreeNode RootNode = new TreeNode();
            RootNode.Text = "Start";
            tView.Nodes.Add(RootNode);
            Stapel.Push(RootNode);
            return true;
        }        

        protected override bool EnterDir(string path)
        {
            // Node für Unterverzeichnis
            TreeNode tNode = new TreeNode();            
            //string dirName = path.Substring(path.LastIndexOf('\\'));
            tNode.Text = System.IO.Path.GetFileName(path);
            tNode.Tag = null;
            // Elternknoten bestimmen
            TreeNode ParentNode = Stapel.Peek();
            // Verknüpfen mit dem Elternknoten
            ParentNode.Nodes.Add(tNode);

            // Aufzeichnen des neuen Kindknotens
            Stapel.Push(tNode);

            return true;
        }

        protected override bool ExitDir(string path)
        {
            // TreeNode vom Stapel entfernen
            Stapel.Pop();

            return true;
        }

        public class FileDescriptor {
            public string Path;
            public bool IsImage = false;
            public bool Flash;
            public DateTime RecordingTime;
            public int ImageWidth;
            public int ImageHeight;
            public double FocalLength;
            public double FocalLength35;
        }

        // Funktor zur Implementierung eines Testprädikates für Zeichenketten
        class TestStringFunctor
        {
            public TestStringFunctor(string str)
            {
                TestString = str;
            }

            public string TestString;

            public bool Test(string str)
            {
                if (str == TestString)
                    return true;
                else
                    return false;
            }
        }

        static string[] bilddateitypen = { ".jpg", ".jpeg", ".tif", ".tiff", ".gif", ".png" };

        protected override bool TouchFile(string path)
        {
            // Node für Unterverzeichnis
            TreeNode tNode = new TreeNode();
            //string dirName = path.Substring(path.LastIndexOf('\\'));
            tNode.Text = System.IO.Path.GetFileName(path);

            FileDescriptor descriptor = new FileDescriptor();
            descriptor.Path = path;
            
            TestStringFunctor IsImageType = new TestStringFunctor(System.IO.Path.GetExtension(path).ToLower());

            //if (Array.Exists<string>(bilddateitypen, IsImageType.Test))
            if (bilddateitypen.Any(r => r == System.IO.Path.GetExtension(path).ToLower()))
            {
                descriptor.IsImage = true;
                System.Drawing.Image bmp = System.Drawing.Bitmap.FromFile(path);

                // Auslesen der Metadaten
                foreach (System.Drawing.Imaging.PropertyItem item in bmp.PropertyItems)
                {
                    switch ((DMS.EXIF.IFD_TAGS)item.Id)
                    {
                        case DMS.EXIF.IFD_TAGS.ImageHeigth:
                            descriptor.ImageHeight = DMS.EXIF.GetImageHeight(item);
                            break;
                        case DMS.EXIF.IFD_TAGS.ImageWidth:
                            descriptor.ImageWidth = DMS.EXIF.GetImageWidth(item);
                            break;
                        case DMS.EXIF.IFD_TAGS.RecordingTime:
                            descriptor.RecordingTime = DMS.EXIF.GetRecordingTime(item);
                            break;
                        case DMS.EXIF.IFD_TAGS.FocalLength:
                            descriptor.FocalLength = DMS.EXIF.GetFocalLength(item);
                            break;
                        case EXIF.IFD_TAGS.FocalLength35:
                            descriptor.FocalLength35 = DMS.EXIF.GetFocalLength35(item);
                            break;
                        case DMS.EXIF.IFD_TAGS.Flash:
                            descriptor.Flash = DMS.EXIF.GetFlash(item);
                            break;
                        default: ;
                            break;
                    }
                }

            }

            tNode.Tag = descriptor;
            // Elternknoten bestimmen
            TreeNode ParentNode = Stapel.Peek();
            // Verknüpfen mit dem Elternknoten
            ParentNode.Nodes.Add(tNode);            

            return true;   
        }
    }
}

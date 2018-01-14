using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Io = System.IO;

namespace PicBrowser
{
    public partial class PicBrowserForm : WinFormTemplates.WinFormTemplate1
    {
        Bitmap bmp;
        mko.Log.LogServer log = new mko.Log.LogServer();
        mko.Log.WinFormListBoxLogHnd hndLbx;
        mko.Log.WinFormStatusStripLogHnd hndStatusStrip;
        //DMS.Bilderscanner scanner;

        public PicBrowserForm()
        {
            InitializeComponent();

            //scanner = new DMS.Bilderscanner(trvPicDir);

            hndLbx = new mko.Log.WinFormListBoxLogHnd(lbxLog);
            log.registerLogHnd(hndLbx);

            hndStatusStrip = new mko.Log.WinFormStatusStripLogHnd(this.statusStrip1, "toolStripStatusLabel1");
            log.registerLogHnd(hndStatusStrip);
        }

        private void btnReloadDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogForScan.ShowDialog(this) == DialogResult.OK)
            {                
                var rootNode = new TreeNode(folderBrowserDialogForScan.SelectedPath);
                rootNode.Tag = new DirEntryDescriptor { Path = folderBrowserDialogForScan.SelectedPath, IsDir = true };
                rootNode.ImageIndex = 0;
                rootNode.SelectedImageIndex = 1;

                trvPicDir.Nodes.Clear();
                trvPicDir.Nodes.Add(rootNode);

                log.Log(mko.Log.RC.CreateStatus(string.Format("Ein neues Bildverzeichnis wurde eingelesen: {0}", folderBrowserDialogForScan.SelectedPath)));
            }
        }

        //private void trvPicDir_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    if (e.Node.Tag != null)
        //    {
        //        try
        //        {
        //            DMS.Bilderscanner.FileDescriptor descriptor = (DMS.Bilderscanner.FileDescriptor)e.Node.Tag;
                    
        //            if (descriptor.IsImage)
        //            {
        //                bmp = (Bitmap)Bitmap.FromFile(descriptor.Path);                        
        //                pbxViewer.Image = bmp;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            log.Log(mko.Log.RC.CreateError(string.Format("Fehler beim Zugriff auf Bilddatei: {0}", ex.Message)));
        //        }
        //    }
        //}

        private void trvPicDir_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
        }

        private void trvPicDir_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            //e.Node.Nodes.Clear();
        }

        private void PicBrowserForm_Load(object sender, EventArgs e)
        {
            var rootNode = new TreeNode(@"C:\");
            rootNode.Tag = new DirEntryDescriptor { Path = @"C:\", IsDir = true };
            rootNode.ImageIndex = 0;
            rootNode.SelectedImageIndex = 1;

            trvPicDir.Nodes.Clear();
            trvPicDir.Nodes.Add(rootNode);

        }


        TreeNode currentlySelectedNode;
        private void trvPicDir_AfterSelect(object sender, TreeViewEventArgs e)
        {
            currentlySelectedNode = e.Node;
            var descriptor = (DirEntryDescriptor)e.Node.Tag;
            if (Io.Directory.Exists(descriptor.Path))
                MakeNewSubnodes(e.Node);
            else
            {
                // Datei Darstellen
                splitContainer1.Panel2.Controls.Clear();
                if (descriptor.IsImage)
                {
                    // Darstellen als Bild
                    var imgViewCtrl = new ImageViewerCtrl();
                    imgViewCtrl.pbxImage.Image = (Bitmap)Bitmap.FromFile(descriptor.Path);
                    imgViewCtrl.lblPath.Text = descriptor.Path;

                    // Exif- Daten übertragen
                    var imgDescr = (DirEntryDescriptorFotos)descriptor;

                    imgViewCtrl.dsExif1.Exif.Clear();

                    var row = imgViewCtrl.dsExif1.Exif.NewExifRow();
                    row.pos = 1;
                    row.ExifAtrib = "Belichtungszeit";
                    row.Value = imgDescr.Exif.ExposureTime.ToString();
                    imgViewCtrl.dsExif1.Exif.AddExifRow(row);

                    row = imgViewCtrl.dsExif1.Exif.NewExifRow();
                    row.pos = 2;
                    row.ExifAtrib = "Blitz";
                    row.Value = imgDescr.Exif.Flash.ToString();
                    imgViewCtrl.dsExif1.Exif.AddExifRow(row);

                    row = imgViewCtrl.dsExif1.Exif.NewExifRow();
                    row.pos = 1;
                    row.ExifAtrib = "Brennweite";
                    row.Value = imgDescr.Exif.FocalLength.ToString();
                    imgViewCtrl.dsExif1.Exif.AddExifRow(row);

                    row = imgViewCtrl.dsExif1.Exif.NewExifRow();
                    row.pos = 1;
                    row.ExifAtrib = "Höhe in Pix";
                    row.Value = imgDescr.Exif.ImageHeight.ToString();
                    imgViewCtrl.dsExif1.Exif.AddExifRow(row);

                    row = imgViewCtrl.dsExif1.Exif.NewExifRow();
                    row.pos = 1;
                    row.ExifAtrib = "Breite in Pix";
                    row.Value = imgDescr.Exif.ImageWidth.ToString();
                    imgViewCtrl.dsExif1.Exif.AddExifRow(row);

                    row = imgViewCtrl.dsExif1.Exif.NewExifRow();
                    row.pos = 1;
                    row.ExifAtrib = "Aufnahmezeit";
                    row.Value = imgDescr.Exif.RecordingTime.ToString();
                    imgViewCtrl.dsExif1.Exif.AddExifRow(row);

                    row = imgViewCtrl.dsExif1.Exif.NewExifRow();
                    row.pos = 1;
                    row.ExifAtrib = "Programm";
                    row.Value = imgDescr.Exif.SceneCaptureType.ToString();
                    imgViewCtrl.dsExif1.Exif.AddExifRow(row);

                    row = imgViewCtrl.dsExif1.Exif.NewExifRow();
                    row.pos = 1;
                    row.ExifAtrib = "Sensor";
                    row.Value = imgDescr.Exif.SensingMethod.ToString();
                    imgViewCtrl.dsExif1.Exif.AddExifRow(row);

                    imgViewCtrl.Dock = DockStyle.Fill;
                    splitContainer1.Panel2.Controls.Add(imgViewCtrl);

                }
                else
                {
                    // Allgemeine Dateiinfos darstellen

                }
            }
        }

        private void btnTab2TreeNodeRefresh_Click(object sender, EventArgs e)
        {
            if (currentlySelectedNode != null)
            {
                currentlySelectedNode.Nodes.Clear();
                MakeNewSubnodes(currentlySelectedNode);
            }
        }

        private void MakeNewSubnodes(TreeNode parentNode)
        {
            try
            {
                var view = new DirViewer();
                view.AsParallel = cbxViewerAsParallel.Checked;

                // Eventhandler zur Dokumentation des Arbeitsfortschrittes im Progressbar vom Programmfester 
                // registrieren
                view.ProgressInfoEvent += (pinfo) =>
                {
                    toolStripProgressBar1.Maximum = pinfo.AllEntriesCount;
                    toolStripProgressBar1.Minimum = 0;
                    toolStripProgressBar1.Value = pinfo.ProcessedEntriesCount;
                };

                log.Log(mko.Log.RC.CreateStatus("Das Unterverzeichnis " + ((DirEntryDescriptor)parentNode.Tag).Path + " wird eingelesen"));
                // Aufbau des Unterverzeichnises im Treeview starten
                view.ViewAsChildnodes(parentNode, ((DirEntryDescriptor)parentNode.Tag).Path);
            }
            catch (Exception ex)
            {
                log.Log(mko.Log.RC.CreateError("Beim Anlegen eines neuen TreeView- Eintrages: " + mko.ExceptionHelper.FlattenExceptionMessages(ex)));
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Io = System.IO;
using Wfm = System.Windows.Forms;
using Trd = System.Threading;

namespace PicBrowser
{
    class DirViewer
    {
        public DirViewer()
        {
            AsParallel = false;
        }

        public bool AsParallel { get; set; }

        DMS.FC.IFileClassificator fc = new DMS.FC.StandardFileClassificator();

        /// <summary>
        /// Delegate, über den asynchron der Aufbau der DirEntryDescriptor- Liste für ein
        /// Unterverzeichnis gestartet werden kann.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        delegate List<DirEntryDescriptor> DgCreateDirEntryList(string path);


        /// <summary>
        /// Darstellung des Prozessfortschrittes beim Einlesen aller Einträge eines Unterverzeichnisses
        /// </summary>
        public class ProgressInfo : mko.ProgressInfo
        {            
            public int AllEntriesCount { get; set; }
            public int ProcessedEntriesCount { get; set; }
        }

        public delegate void DgProgressInfo(ProgressInfo pinfo);
        public event DgProgressInfo ProgressInfoEvent;

        /// <summary>
        /// Zu allen Einträge in einem Dateisystemverzeichnis (Dateien und Unterverzeichnisse)
        /// werden DirEntryDeskriptoren angelegt. Danach werden diese in TreeNodes verpackt und 
        /// als Kindelemente dem übergebenen Elternknoten hinzugefügt.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="path"></param>
        public void ViewAsChildnodes(Wfm.TreeNode parent, string path)
        {
            var dgCreateList = new DgCreateDirEntryList(CreateDirEntryList);
            IAsyncResult ares = dgCreateList.BeginInvoke(path, null, null);
            while (!ares.IsCompleted)
            {
                // Die Verarbeitung von Nachrichten aus der Nachrichtenwarteschlange der Anwendung wird fortgesetz
                // Hierdurch wird ein Blockieren der Oberfläche vermieden
                System.Windows.Forms.Application.DoEvents();

                // Der aktuelle Prozessfortschritt wird angezeigt. Das Event wird im 
                // UI- Thread der Anwendung gefeuert, wodurch auch Winform- Steuerelemente 
                // im Eventhandler problemlos aktualisiert werden können (diese sind nicht 
                // Threadsafe !)
                if (ProgressInfoEvent != null)
                {
                    var pinfo = new ProgressInfo() { AllEntriesCount = this.AllEntriesCount, ProcessedEntriesCount = this.ProcessedEntriesCount };
                    ProgressInfoEvent(pinfo);
                }
            }

            // Das zeitaufwendige Einlesen der Informationen zu den Filesystementries ist beendet
            var list = dgCreateList.EndInvoke(ares);

            // Der Treeview wird aufgebaut
            ViewAsChildnodesImpl(parent, list);
        }

        
        int _allEntriesCount;
        /// <summary>
        /// Anzahl aller Einträge in einem Dateiverzeichnis
        /// </summary>
        public int AllEntriesCount {
            get
            {
                    return _allEntriesCount;
            }
        }

        int _processedEntriesCount;
        /// <summary>
        /// Anzahl aller Einträge in einem Dateiverzeichnis, zu denen bereits die gewünschten
        /// DirEntryDescriptoren angelegt wurden
        /// </summary>
        public int ProcessedEntriesCount
        {
            get
            {
                 return _processedEntriesCount;                
            }
        }

        /// <summary>
        /// Erzeugt eine Liste mit DirEntryDescriptoren zu allen Einträgen in einem Dateverzeichnis
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected  List<DirEntryDescriptor> CreateDirEntryList(string path)
        {
            try
            {
                var list = new List<DirEntryDescriptor>();
                // Alle Unterverzeichnisse als Kindknoten unterhalb des Elternnkotens einfügen

                Trd.Interlocked.Exchange(ref _processedEntriesCount, 0);
                Trd.Interlocked.Exchange(ref _allEntriesCount, Io.Directory.GetFileSystemEntries(path).Length);

                foreach (string dir in Io.Directory.GetDirectories(path))
                {
                    list.Add(DirEntryClassificator.CreateDirEntryDescriptor(dir));
                    Trd.Interlocked.Increment(ref _processedEntriesCount);
                }

                // Alle Dateien als Kindknoten unterhalb des Elternnkotens einfügen
                if(!AsParallel)
                    // Aufgabe klassisch, sequenziell lösen
                    foreach (string file in Io.Directory.GetFiles(path))
                    {
                        list.Add(DirEntryClassificator.CreateDirEntryDescriptor(file));
                        Trd.Interlocked.Increment(ref _processedEntriesCount);
                    }
                else
                    // Aufgabe modern, parallel lösen
                    Trd.Tasks.Parallel.ForEach(Io.Directory.GetFiles(path),
                        new Trd.Tasks.ParallelOptions() { MaxDegreeOfParallelism = 8 }
                        ,
                        file =>
                        {
                            list.Add(DirEntryClassificator.CreateDirEntryDescriptor(file));
                            Trd.Interlocked.Increment(ref _processedEntriesCount);
                        });

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("DirViewer.CreateDirEntryList (Einlesen der Verzeichniseinträge als DirEntryDescriptoren", ex);
            }
        }    
        
        protected void ViewAsChildnodesImpl(Wfm.TreeNode parent, List<DirEntryDescriptor> list)
        {
            var parentDirEntryDescriptor = parent.Tag as DirEntryDescriptor;
            if (parentDirEntryDescriptor.IsDir)
            {               

                // Alle Unterverzeichnisse als Kindknoten unterhalb des Elternnkotens einfügen
                foreach (var entry in list)
                {
                    if (entry.IsDir) 
                    { 
                        var child = new Wfm.TreeNode(Io.Path.GetFileName(entry.Path), 0, 1);
                        child.Tag = entry;
                        parent.Nodes.Add(child);
                    }
                    else if (entry.IsImage)
                    {
                        var child = new Wfm.TreeNode(Io.Path.GetFileName(entry.Path), 3, 3);
                        child.Tag = entry;
                        parent.Nodes.Add(child);
                    }
                    else
                    {
                        var child = new Wfm.TreeNode(Io.Path.GetFileName(entry.Path), 2, 2);
                        child.Tag = entry;
                        parent.Nodes.Add(child);
                    }
                }
                
            }
        }

    }
}

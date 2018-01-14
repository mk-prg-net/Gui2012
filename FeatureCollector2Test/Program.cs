using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FeatureCollector2Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirTree = new DMS.FCollect.DirFeatureCollector();
            dirTree.FC.AddExtractor(new DMS.FCollect.Extractor<DMS.FCollect.FeatureFileName>());
            dirTree.FC.AddExtractor(new DMS.FCollect.Extractor<DMS.FCollect.FeatureFileExt>());
            dirTree.FC.AddExtractor(new DMS.FCollect.Extractor<DMS.FCollect.FeatureCreationTime>());
            dirTree.FC.AddExtractor(new DMS.FCollect.Extractor<DMS.FCollect.FeatureLastAccessTime>());
            dirTree.FC.AddExtractor(new DMS.FCollect.Extractor<DMS.FCollect.FeatureLastWriteTime>());
            dirTree.FC.AddExtractor(new DMS.FCollect.Extractor<DMS.FCollect.FeatureFileClass>());
            dirTree.FC.AddExtractor(new DMS.FCollect.Extractor<DMS.FCollect.FeatureSizeInBytes>());
            dirTree.FC.AddExtractor(new DMS.FCollect.Extractor<DMS.FCollect.FeatureKleinbild>());


            //dirTree.scanDir(@"C:\trac\projekt\lernen-dot-net\Bildergalerie");
            dirTree.scanDir(@"C:\trac\projekt\MkoIT\www.mkoIt.de\mkoItWeb\wissen2010");

            // Einschränken der Menge auf Fotos
            var fotoIds = dirTree.FC.FeatureCollection.Where(r => r.Name == "FileClass").Where(r => (r as DMS.FCollect.FeatureFileClass).FileClass == DMS.FC.ContentVector.FileClasses.Fotos).Select(r => r.FileId);
            var files = dirTree.FC.FeatureCollection.Join (
                    fotoIds,
                    feature => feature.FileId,
                    id => id,                    
                    (f, id) => f).GroupBy(r => r.FileId);

            foreach (var file in files)
            {
                Debug.WriteLine("FileId: " + file.Key.ToString());
                Console.WriteLine("FileId: " + file.Key.ToString());

                foreach (var feature in file)
                {
                    Debug.WriteLine("\t" + feature.Name + ": " + feature.ToString());
                    Console.WriteLine("\t" + feature.Name + ": " + feature.ToString());
                }
            }

            // Gruppieren nach Unterverzeichnissen
            Debug.WriteLine("Gruppieren nach Unterverzeichnissen");
            var dirs = dirTree.FC.FeatureCollection.GroupBy(r => r.ParentDirId);
            foreach (var dir in dirs)
            {
                Debug.WriteLine("DirId: " + dir.Key.ToString());
                Console.WriteLine("DirId: " + dir.Key.ToString());

                var filesInDir = dir.GroupBy(r => r.FileId);

                foreach (var file in filesInDir)
                {
                    Debug.WriteLine("FileId: " + file.Key.ToString());
                    Console.WriteLine("FileId: " + file.Key.ToString());

                    foreach (var feature in file)
                    {
                        Debug.WriteLine("\t" + feature.Name + ": " + feature.ToString());
                        Console.WriteLine("\t" + feature.Name + ": " + feature.ToString());
                    }
                }
            }


            // Sichern in der Datenbank

            var layer = new DMS.FCollect.Db.FeatureCollectorToDbEF();
            try
            {
                //layer.ClearDb();

                layer.Save(dirTree.FC);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error beim Sichern in der DB: " + ex.Message);
            }

        }
    }
}

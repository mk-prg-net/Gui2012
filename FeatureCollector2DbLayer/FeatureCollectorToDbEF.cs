using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.FCollect.Db
{
    public class FeatureCollectorToDbEF
    {        

        public void ClearDb()
        {
            using (var ctx = new FileFeaturesDbEntities())
            {
                string efQuery = "Delete From compact.Files";
                ctx.ExecuteStoreCommand(efQuery);

                efQuery = "Delete From compact.FilePaths";
                ctx.ExecuteStoreCommand(efQuery);
            }
        }


        public void Save(FeatureCollector fcl)
        {
            using (var ctx = new FileFeaturesDbEntities())
            {
                // Sichern der Zuordnung der Pfade zu GUID's
                foreach (var pair in fcl.MapPathToGuid)
                {
                    var etFp = ctx.CreateObject<FilePath>();

                    etFp.path = pair.Key;
                    etFp.uid = pair.Value;

                    ctx.FilePaths.AddObject(etFp);
                }

                ctx.SaveChanges();

                // Sichern aller File- Einträge                
                foreach (var fileFeatures in fcl.FeatureCollection.GroupBy(r => r.FileId))
                {
                    var etFile = ctx.CreateObject<File>();
                    var etBasicFeature = ctx.CreateObject<BasicFeature>();

                    bool first = true;
                    foreach (var feature in fileFeatures)
                    {
                        if (first)
                        {
                            // File Entity wird vollständig erfasst, um es Anzulegen und einen
                            // Primärschlüssel zu erhalten

                            first = false;
                            etFile.file_uid = feature.FileId;
                            etFile.fkey_file_id = ctx.FilePaths.Where(r => r.uid == etFile.file_uid).Single().id;

                            etFile.filename = System.IO.Path.GetFileName(ctx.FilePaths.Where(r => r.uid == etFile.file_uid).Single().path);


                            etFile.dir_uid = feature.ParentDirId;
                            etFile.fkey_dir_id = ctx.FilePaths.Where(r => r.uid == etFile.dir_uid).Single().id;

                            etFile.super_dir_uid = feature.SuperDirId;
                            etFile.fkey_super_dir_id = ctx.FilePaths.Where(r => r.uid == etFile.super_dir_uid).Single().id;
                            ctx.Files.AddObject(etFile);
                            ctx.SaveChanges();
                        }

                        etBasicFeature.fkey_id_files = etFile.id;


                        // Sichern der Elementaren Merkmale der Dateien

                        if (feature is DMS.FCollect.FeatureCreationTime)
                        {
                            etBasicFeature.CreationTime = (feature as DMS.FCollect.FeatureCreationTime).time;
                        } else if(feature is DMS.FCollect.FeatureFileClass) 
                        {
                            etBasicFeature.fkey_FileClass = (int)(feature as DMS.FCollect.FeatureFileClass).FileClass;
                        }
                        else if (feature is DMS.FCollect.FeatureLastAccessTime)
                        {
                            etBasicFeature.LastAccesssTime = (feature as DMS.FCollect.FeatureLastAccessTime).time;
                        }
                        else if (feature is DMS.FCollect.FeatureLastWriteTime)
                        {
                            etBasicFeature.LastWriteTime = (feature as DMS.FCollect.FeatureLastWriteTime).time;
                        }
                        else if (feature is DMS.FCollect.FeatureSizeInBytes)
                        {
                            etBasicFeature.SizeInBytes = (feature as DMS.FCollect.FeatureSizeInBytes).SizeInBytes;
                        }
                        else if (feature is DMS.FCollect.FeatureKleinbild)
                        {
                            var etKleinbildFeature = ctx.CreateObject<image>();
                            etKleinbildFeature.fkey_id_files = etFile.id;
                            etKleinbildFeature.description = etFile.filename;
                            etKleinbildFeature.img = (feature as DMS.FCollect.FeatureKleinbild).Img;                            

                            ctx.images.AddObject(etKleinbildFeature);
                        }
                    }
                    ctx.BasicFeatures.AddObject(etBasicFeature);
                    ctx.SaveChanges();
                }
             
            }
        }


    }
}

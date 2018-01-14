using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IO = System.IO;

namespace DMS.FCollect.Db
{
    public class BoFilesBasic : mkoIt.Db.BoBaseEF<FileFeaturesDbEntities, File, int, BoFilesBasic.View>
    //mkoIt.Asp.BoFilterAndSortEfEntitiesBase<FileFeaturesDbEntities, File, BoFilesBasic.View>
    {
        public BoFilesBasic() : base(new FileFeaturesDbEntities(), "DirId") { }

        /// <summary>
        /// Die Daten aus den aus einem Entity und seinen in Beziehung stehenden Entities werden in einer View zusammengestellt.
        /// Diese fast damit alle Daten aus den normaliserten Tabellen in einer einzigen- denormaliserten Zeile zusammen.
        /// Die "View" Zeilen werden schließlich in datengebundenen Websteuerelementen visualisiert und über diese editiert
        /// </summary>
        public class View : mkoIt.Db.BoBaseView<File, int>
        {
            /// <summary>
            /// Konstruktor
            /// </summary>
            public View()
                : base()
            {
            }

            /// <summary>
            /// Konstruktor, der View aus einem EF- Entity erzeugt
            /// </summary>
            /// <param name="file"></param>
            public View(File file)
                : base(file)
            {
            }

            protected override int GetDummyId()
            {
                return -1;
            }

            protected override int GetEntityId(File Entity)
            {
                return Entity.id;
            }

            protected override void SetEntityId(int id, File Entity)
            {
                Entity.id = id;
            }


            /// <summary>
            /// Eigenschaften/Spalten der View
            /// </summary>


            public class IdFilter : mkoIt.Db.FilterFunctor<File, int>
            {
                public IdFilter() { }
                public override IQueryable<File> filterImpl(IQueryable<File> srcTab)
                {
                    return srcTab.Where(r => r.id == RValue);
                }
            }

            [mkoIt.Db.MapPropertyToColName("id")]
            public int? FileId
            {
                get
                {
                    return GetEntityPropertyStructValue(e =>  e.id);
                }
                set
                {
                    pushUpdateJobNullable(value, (val, e) => e.id = val);
                }
            }

            [mkoIt.Db.MapPropertyToColName("file_uid")]
            public Guid? FileUid
            {
                get
                {
                    return GetEntityPropertyStructValue(e => e.file_uid);
                }
                set
                {
                    pushUpdateJobNullable(value, (val, e) => e.file_uid = val);
                }
            }

            [mkoIt.Db.MapPropertyToColName("derivatFilename")]
            public string FileName
            {
                get
                {
                    return GetEntityPropertyRefValue(e => IO.Path.GetFileName(e.filename));
                }
                set
                {
                    pushUpdateJob(value, (val, e) => e.FilePath.path = IO.Path.GetDirectoryName(e.FilePath.path) + IO.Path.DirectorySeparatorChar + val);
                    pushUpdateJob(value, (val, e) => e.filename = val);
                }
            }

            public class FileNameFilter : mkoIt.Db.FilterFunctor<File, string>
            {
                public FileNameFilter() { }

                public override IQueryable<File> filterImpl(IQueryable<File> srcTab)
                {
                    return srcTab.Where(r => r.filename == RValue);
                }
            }

            [mkoIt.Db.MapPropertyToColName("fkey_dir_id")]
            public int? DirId
            {
                get
                {
                    return GetEntityPropertyStructValue(e => e.Dir.id);
                }
                set { 
                    pushUpdateJobNullable(value, (val, e) => e.Dir.id = val);
                }
            }

            [mkoIt.Db.MapPropertyToColName("dir_uid")]
            public Guid? DirUid
            {
                get { 
                    return GetEntityPropertyStructValue(e => e.dir_uid); 
                }
                set
                {
                    pushUpdateJobNullable(value, (val, e) => e.Dir.uid = val);
                    pushUpdateJobNullable(value, (val, e) => e.dir_uid = val);
                }
            }

            [mkoIt.Db.MapPropertyToColName("derivatDirName")]
            public string DirName
            {
                get
                {
                    return GetEntityPropertyRefValue(e => e.Dir.path);
                }
                set
                {
                    pushUpdateJob(value, (val, e) => e.Dir.path = val);
                }
            }

            public class DirNameFilter : mkoIt.Db.FilterFunctor<File, string>
            {
                public DirNameFilter() { }

                public override IQueryable<File> filterImpl(IQueryable<File> srcTab)
                {
                    return srcTab.Where(r => r.Dir.path == RValue);
                }
            }

            [mkoIt.Db.MapPropertyToColName("derivatCreationTime")]
            public DateTime? CreationTime
            {
                get
                {
                    return GetEntityPropertyNullableValue(e => e.BasicFeatures.FirstOrDefault().CreationTime);
                }
                set
                {

                }
            }

            public class CreationTimeFilter : mkoIt.Db.FilterFunctor<File, mko.Interval<DateTime>>
            {
                public CreationTimeFilter() { }

                public override IQueryable<File> filterImpl(IQueryable<File> srcTab)
                {
                    return srcTab.Where(r => r.BasicFeatures.FirstOrDefault().CreationTime.HasValue && r.BasicFeatures.FirstOrDefault().CreationTime >= RValue.Begin && r.BasicFeatures.FirstOrDefault().CreationTime <= RValue.End);
                }
            }

            [mkoIt.Db.MapPropertyToColName("derivatLastWriteTime")]
            public DateTime? LastWriteTime
            {
                get
                {
                    return GetEntityPropertyNullableValue(e => e.BasicFeatures.FirstOrDefault().LastWriteTime);
                }
                set { }
            }

            [mkoIt.Db.MapPropertyToColName("derivatLastAccessTime")]
            public DateTime? LastAccessTime
            {
                get
                {
                    return GetEntityPropertyNullableValue(e => e.BasicFeatures.FirstOrDefault().LastAccesssTime);
                }
                set { }
            }

            [mkoIt.Db.MapPropertyToColName("derivatSizeInBytes")]
            public long? SizeInBytes
            {
                get
                {
                    return GetEntityPropertyNullableValue(e => e.BasicFeatures.FirstOrDefault().SizeInBytes);
                }
                set { }
            }

            public class SizeInBytesFilter : mkoIt.Db.FilterFunctor<File, mko.Interval<double>>
            {
                public SizeInBytesFilter() { }

                public override IQueryable<File> filterImpl(IQueryable<File> srcTab)
                {
                    return srcTab.Where(r => r.BasicFeatures.FirstOrDefault().SizeInBytes.HasValue &&
                                                r.BasicFeatures.FirstOrDefault().SizeInBytes >= RValue.Begin &&
                                                r.BasicFeatures.FirstOrDefault().SizeInBytes <= RValue.End);
                }
            }

            public int? FileClass
            {
                get
                {
                    return GetEntityPropertyNullableValue(e => e.BasicFeatures.FirstOrDefault().fkey_FileClass);
                }
                set { }
            }

            public class FileClassFilter : mkoIt.Db.FilterFunctor<File, int>
            {
                public FileClassFilter() { }

                public override IQueryable<File> filterImpl(IQueryable<File> srcTab)
                {
                    return srcTab.Where(r => r.BasicFeatures.FirstOrDefault().fkey_FileClass.HasValue &&
                                                r.BasicFeatures.FirstOrDefault().fkey_FileClass == RValue);
                }
            }

            [mkoIt.Db.MapPropertyToColName("derivatFileClass")]
            public string FileClassTxt
            {
                get
                {
                    return GetEntityPropertyRefValue(e => e.BasicFeatures.FirstOrDefault().FileClass.name);
                }
                set { }
            }

            [mkoIt.Db.MapPropertyToColName("derivatRating")]
            public int? Rating
            {
                get
                {
                    return GetEntityPropertyStructValue(e => e.rating_up - e.rating_down);
                }
                set { }
            }

            [mkoIt.Db.MapPropertyToColName("rating_up")]
            public int? RatingUp
            {
                get
                {
                    return GetEntityPropertyStructValue(e => e.rating_up);
                }
                set {
                    pushUpdateJobNullable(value, (r, e) => e.rating_up += r);
                }
            }

            [mkoIt.Db.MapPropertyToColName("rating_down")]
            public int? RatingDown
            {
                get
                {
                    return GetEntityPropertyStructValue(e => e.rating_down);
                }
                set
                {
                    pushUpdateJobNullable(value, (val, e) => e.rating_down += val);
                }
            }

            [mkoIt.Db.MapPropertyToColName("description")]
            public string Description
            {
                get
                {
                    return GetEntityPropertyRefValue(e => e.description);
                }
                set
                {
                    pushUpdateJob(value, (val, e) => e.description = val);
                }
            }

            [mkoIt.Db.MapPropertyToColName("keywords")]
            public string Keywords
            {
                get
                {
                    return GetEntityPropertyRefValue(e => e.keywords);
                }
                set
                {
                    pushUpdateJob(value, (val, e) => e.keywords = val);
                }
            }

        } // End Class

        //-------------------------------------------------------------------------------------------------------------------------------
        // Methoden für die mehrseitige Anzeige
        protected override Type[] AllEntityViewTypes()
        {
            return new Type[] { typeof(View) };
        }

        protected override Type GetBoThatInclude(Type typeTEntityView)
        {
            return typeof(View);
        }

        public override mkoIt.Db.FilterFunctor<File, int> CreateIdFilter(int Id)
        {
            return new View.IdFilter() { RValue = Id };
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        // CRUD- Operationen

        public override void Delete(BoFilesBasic.View view)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override void Insert(BoFilesBasic.View view)
        {
            throw new NotImplementedException();
        }

        
        //-------------------------------------------------------------------------------------------------------------------------------

        public override IQueryable<File> EntityCollection
        {
            get
            {
                return ORMContext.Files;
            }
        }

        public override void AddEntityToEntityCollection(File entity)
        {
            ORMContext.Files.AddObject(entity);
        }

        public override File CreateEntity()
        {
            return new File();
        }

        public override BoFilesBasic.View CreateView()
        {
            return new View();
        }

        protected override BoFilesBasic.View CreateView(File entity)
        {
            return new View(entity);
        }

        protected override bool sortByDerivat(IQueryable<File> tab, string ColName, bool desc, out IQueryable<File> tabOrdered)
        {
            switch (ColName)
            {
                case "derivatFilename":
                    tabOrdered = sortHlp(tab, desc, r => r.FilePath.path);
                    return true;
                case "derivatDirName":
                    tabOrdered = sortHlp(tab, desc, r => r.Dir.path);
                    return true;
                case "derivatCreationTime":
                    tabOrdered = sortHlp(tab, desc, r => r.BasicFeatures.FirstOrDefault().CreationTime);
                    return true;
                case "derivatLastWriteTime":
                    tabOrdered = sortHlp(tab, desc, r => r.BasicFeatures.FirstOrDefault().LastWriteTime);
                    return true;
                case "derivatLastAccessTime":
                    tabOrdered = sortHlp(tab, desc, r => r.BasicFeatures.FirstOrDefault().LastAccesssTime);
                    return true;
                case "derivatSizeInBytes":
                    tabOrdered = sortHlp(tab, desc, r => r.BasicFeatures.FirstOrDefault().SizeInBytes);
                    return true;
                case "derivatFileClass":
                    tabOrdered = sortHlp(tab, desc, r => r.BasicFeatures.FirstOrDefault().FileClass.name);
                    return true;
                default:
                    {
                        tabOrdered = null;
                        return false;
                    }
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------
        // Methoden für die automat. Vervollständigung von Eingaben
        public List<string> GetDirNameStartsWith(string Prefix, int SetCount)
        {
            try
            {
                if (SetCount > 0)
                    return ORMContext.Files.Where(r => r.Dir.path.StartsWith(Prefix)).Take(SetCount).Select(r => r.Dir.path).ToList();
                else
                    return ORMContext.Files.Where(r => r.Dir.path.StartsWith(Prefix)).Select(r => r.Dir.path).ToList();
            }
            catch (Exception ex)
            {
                throw BoBaseException.Create("GetDirStartsWith", ex);
            }
        }

        public List<string> GetFileNameStartsWith(string Prefix, int SetCount)
        {
            try
            {
                if (SetCount > 0)
                    return ORMContext.Files.Where(r => r.filename.StartsWith(Prefix)).Take(SetCount).Select(r => r.filename).ToList();
                else
                    return ORMContext.Files.Where(r => r.filename.StartsWith(Prefix)).Select(r => r.filename).ToList();
            }
            catch (Exception ex)
            {
                throw BoBaseException.Create("GetFilenameStartsWith", ex);
            }
        }



    } // end Class
} // EOF

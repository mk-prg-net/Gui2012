using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.FCollect.Db
{
    public class BoSizePerFileClass : mkoIt.Db.BoBaseEF<FileFeaturesDbEntities, FileClass, int, BoSizePerFileClass.View>
    {
        public BoSizePerFileClass() : base(new FileFeaturesDbEntities(), "ClassName") { }

        public class View : mkoIt.Db.BoBaseView<FileClass, int>
        {
            public View()
            {
            }

            public View(FileClass Entity)
                : base(Entity)
            {
                Id = Entity.id;
                ClassName = Entity.name;                

                // Die Größen aller Dateien aus einer Fileklasse aufsummieren
                SumSize = Entity.BasicFeatures.Sum(r => r.SizeInBytes) ?? 0;
            }

            public class IdFilter : mkoIt.Db.FilterFunctor<FileClass, int>
            {
                public IdFilter() { }
                public override IQueryable<FileClass> filterImpl(IQueryable<FileClass> srcTab)
                {
                    return srcTab.Where(r => r.id == RValue);
                }
            }


            [mkoIt.Db.MapPropertyToColName("name")]
            public string ClassName
            {
                get
                {
                    return Entity.name;
                }
                set
                {
                    pushUpdateJob(value, (val, e) => e.name = val);
                }
            }            

            [mkoIt.Db.MapPropertyToColName("DerivatSumSize")]
            public long? SumSize
            {
                get
                {
                    return Entity.BasicFeatures.Sum(r => r.SizeInBytes);
                }
                set
                {
                }
            }

            protected override int GetDummyId()
            {
                return -1;
            }

            protected override int GetEntityId(FileClass Entity)
            {
                return Entity.id;
            }

            protected override void SetEntityId(int id, FileClass Entity)
            {
                Entity.id = id;
            }
        }

        /// <summary>
        /// Filter, das alle Daten zu einer def. FileClass ausschließt
        /// </summary>
        public class ExcludeFileClassFilter : mkoIt.Db.FilterFunctor<FileClass, int>
        {
            public ExcludeFileClassFilter() { }            
            public override IQueryable<FileClass> filterImpl(IQueryable<FileClass> srcTab)
            {
                return srcTab.Where(r => r.id != RValue);
            }
        }

        protected override bool sortByDerivat(IQueryable<FileClass> tab, string ColName, bool desc, out IQueryable<FileClass> tabOrdered)
        {
            tabOrdered = tab;
            switch (ColName)
            {
                case "DerivatSumSize":
                    {
                        return true;
                    }
                default:
                    {
                        tabOrdered = null;
                        return false;
                    }
            }
        }

        public override IQueryable<FileClass> EntityCollection
        {
            get { 
                return ((FileFeaturesDbEntities)ORMContext).FileClasses; 
            }
        }

        public override BoSizePerFileClass.View CreateView()
        {
            return new View();
        }

        protected override BoSizePerFileClass.View CreateView(FileClass entity)
        {
            return new View(entity);
        }

        protected override Type[] AllEntityViewTypes()
        {
            return new Type[] { typeof(View) };
        }       

        public override mkoIt.Db.FilterFunctor<FileClass, int> CreateIdFilter(int Id)
        {
            return new View.IdFilter();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override void Delete(View view)
        {
            throw new NotImplementedException();
        }

        protected override Type GetBoThatInclude(Type typeTEntityView)
        {
            return typeof(View);
        }

        public override void Insert(View view)
        {
            throw new NotImplementedException();
        }

        public override FileClass CreateEntity()
        {
            return new FileClass();
        }

        public override void AddEntityToEntityCollection(FileClass entity)
        {
            ORMContext.FileClasses.AddObject(entity);
        }
    }
}

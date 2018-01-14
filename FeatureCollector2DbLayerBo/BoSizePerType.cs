using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.FCollect.Db
{
    public class BoSizePerType : mkoIt.Asp.BoFilterAndSortEfEntitiesBase<FileFeaturesDbEntities, FileClass, BoSizePerType.View>
    {
        public BoSizePerType() : base(new FileFeaturesDbEntities(), "TypeName") { }
        public class View
        {
            public View()
            {
                TypeName = "";
                SumSize = 0;
            }

            public View(FileClass Entity)
            {
                TypeName = Entity.name;
                SumSize = Entity.BasicFeatures.Sum(r => r.SizeInBytes) ?? 0;
            }


            [mkoIt.Asp.MapPropertyToColName("name")]
            public string TypeName
            {
                get;
                set;
            }

            [mkoIt.Asp.MapPropertyToColName("DerivatSumSize")]
            public long SumSize
            {
                get;
                set;
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
                return ((FileFeaturesDbEntities)ObjectContext).FileClasses; 
            }
        }

        protected override BoSizePerType.View CreateView(FileClass entity)
        {
            return new View(entity);
        }
    }
}

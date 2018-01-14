using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprachkonzepte
{
    public class DynamischeTypen
    {

        public class Person {
            public string Name { get; set; }
        }

        public class Schlachtschiff
        {
            public string Name { get; set; }
            public int AnzLeben { get; set; }
        }

        public bool execForDyn(dynamic Figur)
        {
            try
            {
                Figur.Name = "Anton";
                Figur.AnzLeben = 99;                
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException rex)
            {
                Debug.WriteLine("RuntimeBinderException!!");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception!!: " + ex.Message);
                return false;
            }

            return true;
        }


        public bool execForDynklassisch(object Figur)
        {
            try
            {
                if (Figur is Schlachtschiff)
                {
                    var schiff = Figur as Schlachtschiff;
                    schiff.Name = "Anton";
                    schiff.AnzLeben = 99;
                }
                else if(Figur is Person)
                {
                    var person = Figur as Person;
                    person.Name = "Anton";                    
                }
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException rex)
            {
                Debug.WriteLine("RuntimeBinderException!!");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception!!: " + ex.Message);
                return false;
            }

            return true;
        }


    }
}

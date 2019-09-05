using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumeratorWithYield
{
    public class Garage : IEnumerable
    {
        private Car[] carArray = new Car[4];

        // Fill with some Car objects upon startup.
        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }

        public IEnumerator GetEnumerator()
        {
            // This will get thrown immediately
            throw new Exception("This will get called");

            return actualImplementation();

            // This will not get thrown until MoveNext() is called
            IEnumerator actualImplementation()
            { 
                foreach (Car c in carArray)
                {
                    yield return c;
                }
            }
        }
    }
}

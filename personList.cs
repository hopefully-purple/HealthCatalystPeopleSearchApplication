using System;
using System.Collections;
using System.IO;
using PeopleSearchApplication;
using System.Web.Services;

namespace PeopleSearchApplicationT
{
    public class PersonList
    {

        public class CompareNamesClass : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                Person c1 = (Person)x;
                Person c2 = (Person)y;
                return String.Compare(x.ToString(), y.ToString());
            }
        }

        // The caches being managed by this CacheList. They are arranged in
        // ascending order according to cache title.
        private ArrayList allPeople;

        private String titleConstraint;

        /*        
        * Creates a CacheList from the specified Scanner. Each line of the Scanner should contain the description of a
        * cache in a format suitable for consumption by the Cache constructor. The resulting CacheList should contain one
        * Cache object corresponding to each line of the Scanner.
        * 
        * Sets the initial value of the title and owner constraints to the empty string, sets the minimum difficulty and
        * terrain constraints to 1.0, and sets the maximum difficulty and terrain constraints to 5.0.
        * 
        * Throws an IOException if the Scanner throws an IOException, or an IllegalArgumentException if any of the
        * individual lines are not appropriate for the Cache constructor.
        * 
        * When an IllegalArgumentException e is thrown, e.getMessage() is the number of the line that was being read when
        * the error that triggered the exception was encountered. Lines are numbered beginning with 1.
        */
        public PersonList(String people)
        {
            int lineNum = 0;
            allPeople = new ArrayList();

            //Cache will throw IllegArg errors, so this try/catch will grab them and throw a new error
            try
            {
                using (StringReader reader = new StringReader(people))
                {
                    string line = reader.ReadLine();
                    //keeps track of the line number, then runs through Cache to check for errors
                    while (line != null)
                    {
                        lineNum++;
                        allPeople.Add(new Person(line));
                        line = reader.ReadLine();
                    }
                }


            }
            catch (System.Exception)
            {
                throw new SystemException("Line number: " + lineNum);
            }

            SetTitleConstraint("");

            IComparer myComparer = new CompareNamesClass();
            allPeople.Sort(myComparer);

        }
        /*
        *This is code from the article to experiment with
        */
        [WebMethod]
    public static string ProcessIT(string name, string address)
    {
        string result = "Welcome Mr. " + name + ". Your address is '" + address + "'.";
        return result;
    }

        /*
        * Sets the title constraint to the specified value. 
        */
        public void SetTitleConstraint(String title)
        {
            titleConstraint = title;
        }

        /*
         * Returns a list that contains each cache c from the CacheList so long as c's title contains the title constraint
         * as a substring, c's owner equals the owner constraint (unless the owner constraint is empty), c's difficulty
         * rating is between the minimum and maximum difficulties (inclusive), and c's terrain rating is between the minimum
         * and maximum terrains (inclusive). Both the title constraint and the owner constraint are case insensitive.
         * 
         * The returned list is arranged in ascending order by cache title.
         */
        public ArrayList Select()
        {
            ArrayList people = new ArrayList();

            //for each cache, if all the constraints apply, that cache will be added to the ArrayList
           foreach(Person currP in allPeople)
            {
                if (currP.GetName().ToLower().Contains(titleConstraint.ToLower()))
                {
                    people.Add(currP);
                }
            }

            //Sorts the arrayList

            IComparer myComparer = new CompareNamesClass();
            people.Sort(myComparer);

            return people;
        }
    }
}



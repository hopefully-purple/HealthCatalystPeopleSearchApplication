using System;
using System.Collections;

//TODO figure out how to get a picture in there
/*
 * The application accepts search input in a text box and then displays in a 
 * pleasing style a list of people where any part of their first or last name matches 
 * what was typed in the search box (displaying at least name, address, age, interests, and a picture). 
 * Solution should either seed data or provide a way to enter new users or both
 * Simulate search being slow and have the UI gracefully handle the delay
*/
namespace PeopleSearchApplication
{
    public class Person
    {

        private String[] arrayAtt;

        /*
         * Creates a person with 4 attribtutes:
         * Name
         * Address
         * Age
         * Interests
         * Picture
         * 
         * Person p = new Person("Pollyanna Perkins\t144 EdBrook Ave, Springs, AZ\t24\tMountain Biker, Finger Knitter\t<insert pic here>");       
         *
          */
        public Person(String attributes)
        {

            arrayAtt = attributes.Split("\t");

            //if the number of attributes lines != 5, throw illegalArg
            if (arrayAtt.Length != 5)
            {
                throw new System.ArgumentException("Wrong amount of attributes");
            }

            //if any line contains whitespace or is empty, throw illegArg
            if (!IsNotBlank(arrayAtt))
            {
                throw new System.ArgumentException("Blank Attributes");
            }

            this.ToString();
            this.GetName();
            this.GetAddress();
            this.GetAge();
            this.GetInterests();
            this.GetPicture();
        }

        public Person()
        {
            this.ToString();
            this.GetName();
            this.GetAddress();
            this.GetAge();
            this.GetInterests();
            this.GetPicture();
        }

        public object GetPicture()
        {
            return arrayAtt[4];
        }

        public String GetInterests()
        {
            return arrayAtt[3];
        }

        public String GetAge()
        {
            return arrayAtt[2];
        }

        public String GetAddress()
        {
            return arrayAtt[1];
        }

        public String GetName()
        {
            return arrayAtt[0];
        }

        /*
         * ToString from the Person class
         */
        public override String ToString()
        {
            return GetName() + "";
        }

        //---------------------------------------------------------------

        private bool IsNotBlank(String[] arrayA)
        {
            //goes through each array item
            foreach (String attr in arrayA)
            {
                if (string.IsNullOrEmpty(attr))
                {
                    //returns false if item is empty
                    return false;
                }
                else if (attr.Length > 0)
                {
                    //assumes that if the length of the item is 1 or more and starts with a whitespace, then it's all whitespace
                    //and returns false
                    if (Char.IsWhiteSpace(attr[0]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Teams
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
		//these Person Classes are personal notes
  /*      public class Person 
        {
            private int personID;
            private string name;
            private string role;


            public Person(int person_ID, string nm, string personRole)
            {
                personID = person_ID;
                name = nm;
                role = personRole;

            }
            public override string ToString()
            {
                return personID + ": " + name + ", role: " + role + "\n";
            }
        }
       */
        public class Team 
        {
            private int teamID;
          //  private int personID;
            private Person[] persons; //person array
            const int MAX_PERSONS = 100; 



            public Team(int team_ID) //constructor with teamID and persons
            {
                teamID = team_ID;
                persons = new Person[MAX_PERSONS];
            }
            public void SetTeamID(int team_ID)
            {
                teamID = team_ID;
            }
            public bool AddPerson(Person person)
            {
                int i = 0;
                while (i < MAX_PERSONS && persons[i] != null)
                    i++;
                if (i <  MAX_PERSONS)
                {
                    persons[i] = person;
                    return true;
                }
                return false;
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder("Team's ID: " + teamID + "\n ");
                for (int i = 0; i < MAX_PERSONS; i++)
                {
                    if (persons[i] != null)
                    {
                        sb.AppendLine(persons[i].ToString());
                    }
                }
                return sb.ToString();
            }
            

        }
    }
}

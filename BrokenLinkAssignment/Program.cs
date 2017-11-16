using DataStructures;
using DataStructures.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokenLinkAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Congratulations, you need to implement our empty datastructure but not change the contracts and you cannot use already existing LinkedList class in .NET
            // make sure all tests are green (do not edit tests)
            // find and fix any bugs you encounter
            // create a list here 
            // add 100 random members to it
            // print all 100 members to console

            var list = new SpecialLinkedList<int>();
            var test = new SpecialLinkedListTests();
            try
            {
                test.CanAddMember();
                test.CanSetHeadElement();
                //test.ThrowsOutOfIndex();
                test.RetrievesMembersByIndex();
                test.CanRemoveMember();
                test.CanRemoveMemberByIndex();
                test.CanPrintEmptyList();
                test.SupportsNullValues();
                test.CanPrintMembers();
                test.CanPrintMembersReverse();
                test.CanLoopUsingForeach();              
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("The provided index is out of range");
            }
            catch (ElementNotFoundException)
            {
                Console.WriteLine("The provided element does not exist in the list");
            }

            for (int i = 0; i < 100; i++)
                list.Add(i);

            Console.WriteLine(list.ToString());
            Console.ReadKey();


        }
    }
}

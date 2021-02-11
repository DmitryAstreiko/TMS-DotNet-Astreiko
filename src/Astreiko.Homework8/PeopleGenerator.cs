using System;
using System.Text;

namespace Astreiko.Homework8
{
    public class PeopleGenerator
    {
        /// <summary>
        /// Generator time
        /// </summary>
        private Random randomTime;

        /// <summary>
        /// Generator name
        /// </summary>
        private Random randomName;

        public PeopleGenerator()
        {
            randomTime = new Random();
            randomName = new Random();
        }

        /// <summary>
        /// Create class Person
        /// </summary>
        /// <returns></returns>
        internal Person GetPerson()
        {
            return new Person
            {
                TimeToProcess = randomTime.Next(10000),
                Name = GetRandomString(randomName.Next(5, 15))
            };
        }

        /// <summary>
        /// Get random string
        /// </summary>
        /// <param name="size">Length string</param>
        /// <param name="lowerCase">Flag use lower or upper</param>
        /// <returns></returns>
        private string GetRandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):   
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)randomName.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}
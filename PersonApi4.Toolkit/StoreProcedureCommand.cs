using System;
using System.Collections.Generic;
using System.Text;

namespace PersonApi4.Toolkit
{
    public class StoreProcedureCommand
    {

        public string Name { get; set; }
        public List<string> Parameters {get; set;}

        public StoreProcedureCommand()
        {
            Parameters = new List<string>();
        }
        public StoreProcedureCommand AddName (string value)
        {
            Name = value;

            return this;
        }

        public StoreProcedureCommand AddParameter (string value)
        {
            Parameters.Add($"'{value}'");

            return this;
        }

        public StoreProcedureCommand AddParameter(int value)
        {
            Parameters.Add($"{value}");            

            return this;
        }

        public StoreProcedureCommand AddParameter(DateTime value)
        {
            Parameters.Add($"'{value.ToString()}'");

            return this;
        }

        public string Generate()
        {                        
            return $"{Name} {string.Join(", ", Parameters)}";
        }
    }
}

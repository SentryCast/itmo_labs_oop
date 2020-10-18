using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace IniParser
{
    class IniParser
    {
        private string filename;

        public IniParser(string filename)
        {
            if (!filename.EndsWith(".ini"))
            {
                throw new WrongEnteredException();
            }
            if(!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            this.filename = filename;
        }

        // Item1 = section, Item2 = param, Item3 = value
        private List<Tuple<string, string, string>> inidata = new List<Tuple<string, string, string>>(); 

        public void Parse()
        {
            var validation = new Validation();
            
            string line;
            string validatedSection = "[DefaultSection]";
            string validatedParam;
            string validatedParamFirst, validatedParamSecond;
            using (StreamReader sr = new StreamReader(filename))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string cleanLine = validation.CommentCleaner(line);
                    if (validation.IsValidSection(cleanLine))
                    {
                        validatedSection = cleanLine;
                        continue;
                    }
                    if (validation.IsValidParam(cleanLine))
                    {

                        validatedParam = cleanLine;
                        validatedParamFirst = validatedParam.Substring(0, validatedParam.IndexOf("=")).Trim();
                        validatedParamSecond = validatedParam.Substring(validatedParam.IndexOf("=") + 1).Trim();

                        var t = Tuple.Create(validatedSection, validatedParamFirst, validatedParamSecond);
                        inidata.Add(t);
                        continue;
                    }
                    if (cleanLine == String.Empty)
                    {
                        continue;
                    }
                    else
                        throw new IncorrectStringFoundException(line);
                }
            }
            
        }

        public string GetValue(string userSection, string userParameter)
        {
            foreach(var value in inidata)
            {
                if (value.Item1 == userSection)
                {
                    if (value.Item2 == userParameter)
                    {
                        return value.Item3;
                    }
                }
            }
            return null;
        }
    }
}

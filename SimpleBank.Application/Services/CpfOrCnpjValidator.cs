using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Application.Services
{
    public class CpfOrCnpjValidator
    {
        public static bool IsValid(string document)
        {
            var cleanedDocument = new string(document.Where(char.IsDigit).ToArray());
            if (cleanedDocument.Length == 11)
            {
                return ValidateCpf(cleanedDocument);
            }
            else if (cleanedDocument.Length == 14)
            {
                return ValidateCnpj(cleanedDocument);
            }
            return false;
        }
        private static bool ValidateCpf(string cpf)
        {   
            return true;
        }
        private static bool ValidateCnpj(string cnpj)
        {
            return true;
        }
    }
}

using System;
using System.Text;

namespace LabaWork124
{
    //Implement class Morse_matrix derived from String_matrix, which realize IMorse_crypt
    class Morse_matrix : String_matrix, IMorse_crypt
    {
        public const int Size_2 = Alphabet.Size;
        private int offset_key = 0;

        //Implement Morse_matrix constructor with the int parameter for offset
        //Use fd(Alphabet.Dictionary_arr) and sd() methods
        public Morse_matrix(int inpInt = 0)
        {
            offset_key = inpInt;
            fd(Alphabet.Dictionary_arr);
            sd();

        }
        //Implement Morse_matrix constructor with the string [,] Dict_arr and int parameter for offset
        //Use fd(Dict_arr) and sd() methods
        public Morse_matrix(string[,] inpStr, int inpInt = 0)
        {
            offset_key = inpInt;
            fd(inpStr);
            sd();

        }

        private void fd(string[,] Dict_arr)
        {
            for (int ii = 0; ii < Size1; ii++)
                for (int jj = 0; jj < Size_2; jj++)
                    this[ii, jj] = Dict_arr[ii, jj];
        }

        private void sd()
        {
            int off = Size_2 - offset_key;
            for (int jj = 0; jj < off; jj++)
                this[1, jj] = this[1, jj + offset_key];
            for (int jj = off; jj < Size_2; jj++)
                this[1, jj] = this[1, jj - off];
        }

        //Implement Morse_matrix operator +
        public static Morse_matrix operator +(Morse_matrix matrix1, Morse_matrix matrix2)
        {
            var result = new Morse_matrix();

            return result;
        }

        private int? GetIDofSymbol(string Symbol, bool IsCrypt = true)
        {
            for (int i = 0; i < Size2; i++)
            {
                if (this[IsCrypt ? 0 : 1, i] == Symbol)
                    return i;
            }
            return null;
        }
        private string? GetChangedSymbol(string Symbol, bool IsCrypt = true, bool ReturnLetter = false)
        {
            if (Symbol == " ")
                return Symbol;
            var id = GetIDofSymbol(Symbol, IsCrypt);
            if (id is null)
                return null;

            int newID = (int)id + (IsCrypt ? offset_key : -1 * offset_key);
            if (newID < 0){ newID += Size_2 - 1; } 
            else if (newID > Size_2 - 1) { newID -= Size_2 - 1; }

            return this[ReturnLetter ? 0 : 1, newID];

        }
        private string GetChangedStr(string incString, bool isCrypt = true)
        {
            StringBuilder CryptedStr = new StringBuilder(incString.Length);
            foreach (var item in incString)
            {
                var newSymbol = GetChangedSymbol(item.ToString(), isCrypt);
                if (newSymbol is null)
                    throw new NotImplementedException();
                CryptedStr.Append(newSymbol);
            }
            return CryptedStr.ToString();
        }
        //Realize crypt() with string parameter
        //Use indexers
        public string Crypt(string incString)
        {
            return GetChangedStr(incString);
        }     

        //Realize decrypt() with string array parameter
        //Use indexers
        public string Decrypt(string[] incStringArr)
        {
            string[] Result = new string[incStringArr.Length];
            for (int i = 0; i < incStringArr.Length; i++)
            {
                var newSymbol = GetChangedSymbol(incStringArr[i], false, true);
                if (newSymbol is null)
                    throw new NotImplementedException();
                Result[i] = newSymbol;//GetChangedStr(incStringArr[i], false);
            }
            return string.Join("", Result);
        }

        //Implement Res_beep() method with string parameter to beep the string
        public void Res_beep(string ToBeep)
        {
            string itemStr;
            int i;
            foreach (var item in ToBeep)
            {
                itemStr = item.ToString();
                for (i = 0; i < Size_2; i++)
                {
                    if (this[0,i] == itemStr)
                    {
                        UsefulFunctions.ConsoleFunc.BeepString(this[1, i]);
                        break;
                    }
                }
            }
        }

    }
}


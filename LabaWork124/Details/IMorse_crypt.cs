namespace LabaWork124
{
    //Define interface IMorse_crypt wicth two methods
    public interface IMorse_crypt
    {
        //crypt - to crypt the string
        public string Crypt(string incString);
        //decrypt - to decrypt array of strings
        public string Decrypt(string[] incStringArr);

    }

}

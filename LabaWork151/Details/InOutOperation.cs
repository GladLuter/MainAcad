using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace LabaWork151
{
    class InOutOperation
    {
        // 1) declare properties  CurrentPath - path to file (without name of file), CurrentDirectory - name of current directory,
        // CurrentFile - name of current file
        public string CurrentPath { get; private set; }
        public string CurrentDirectory { get; private set; }
        public string CurrentFile { get; private set; }

        //private bool InnerCall = false;

        // 2) declare public methods:
        //ChangeLocation() - change of CurrentPath; 
        // method takes new file path as parameter, creates new directories (if it is necessary)
        public void ChangeLocation(string NewLocation){
            FileInfo file = null;
            if (!FileExistsAtLocation(null, file, NewLocation)) { 
            


            }

            CurrentPath = NewLocation;
            CurrentDirectory = file.DirectoryName;
            CurrentFile = file.Name;
        }
        // CreateDirectory() - create new directory in current location
        public void CreateDirectory(string name){
            FileInfo file = null;
            if (FileExistsAtLocation("Warning: You must change location to initialize path before creating new directory", file)) { return; }

            string NewDirectoryPath = $@"{file.Directory}\{name}\";
            FileInfo DirChecker = null;
            if (FileExistsAtLocation($"Warning: directory with name {name} is already exists and no need to be created", DirChecker, NewDirectoryPath)) { return; }
            Directory.CreateDirectory(NewDirectoryPath);
        }
        // WriteData() – save data to file
        // method takes data (info about computers) as parameter
        public async void WriteData(string[] data) {

            FileInfo FileInf = null;
            if (FileExistsAtLocation($"Warning: file not exists with location '{CurrentPath}'", FileInf)) { return; }
            
            await File.WriteAllLinesAsync(CurrentPath, data);
            //using (FileStream FileStream = File.Open(FileMode.Open, FileAccess.Write, FileShare.None)) {
            //    FileStream.Write();
            //}

        }
        public void WriteData(string data) {
            WriteData(new string[1] { data });
        }
        // ReadData() – read data from file
        // method returns info about computers after reading it from file
        public string ReadData() { return ""; }
        // WriteZip() – save data to zip file
        // method takes data (info about computers) as parameter
        public void WriteZip() { }
        // ReadZip() – read data from file
        // method returns info about computers after reading it from file
        public void ReadZip() { }
        // ReadAsync() – read data from file asynchronously
        // method is async
        // method returns Task with info about computers
        // use ReadLineAsync() method to read data from file
        // Note: don't forget about await
        public async Task ReadAsync() { }

        // 7)
        // ADVANCED:
        // WriteToMemoryStream() – save data to memory stream
        // method takes data (info about computers) as parameter
        // info about computers is saved to Memory Stream
        public void WriteToMemoryStream(Computer data) {
            // use  method GetBytes() from class UnicodeEncoding to save array of bytes from string data 
            // create new file stream
            // use method WriteTo() to save memory stream to file stream 
            // method returns file stream
        }

        // WriteToFileFromMemoryStream() – save data to file from memory stream and read it
        // method takes file stream as parameter
        // save data to file      
        public void WriteToFileFromMemoryStream(FileStream data) { }


        // Note: 
        // - use '//' in path string or @ before it (for correct path handling without escape sequence)
        // - use 'using' keyword to organize correct working with files
        // - don't forget to check path before any file or directory operations
        // - don't forget to check existed directory and file before creating
        // use File class to check files, Directory class to check directories, Path to check path

        private bool FileExistsAtLocation(string textError = null, FileInfo file = null, string FileLockation = null) {
            file = new FileInfo(FileLockation ?? CurrentPath);
            if (!file.Exists) {
                if (textError != null) { Console.WriteLine(textError); }
                return false;
            }
            return true;
        }

    }
}

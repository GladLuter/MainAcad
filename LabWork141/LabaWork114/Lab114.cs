using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork114
{
    class Lab114
    {
        // 1) declare enum ComputerType
        public enum ComputerType
        {
            Desktop,
            Laptop,
            Server
        }
        public enum SizeType
        {
            GB,
            TB
        }
        // 2) declare struct Computer
        public struct Computer
        {
            public Computer(ComputerType type_)
            {
                type = type_;
                switch (type_)
                {
                    case ComputerType.Desktop:
                        CPU = new CPU(4, 2.5);
                        memory = new AmountSize(6, SizeType.GB);
                        HDD = new AmountSize(500, SizeType.GB);
                        break;
                    case ComputerType.Laptop:
                        CPU = new CPU(2, 1.7);
                        memory = new AmountSize(4, SizeType.GB);
                        HDD = new AmountSize(250, SizeType.GB);
                        break;
                    case ComputerType.Server:
                        CPU = new CPU(8, 3);
                        memory = new AmountSize(16, SizeType.GB);
                        HDD = new AmountSize(2, SizeType.TB);
                        break;
                    default:
                        CPU = null;
                        memory = null;
                        HDD = null;
                        break;
                }
            }
            private ComputerType type;
            private CPU? CPU;
            private AmountSize? memory;
            private AmountSize? HDD;

        }
        public struct CPU
        {
            public CPU(int cores_, double HGz_)
            {
                cores = cores_;
                HGz = HGz_;
            }
            public int cores;
            public double HGz;
        }
        public struct AmountSize
        {
            public AmountSize(double amount_, SizeType size_)
            {
                amount = amount_;
                size = size_;
            }
            public double amount;
            public SizeType size;
        }
        static void Main()
        {
            // 3) declare jagged array of computers size 4 (4 departments)
            var departmentsPC = GetDepatmentsDefault();

            // 6) count total number of every type of computers

            // 7) count total number of all computers
            // Note: use loops and if-else statements
            // Note: use the same loop for 6) and 7)



            // 8) find computer with the largest storage (HDD) - 
            // compare HHD of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements


            // 9) find computer with the lowest productivity (CPU and memory) - 
            // compare CPU and memory of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements
            // Note: use logical oerators in statement conditions


            // 10) make desktop upgrade: change memory up to 8
            // change value of memory to 8 for every desktop. Don't do it for other computers
            // Note: use loops and if-else statements

        }

        public static Computer[][] GetDepatmentsDefault()
        {
            // 4) set the size of every array in jagged array (number of computers)
            Computer[][] departmentsPC = new Computer[4][];

            // 5) initialize array
            // Note: use loops and if-else statements
            departmentsPC[0] = new Computer[5]
            {
                    new Computer(ComputerType.Desktop),
                    new Computer(ComputerType.Desktop),
                    new Computer(ComputerType.Laptop),
                    new Computer(ComputerType.Laptop),
                    new Computer(ComputerType.Server)
            };
            departmentsPC[1] = new Computer[3]
            {
                    new Computer(ComputerType.Laptop),
                    new Computer(ComputerType.Laptop),
                    new Computer(ComputerType.Laptop)
            };
            departmentsPC[2] = new Computer[5]
            {
                    new Computer(ComputerType.Desktop),
                    new Computer(ComputerType.Desktop),
                    new Computer(ComputerType.Desktop),
                    new Computer(ComputerType.Laptop),
                    new Computer(ComputerType.Laptop)
            };
            departmentsPC[3] = new Computer[4]
            {
                    new Computer(ComputerType.Desktop),
                    new Computer(ComputerType.Laptop),
                    new Computer(ComputerType.Server),
                    new Computer(ComputerType.Server)
            };

            return departmentsPC;
        }
    }
}

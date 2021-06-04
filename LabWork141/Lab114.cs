using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork114
{
    static class Checker
    {
        public static bool AmountSize_FirstBiger(Lab114.AmountSize Value1, Lab114.AmountSize Value2) {         
            if (Value1.size == Value2.size && Value1.amount > Value2.amount) { return true; }
            else
            {
                var amount1 = Value1.size == Lab114.SizeType.TB ? Value1.amount : Value1.amount / 1000;
                var amount2 = Value2.size == Lab114.SizeType.TB ? Value2.amount : Value2.amount / 1000;
                return amount1 > amount2;
            }
        }
        public static bool CPU_FirstBiger(Lab114.CPU Value1, Lab114.CPU Value2)
        {
            return (Value1.HGz * Value1.cores) > (Value2.HGz * Value2.cores);
        }
    }
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

        // 2) declare struct Computer
        public struct Computer
        {
            public Computer(ComputerType type_)
            {
                PCType = type_;
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
            public void UpgradeMemory(double amount_, SizeType? size_ = null)
            {                
                memory = new AmountSize(amount_, ((size_ is null)? memory.Value.size : (SizeType)size_)); 
            }
            //public void Upgrade(ref dynamic field, params dynamic[] ForUpgrade)
            //{
            //    if (field == null) { return; }
            //    else if (field == CPU)
            //    {
            //        foreach (var item in ForUpgrade)
            //        {
            //            if (item.GetType() == typeof(int))
            //            {
            //                field.cores = item;
            //            } else if (item.GetType() == typeof(double))
            //            {
            //                field.HGz = item;
            //            }
            //        }
            //    } 
            //    else if (field == memory || field == HDD)
            //    {
            //        foreach (var item in ForUpgrade)
            //        {
            //            if (item.GetType() == typeof(double))
            //            {
            //                field.amount = item;
            //            }
            //            else if (item.GetType() == typeof(SizeType))
            //            {
            //                field.size = item;
            //            }
            //        }
            //    }

            //}
            public ComputerType PCType { get; private set; }
            public CPU? CPU { get; private set; }
            public AmountSize? memory { get; private set; }
            public AmountSize? HDD { get; private set; }

        }
       
        static void Main()
        {
            // 3) declare jagged array of computers size 4 (4 departments)
            var departmentsPC = GetDepatmentsDefault();

            // 6) count total number of every type of computers
            #region _6
            int TotalAmount = 0;
            int[,] CounterArr = new int[Enum.GetNames(typeof(ComputerType)).Count(),1]; 
            for (int i = 0; i < departmentsPC.Length; i++)
            {
                for(int j = 0; j < departmentsPC[i].Length; j++)
                {
                    CounterArr[(int)Convert.ChangeType(departmentsPC[i][j].PCType, typeof(int)), 0] += 1;
                    TotalAmount++;
                }
            }

            for(int i = 0; i < CounterArr.Length; i++)
            {
                Console.WriteLine($"{(ComputerType)i} total computer count is {CounterArr[i, 0]}");
            }
            #endregion

            // 7) count total number of all computers
            // Note: use loops and if-else statements
            // Note: use the same loop for 6) and 7)
            Console.WriteLine(new String('-', 100));
            Console.WriteLine($"All types total computer count is {TotalAmount}");


            // 8) find computer with the largest storage (HDD) - 
            // compare HHD of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements
            #region _8
            var PCWithLargestHDD = departmentsPC[0][0]; //default largest
            int[] PositionHigh = { 0, 0 };
            for (int i = 0; i < departmentsPC.Length; i++)
            {
                for (int j = 0; j < departmentsPC[i].Length; j++)
                {
                    if(departmentsPC[i][j].HDD is null) { continue; }
                    if (
                        (PCWithLargestHDD.HDD is null)
                        || (Checker.AmountSize_FirstBiger((AmountSize)departmentsPC[i][j].HDD, (AmountSize)PCWithLargestHDD.HDD))
                       )
                    {
                        PCWithLargestHDD = departmentsPC[i][j];
                        PositionHigh[0] = i;
                        PositionHigh[1] = j;
                    }
                }
            }
            Console.WriteLine(new String('-', 100));
            if (PCWithLargestHDD.HDD is null)
            {
                Console.WriteLine($"Unfortunately we don't have PC with storage...");
            }
            else
            {
                ShowPCInfo("Computer with largest storage", PCWithLargestHDD, PositionHigh);
            }
            #endregion
            
            // 9) find computer with the lowest productivity (CPU and memory) - 
            // compare CPU and memory of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements
            // Note: use logical oerators in statement conditions
            #region _9
            Computer[] PCWithLowestProductivity = { departmentsPC[0][0], departmentsPC[0][0] }; //default lowest
            int[][] PositionLow = new int[2][];
            PositionLow[0] = new int[2];
            PositionLow[1] = new int[2];
            for (int i = 0; i < departmentsPC.Length; i++)
            {
                for (int j = 0; j < departmentsPC[i].Length; j++)
                {
                    if (departmentsPC[i][j].memory is not null)
                    {
                        if (
                            (PCWithLowestProductivity[1].memory is null)
                            || (Checker.AmountSize_FirstBiger((AmountSize)PCWithLowestProductivity[1].memory, (AmountSize)departmentsPC[i][j].memory))
                           )
                        {
                            PCWithLowestProductivity[1] = departmentsPC[i][j];
                            PositionLow[1][0] = i;
                            PositionLow[1][1] = j;
                        }
                    }
                    if (departmentsPC[i][j].CPU is not null)
                    {
                        if (
                            (PCWithLowestProductivity[0].CPU is null)
                            || (Checker.CPU_FirstBiger((CPU)PCWithLowestProductivity[0].CPU, (CPU)departmentsPC[i][j].CPU))
                           )
                        {
                            PCWithLowestProductivity[0] = departmentsPC[i][j];
                            PositionLow[0][0] = i;
                            PositionLow[0][1] = j;
                        }
                    }
                }
            }
            Console.WriteLine(new String('-', 100));
            if (PCWithLowestProductivity[0].CPU is null)
            {
                Console.WriteLine($"Unfortunately we don't have PC with CPU...");
            }
            else
            {
                ShowPCInfo("Computer with lowest CPU", PCWithLowestProductivity[0], PositionLow[0]);
            }

            Console.WriteLine(new String('-', 100));
            if (PCWithLowestProductivity[1].memory is null)
            {
                Console.WriteLine($"Unfortunately we don't have PC with memory...");
            }
            else
            {
                ShowPCInfo("Computer with lowest memory", PCWithLowestProductivity[1], PositionLow[1]);
            }
            #endregion

            // 10) make desktop upgrade: change memory up to 8
            // change value of memory to 8 for every desktop. Don't do it for other computers
            // Note: use loops and if-else statements
            #region _10
            Console.WriteLine(new String('-', 100));
            for (int i = 0; i < departmentsPC.Length; i++)
            {
                for (int j = 0; j < departmentsPC[i].Length; j++)
                {
                    if (departmentsPC[i][j].PCType == ComputerType.Desktop)
                    {
                        Console.WriteLine($"{departmentsPC[i][j].PCType} by index [{i}][{j}] memmory before {departmentsPC[i][j].memory.Value.amount} {departmentsPC[i][j].memory.Value.size}");
                        departmentsPC[i][j].UpgradeMemory(8);
                        Console.WriteLine($"{departmentsPC[i][j].PCType} by index [{i}][{j}] memmory after {departmentsPC[i][j].memory.Value.amount} {departmentsPC[i][j].memory.Value.size}");
                    }
                }
            }
            #endregion

        }

        public static void ShowPCInfo(String Annonce, Computer PC, int[] Position)
        {
            Console.WriteLine($@"{Annonce}:
type {PC.PCType}:
CPU - {PC.CPU.Value.cores} cores, {PC.CPU.Value.HGz} HGz, 
memory - {PC.memory.Value.amount} {PC.memory.Value.size}
HDD - {PC.HDD.Value.amount} { PC.HDD.Value.size }
position in array [{Position[0]}][{Position[1]}]");
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

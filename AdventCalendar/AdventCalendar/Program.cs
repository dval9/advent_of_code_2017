using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventCalendar
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem1();
            Problem2();
            Problem3();
            Problem4();
            Problem5();
            Problem6();
            Problem7();
            Problem8();
            Problem9();
            Problem11();
            Problem12();
            Problem13();
            Problem14();
            Problem15();
            Problem16();
            Problem17();
            Problem18();
            Problem19();
            Problem20();
            Problem21();
            Problem22();
            Problem23();
            Problem24();
            Problem25();
            Console.ReadLine();
        }

        /* Day 1
         * part 1:
         * review a sequence of digits and find the sum of all digits that match the next digit in the list
         * the list is circular
         * ex. 1122 = 1 + 2 = 3
         *     1111 = 1 + 1 + 1 + 1 = 4
         *     1234 = 0
         *     91212129 = 9
         *     
         * part 2:
         * same, but only include a digit if it is halfway around the list
         * the inputs should be even length
         * ex. 1122 = 6
         *     1221 = 0
         *     123425 = 4
         *     123123 = 12
         *     12131415 = 4
         */
        static void Problem1()
        {
            string __input = "428122498997587283996116951397957933569136949848379417125362532269869461185743113733992331379856446362482129646556286611543756564275715359874924898113424472782974789464348626278532936228881786273586278886575828239366794429223317476722337424399239986153675275924113322561873814364451339186918813451685263192891627186769818128715595715444565444581514677521874935942913547121751851631373316122491471564697731298951989511917272684335463436218283261962158671266625299188764589814518793576375629163896349665312991285776595142146261792244475721782941364787968924537841698538288459355159783985638187254653851864874544584878999193242641611859756728634623853475638478923744471563845635468173824196684361934269459459124269196811512927442662761563824323621758785866391424778683599179447845595931928589255935953295111937431266815352781399967295389339626178664148415561175386725992469782888757942558362117938629369129439717427474416851628121191639355646394276451847131182652486561415942815818785884559193483878139351841633366398788657844396925423217662517356486193821341454889283266691224778723833397914224396722559593959125317175899594685524852419495793389481831354787287452367145661829287518771631939314683137722493531318181315216342994141683484111969476952946378314883421677952397588613562958741328987734565492378977396431481215983656814486518865642645612413945129485464979535991675776338786758997128124651311153182816188924935186361813797251997643992686294724699281969473142721116432968216434977684138184481963845141486793996476793954226225885432422654394439882842163295458549755137247614338991879966665925466545111899714943716571113326479432925939227996799951279485722836754457737668191845914566732285928453781818792236447816127492445993945894435692799839217467253986218213131249786833333936332257795191937942688668182629489191693154184177398186462481316834678733713614889439352976144726162214648922159719979143735815478633912633185334529484779322818611438194522292278787653763328944421516569181178517915745625295158611636365253948455727653672922299582352766484";
            char[] input = __input.ToCharArray();
            char first = input[0];
            int sum1 = 0, sum2 = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals(input[(i + 1) % input.Length]))
                    sum1 += (int)Char.GetNumericValue(input[i]);
                if (input[i].Equals(input[(i + (input.Length / 2)) % input.Length]))
                    sum2 += (int)Char.GetNumericValue(input[i]);
            }

            Console.WriteLine("Day 1, Problem 1: " + sum1);
            Console.WriteLine("Day 1, Problem 2: " + sum2);
        }

        /* Day 2
         * part 1:
         * calculate checksum of 2d array
         * get difference between largest and smallest values on each row
         * sum them together
         * 
         * part 2:
         * find the numbers on each line that divide eachother
         * sum each lines result
         */
        static void Problem2()
        {
            string[] __input = {"1919	2959	82	507	3219	239	3494	1440	3107	259	3544	683	207	562	276	2963",
                                "587 878 229 2465    2575    1367    2017    154 152 157 2420    2480    138 2512    2605    876",
                                "744 6916    1853    1044    2831    4797    213 4874    187 6051    6086    7768    5571    6203    247 285",
                                "1210    1207    1130    116 1141    563 1056    155 227 1085    697 735 192 1236    1065    156",
                                "682 883 187 307 269 673 290 693 199 132 505 206 231 200 760 612",
                                "1520    95  1664    1256    685 1446    253 88  92  313 754 1402    734 716 342 107",
                                "146 1169    159 3045    163 3192    1543    312 161 3504    3346    3231    771 3430    3355    3537",
                                "177 2129    3507    3635    2588    3735    3130    980 324 266 1130    3753    175 229 517 3893",
                                "4532    164 191 5169    4960    3349    3784    3130    5348    5036    2110    151 5356    193 1380    3580",
                                "2544    3199    3284    3009    3400    953 3344    3513    102 1532    161 143 2172    2845    136 2092",
                                "194 5189    3610    4019    210 256 5178    4485    5815    5329    5457    248 5204    4863    5880    3754",
                                "3140    4431    4534    4782    3043    209 216 5209    174 161 3313    5046    1160    160 4036    111",
                                "2533    140 4383    1581    139 141 2151    2104    2753    4524    4712    866 3338    2189    116 4677",
                                "1240    45  254 1008    1186    306 633 1232    1457    808 248 1166    775 1418    1175    287",
                                "851 132 939 1563    539 1351    1147    117 1484    100 123 490 152 798 1476    543",
                                "1158    2832    697 113 121 397 1508    118 2181    2122    809 2917    134 2824    3154    2791" };
            int[,] input = new int[16, 16];
            for (int i = 0; i < 16; i++)
            {
                string[] line = __input[i].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < 16; j++)
                {
                    input[i, j] = Int32.Parse(line[j]);
                }
            }
            int checksum1 = 0, checksum2 = 0;
            for (int i = 0; i < 16; i++)
            {
                int min = 10000, max = 0;
                for (int j = 0; j < 16; j++)
                {
                    if (input[i, j] > max)
                    {
                        max = input[i, j];
                    }
                    if (input[i, j] < min)
                    {
                        min = input[i, j];
                    }
                }
                checksum1 += (max - min);
            }
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    for (int k = j + 1; k < 16; k++)
                    {
                        if ((input[i, j] % input[i, k]) == 0)
                        {
                            checksum2 += input[i, j] / input[i, k];
                            j = k = 16;
                        }
                        else if ((input[i, k] % input[i, j]) == 0)
                        {
                            checksum2 += input[i, k] / input[i, j];
                            j = k = 16;
                        }
                    }
                }
            }


            Console.WriteLine("Day 2, Problem 1: " + checksum1);
            Console.WriteLine("Day 2, Problem 2: " + checksum2);
        }

        /* Day 3
         * problem 1:
         * find taxi cab metric distance
         * numbers start at 1, spiral counter clockwise outwards
         * ex. 5 4 3
         *     6 1 2
         *     7 8 9
         * 
         * problem 2:
         * starting at center, values spiral out counter clockwise
         * values are sum of adj values
         * find first value larger than input
         */
        static void Problem3()
        {
            string __input = "347991";
            int input = Int32.Parse(__input);
            int distance = 0;
            int ring = (int)Math.Floor(Math.Sqrt((input - 1) / 4));
            while ((4 * ring * ring + 4 * ring + 1) < input)
            {
                ring++;
            }
            int ring_max = (ring * 2 + 1) * (ring * 2 + 1);
            int ring_min = ring_max - (ring * 2);
            while (input <= ring_min)
            {
                ring_min = ring_min - (ring * 2);
            }
            distance = ring + ((ring_min + (ring * 2) - ring_min) / 2) - ((ring_min + (ring * 2)) - input);

            Console.WriteLine("Day 3, Problem 1: " + distance);

            int max = 0;
            int grid_size = 15;
            int[,] grid = new int[grid_size, grid_size];
            for (int i = 0; i < grid_size; i++)
            {
                for (int j = 0; j < grid_size; j++)
                {
                    grid[i, j] = 0;
                }
            }
            int x_0 = grid_size / 2;
            int y_0 = grid_size / 2;
            grid[x_0, y_0] = 1;
            ring = 1;
            int ring_br = (ring * 2 + 1) * (ring * 2 + 1);
            int ring_bl = ring_br - (ring * 2);
            int ring_tl = ring_bl - (ring * 2);
            int ring_tr = ring_tl - (ring * 2);
            ring_min = ((ring - 1) * 2 + 1) * ((ring - 1) * 2 + 1);
            int x = x_0;
            int y = y_0;
            for (int i = 1; ; i++)
            {
                if (i >= ring_br)
                {
                    ring++;
                    ring_br = (ring * 2 + 1) * (ring * 2 + 1);
                    ring_bl = ring_br - (ring * 2);
                    ring_tl = ring_bl - (ring * 2);
                    ring_tr = ring_tl - (ring * 2);
                    ring_min = ((ring - 1) * 2 + 1) * ((ring - 1) * 2 + 1);
                }
                if (i == ring_min)
                {
                    x++;
                }
                else if (i < ring_tr)
                {
                    y--;
                }
                else if (i < ring_tl)
                {
                    x--;
                }
                else if (i < ring_bl)
                {
                    y++;
                }
                else if (i < ring_br)
                {
                    x++;
                }
                grid[x, y] = grid[x, y + 1] + grid[x + 1, y] + grid[x + 1, y + 1] +
                    grid[x - 1, y] + grid[x, y - 1] + grid[x - 1, y - 1] +
                    grid[x - 1, y + 1] + grid[x + 1, y - 1];
                if (grid[x, y] > input)
                {
                    max = grid[x, y];
                    break;
                }
            }

            Console.WriteLine("Day 3, Problem 2: " + max);
        }

        /* Day 4
         * problem 1:
         * read file problem4.txt
         * count lines that have unique words
         * 
         * problem 2:
         * count lines where none of the words are anagrams of eachother
         */
        static void Problem4()
        {
            var lines = File.ReadLines(@"H:\WORKING\kaggle\AdventCalendar\AdventCalendar\problem4.txt");
            int valid = 0, valid2 = 0;
            foreach (string line in lines)
            {
                string[] new_line = line.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> dict = new Dictionary<string, string>();
                for (int i = 0; i < new_line.Length; i++)
                {
                    if (dict.ContainsKey(new_line[i]))
                        break;
                    dict.Add(new_line[i], null);
                }
                if (dict.Count == new_line.Length)
                    valid++;
                for (int i = 0; i < new_line.Length; i++)
                {
                    var my_line = new_line[i].ToCharArray();
                    Array.Sort(my_line);
                    new_line[i] = new string(my_line);
                }
                dict = new Dictionary<string, string>();
                for (int i = 0; i < new_line.Length; i++)
                {
                    if (dict.ContainsKey(new_line[i]))
                        break;
                    dict.Add(new_line[i], null);
                }
                if (dict.Count == new_line.Length)
                    valid2++;

            }

            Console.WriteLine("Day 4, Problem 1: " + valid);
            Console.WriteLine("Day 4, Problem 2: " + valid2);
        }

        /* Day 5
         * 
         */
        static void Problem5()
        {
            Console.WriteLine("Day 5, Problem 1: ");
            Console.WriteLine("Day 5, Problem 2: ");
        }

        /* Day 6
         * 
         */
        static void Problem6()
        {
            Console.WriteLine("Day 6, Problem 1: ");
            Console.WriteLine("Day 6, Problem 2: ");
        }

        /* Day 7
         * 
         */
        static void Problem7()
        {
            Console.WriteLine("Day 7, Problem 1: ");
            Console.WriteLine("Day 7, Problem 2: ");
        }

        /* Day 8
         * 
         */
        static void Problem8()
        {
            Console.WriteLine("Day 8, Problem 1: ");
            Console.WriteLine("Day 8, Problem 2: ");
        }

        /* Day 9
         * 
         */
        static void Problem9()
        {
            Console.WriteLine("Day 9, Problem 1: ");
            Console.WriteLine("Day 9, Problem 2: ");
        }

        /* Day 10
         * 
         */
        static void Problem10()
        {
            Console.WriteLine("Day 10, Problem 1: ");
            Console.WriteLine("Day 10, Problem 2: ");
        }

        /*  Day 11
         * 
         */
        static void Problem11()
        {
            Console.WriteLine("Day 11, Problem 1: ");
            Console.WriteLine("Day 11, Problem 2: ");
        }

        /* Day 12
         * 
         */
        static void Problem12()
        {
            Console.WriteLine("Day 12, Problem 1: ");
            Console.WriteLine("Day 12, Problem 2: ");
        }

        /* Day 13
         * 
         */
        static void Problem13()
        {
            Console.WriteLine("Day 13, Problem 1: ");
            Console.WriteLine("Day 13, Problem 2: ");
        }

        /* Day 14
         * 
         */
        static void Problem14()
        {
            Console.WriteLine("Day 14, Problem 1: ");
            Console.WriteLine("Day 14, Problem 2: ");
        }

        /* Day 15
         * 
         */
        static void Problem15()
        {
            Console.WriteLine("Day 15, Problem 1: ");
            Console.WriteLine("Day 15, Problem 2: ");
        }

        /* Day 16
         * 
         */
        static void Problem16()
        {
            Console.WriteLine("Day 16, Problem 1: ");
            Console.WriteLine("Day 16, Problem 2: ");
        }

        /* Day 17
         * 
         */
        static void Problem17()
        {
            Console.WriteLine("Day 17, Problem 1: ");
            Console.WriteLine("Day 17, Problem 2: ");
        }

        /* Day 18
         * 
         */
        static void Problem18()
        {
            Console.WriteLine("Day 18, Problem 1: ");
            Console.WriteLine("Day 18, Problem 2: ");
        }

        /* Day 19
         * 
         */
        static void Problem19()
        {
            Console.WriteLine("Day 19, Problem 1: ");
            Console.WriteLine("Day 19, Problem 2: ");
        }

        /* Day 20
         * 
         */
        static void Problem20()
        {
            Console.WriteLine("Day 20, Problem 1: ");
            Console.WriteLine("Day 20, Problem 2: ");
        }

        /* Day 21
         * 
         */
        static void Problem21()
        {
            Console.WriteLine("Day 21, Problem 1: ");
            Console.WriteLine("Day 21, Problem 2: ");
        }

        /* Day 22
         * 
         */
        static void Problem22()
        {
            Console.WriteLine("Day 22, Problem 1: ");
            Console.WriteLine("Day 22, Problem 2: ");
        }

        /* Day 23
         * 
         */
        static void Problem23()
        {
            Console.WriteLine("Day 23, Problem 1: ");
            Console.WriteLine("Day 23, Problem 2: ");
        }

        /* Day 24
         * 
         */
        static void Problem24()
        {
            Console.WriteLine("Day 24, Problem 1: ");
            Console.WriteLine("Day 24, Problem 2: ");
        }

        /* Day 25
         * 
         */
        static void Problem25()
        {
            Console.WriteLine("Day 25, Problem 1: ");
            Console.WriteLine("Day 25, Problem 2: ");
        }
    }
}

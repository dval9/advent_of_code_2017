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
            Problem1(@"..\..\problem1.txt");
            Problem2(@"..\..\problem2.txt");
            Problem3(@"..\..\problem3.txt");
            Problem4(@"..\..\problem4.txt");
            Problem5(@"..\..\problem5.txt");
            Problem6(@"..\..\problem6.txt");
            Problem7(@"..\..\problem7.txt");
            Problem8(@"../../problem8.txt");
            Problem9(@"..\..\problem9.txt");
            Problem10(@"..\..\problem10.txt");
            Problem11(@"..\..\problem11.txt");
            Problem12(@"..\..\problem12.txt");
            //Problem13(@"..\..\problem13.txt");
            //Problem14(@"..\..\problem14.txt");
            //Problem15(@"..\..\problem15.txt");
            //Problem16(@"..\..\problem16.txt");
            //Problem17(@"..\..\problem17.txt");
            //Problem18(@"..\..\problem18.txt");
            //Problem19(@"..\..\problem19.txt");
            //Problem20(@"..\..\problem20.txt");
            //Problem21(@"..\..\problem21.txt");
            //Problem22(@"..\..\problem22.txt");
            //Problem23(@"..\..\problem23.txt");
            //Problem24(@"..\..\problem24.txt");
            //Problem25(@"..\..\problem25.txt");
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
        static void Problem1(string __input)
        {
            var line = File.ReadAllLines(__input);
            char[] input = line[0].ToCharArray();
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
        static void Problem2(string __input)
        {
            var lines = File.ReadLines(__input);
            int[,] input = new int[16, 16];
            for (int i = 0; i < 16; i++)
            {
                string[] line = lines.ElementAt(i).Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < 16; j++)
                    input[i, j] = Int32.Parse(line[j]);
            }
            int checksum1 = 0, checksum2 = 0;
            for (int i = 0; i < 16; i++)
            {
                int min = 10000, max = 0;
                for (int j = 0; j < 16; j++)
                {
                    if (input[i, j] > max)
                        max = input[i, j];
                    if (input[i, j] < min)
                        min = input[i, j];
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
        static void Problem3(string __input)
        {
            var line = File.ReadAllLines(__input);
            int input = Int32.Parse(line[0]);
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
            int grid_size = 15;//just choose sufficently big that shouldnt error, but not slow
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
        static void Problem4(string __input)
        {
            var lines = File.ReadLines(__input);
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
         * problem 1:
         * given a list of numbers, each line is a jump count
         * jump forward or negative by the count
         * after a jump increment that number by 1
         * count how long it takes to fall off end of list
         * 
         * problem 2:
         * same thing, but decrease the number if the value is >= 3
         */
        static void Problem5(string __input)
        {
            var lines = File.ReadLines(__input);
            List<int> jumps = new List<int>();
            foreach (string line in lines)
                jumps.Add(int.Parse(line));
            int steps = 0, steps2 = 0;
            int pos = 0;
            while (pos < jumps.Count)
            {
                var old_pos = pos;
                pos += jumps[pos];
                jumps[old_pos] += 1;
                steps++;
            }
            jumps.Clear();
            foreach (string line in lines)
                jumps.Add(int.Parse(line));
            pos = 0;
            while (pos < jumps.Count)
            {
                var old_pos = pos;
                pos += jumps[pos];
                if (jumps[old_pos] >= 3)
                    jumps[old_pos] -= 1;
                else
                    jumps[old_pos] += 1;
                steps2++;
            }

            Console.WriteLine("Day 5, Problem 1: " + steps);
            Console.WriteLine("Day 5, Problem 2: " + steps2);
        }

        /* Day 6
         * problem 1:
         * file is an array of numbers, blocks 
         * find largest number, first wins ties
         * set to 0, redistribute to blocks by adding 1 to each sequential block
         * how many unique states before finding one seen before
         * 
         * problem 2:
         * continue on, what is length of this cycle
         */
        static void Problem6(string __input)
        {
            var lines = File.ReadAllLines(__input);
            List<int> blocks = new List<int>();
            var line = lines[0].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            foreach (string l in line)
                blocks.Add(int.Parse(l));
            Dictionary<string, string> mem = new Dictionary<string, string>();
            string config = "";
            foreach (int m in blocks)
                config += m.ToString() + " ";
            mem.Add(config, null);
            bool start = false;
            int ans1 = 0;
            for (;;)
            {
                config = "";
                int max = 0;
                int max_elem = 0;
                for (int i = 0; i < blocks.Count; i++)
                {
                    if (blocks[i] > max)
                    {
                        max = blocks[i];
                        max_elem = i;
                    }
                }
                blocks[max_elem] = 0;
                for (int i = 1; i <= max; i++)
                {
                    blocks[(max_elem + i) % blocks.Count] += 1;
                }
                foreach (int m in blocks)
                    config += m.ToString() + " ";
                if (mem.ContainsKey(config))
                {
                    if (!start)
                    {
                        ans1 = mem.Keys.Count;
                        start = true;
                        mem.Clear();
                    }
                    else
                        break;
                }
                mem.Add(config, null);
            }
            Console.WriteLine("Day 6, Problem 1: " + ans1);
            Console.WriteLine("Day 6, Problem 2: " + mem.Keys.Count);
        }

        /* Day 7
         * problem 1:
         * create a tree structure from the file, find the root.
         * 
         * problem 2:
         * each node needs children with equal total weight
         * one node is wrong weight
         * what should its weight be?
         */
        static void Problem7(string __input)
        {
            var lines = File.ReadAllLines(__input);
            char[] delims = { '(', ')', '-', '>', ',', ' ' };
            Dictionary<string, int> weights = new Dictionary<string, int>();
            SortedList<string, int> total_weights = new SortedList<string, int>();
            Dictionary<string, List<string>> tree = new Dictionary<string, List<string>>();
            Dictionary<string, int> ischild = new Dictionary<string, int>();
            string root = "";
            foreach (string line in lines)
            {
                string[] nodes = line.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                weights.Add(nodes[0], int.Parse(nodes[1]));
                ischild.Add(nodes[0], 0);
                List<string> childs = new List<string>();
                for (int i = 2; i < nodes.Length; i++)
                    childs.Add(nodes[i]);
                tree.Add(nodes[0], childs);
            }
            foreach (KeyValuePair<string, List<string>> e in tree)
            {
                List<string> children = e.Value;
                foreach (string c in children)
                {
                    ischild[c] = 1;
                }
            }
            foreach (KeyValuePair<string, int> e in ischild)
            {
                if (e.Value != 1)
                {
                    root = e.Key;
                    break;
                }
            }
            GetWeight(ref tree, ref weights, ref total_weights, root);
            total_weights.OrderBy(k => k.Key);
            string curr_node = root;
            int good_weight = 0;
            while (true)
            {
                List<Tuple<string, int>> list = new List<Tuple<string, int>>();
                foreach (string child in tree[curr_node])
                {
                    list.Add(new Tuple<string, int>(child, total_weights[child]));
                }
                list.Sort((x, y) => x.Item2.CompareTo(y.Item2));
                if (list[0].Item2 != list[1].Item2)
                {
                    good_weight = list[0].Item2;
                    curr_node = list[0].Item1;
                }
                else if (list[list.Count - 1].Item2 != list[list.Count - 2].Item2)
                {
                    good_weight = list[0].Item2;
                    curr_node = list[list.Count - 1].Item1;
                }
                else
                    break;
            }
            int suggest = weights[curr_node] - ((total_weights[curr_node] - good_weight) > 0 ? (total_weights[curr_node] - good_weight) : (-good_weight - total_weights[curr_node]));
            Console.WriteLine("Day 7, Problem 1: " + root);
            Console.WriteLine("Day 7, Problem 2: " + suggest);

            int GetWeight(ref Dictionary<string, List<string>> rtree, ref Dictionary<string, int> rweights, ref SortedList<string, int> rtotal_weights, string name)
            {
                int weight = 0;
                weight += rweights[name];
                foreach (string child in rtree[name])
                    weight += GetWeight(ref rtree, ref rweights, ref rtotal_weights, child);
                rtotal_weights.Add(name, weight);
                return weight;
            }
        }

        /* Day 8
        * problem 1:
        * given list of instructions
        * preform operation to regester
        * find largest value stored in a register
        * 
        * problem 2:
        * what was the largest value ever held in a register
        */
        static void Problem8(string __input)
        {
            var lines = File.ReadAllLines(__input);
            Dictionary<string, int> reg = new Dictionary<string, int>();
            char[] delims = { ' ' };
            int largest_ever = 0;
            foreach (string instruct in lines)
            {
                string[] i = instruct.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                if (!reg.ContainsKey(i[0]))
                    reg.Add(i[0], 0);
            }
            foreach (string instruct in lines)
            {
                string[] i = instruct.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                bool cond;
                switch (i[5])
                {
                    case "<":
                        cond = (reg[i[4]] < int.Parse(i[6]));
                        if (cond)
                        {
                            switch (i[1])
                            {
                                case "inc":
                                    reg[i[0]] += int.Parse(i[2]);
                                    if (reg[i[0]] > largest_ever)
                                        largest_ever = reg[i[0]];
                                    break;
                                case "dec":
                                    reg[i[0]] -= int.Parse(i[2]);
                                    if (reg[i[0]] > largest_ever)
                                        largest_ever = reg[i[0]];
                                    break;
                            }
                        }
                        break;
                    case ">":
                        cond = (reg[i[4]] > int.Parse(i[6]));
                        if (cond)
                        {
                            switch (i[1])
                            {
                                case "inc":
                                    reg[i[0]] += int.Parse(i[2]);
                                    if (reg[i[0]] > largest_ever)
                                        largest_ever = reg[i[0]];
                                    break;
                                case "dec":
                                    reg[i[0]] -= int.Parse(i[2]);
                                    if (reg[i[0]] > largest_ever)
                                        largest_ever = reg[i[0]];
                                    break;
                            }
                        }
                        break;
                    case ">=":
                        cond = (reg[i[4]] >= int.Parse(i[6]));
                        if (cond)
                        {
                            switch (i[1])
                            {
                                case "inc":
                                    reg[i[0]] += int.Parse(i[2]);
                                    if (reg[i[0]] > largest_ever)
                                        largest_ever = reg[i[0]];
                                    break;
                                case "dec":
                                    reg[i[0]] -= int.Parse(i[2]);
                                    if (reg[i[0]] > largest_ever)
                                        largest_ever = reg[i[0]];
                                    break;
                            }
                        }
                        break;
                    case "<=":
                        cond = (reg[i[4]] <= int.Parse(i[6]));
                        if (cond)
                        {
                            switch (i[1])
                            {
                                case "inc":
                                    reg[i[0]] += int.Parse(i[2]);
                                    if (reg[i[0]] > largest_ever)
                                        largest_ever = reg[i[0]];
                                    break;
                                case "dec":
                                    reg[i[0]] -= int.Parse(i[2]);
                                    if (reg[i[0]] > largest_ever)
                                        largest_ever = reg[i[0]];
                                    break;
                            }
                        }
                        break;
                    case "==":
                        cond = (reg[i[4]] == int.Parse(i[6]));
                        if (cond)
                        {
                            switch (i[1])
                            {
                                case "inc":
                                    reg[i[0]] += int.Parse(i[2]);
                                    if (reg[i[0]] > largest_ever)
                                        largest_ever = reg[i[0]];
                                    break;
                                case "dec":
                                    reg[i[0]] -= int.Parse(i[2]);
                                    if (reg[i[0]] > largest_ever)
                                        largest_ever = reg[i[0]];
                                    break;
                            }
                        }
                        break;
                    case "!=":
                        cond = (reg[i[4]] != int.Parse(i[6]));
                        if (cond)
                        {
                            switch (i[1])
                            {
                                case "inc":
                                    reg[i[0]] += int.Parse(i[2]);
                                    if (reg[i[0]] > largest_ever)
                                        largest_ever = reg[i[0]];
                                    break;
                                case "dec":
                                    reg[i[0]] -= int.Parse(i[2]);
                                    if (reg[i[0]] > largest_ever)
                                        largest_ever = reg[i[0]];
                                    break;
                            }
                        }
                        break;
                }
            }
            int largest = 0;
            foreach (var kvp in reg)
            {
                if (kvp.Value > largest)
                    largest = kvp.Value;
            }
            Console.WriteLine("Day 8, Problem 1: " + largest);
            Console.WriteLine("Day 8, Problem 2: " + largest_ever);
        }

        /* Day 9
         * problem 1:
         * parse string to find groups
         * find total sum of score of groups
         * each level of nesting = 1
         * i.e. {} = 1, {{}} = 1 + 2 = 3
         * 
         * problem 2:
         * garbage strings are <>
         * characters canceled with !
         * find non canceled garbage character count
         */
        static void Problem9(string __input)
        {
            string lines = File.ReadAllText(__input).Trim();
            lines = lines.Replace("\r\n", string.Empty);
            Stack<char> s = new Stack<char>();
            int score = 0;
            int non_garbage = 0;
            s.Push(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                if (s.Peek().Equals('{'))
                {
                    if (lines[i].Equals('{'))
                        s.Push(lines[i]);
                    else if (lines[i].Equals('<'))
                        s.Push(lines[i]);
                    else if (lines[i].Equals('}'))
                    {
                        score += s.Count;
                        s.Pop();
                    }
                }
                else if (s.Peek().Equals('<'))
                {
                    if (lines[i].Equals('!'))
                        i++;
                    else if (lines[i].Equals('>'))
                        s.Pop();
                    else
                        non_garbage++;
                }
            }
            Console.WriteLine("Day 9, Problem 1: " + score);
            Console.WriteLine("Day 9, Problem 2: " + non_garbage);
        }

        /* Day 10
         * problem 1:
         * create hash function
         * take list of ints 0..255
         * for each length in input, reverse that many from current pos
         * move position forward, list should be circular
         * 
         * problem 2:
         * take input lengths as ascii bytes
         * perform perm 64 times
         * xor 16 lengths blocks together
         * output is hex encoded
         */
        static void Problem10(string __input)
        {
            string lines = File.ReadAllText(__input).Trim();
            List<int> str = new List<int>();
            int pos = 0;
            int skip = 0;
            for (int i = 0; i < 256; i++)
                str.Add(i);
            char[] delims = { ',' };
            string[] lengths = lines.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            //lengths = new string[] { "3", "4", "1", "5" };
            for (int i = 0; i < lengths.Length; i++)
            {
                if (pos + int.Parse(lengths[i]) > str.Count)
                {
                    int end = str.Count - pos;
                    int rem = int.Parse(lengths[i]) - end;
                    List<int> temp = new List<int>();
                    temp.AddRange(str.GetRange(pos, end));
                    temp.AddRange(str.GetRange(0, rem));
                    temp.Reverse();
                    str.RemoveRange(pos, end);
                    str.RemoveRange(0, rem);
                    str.AddRange(temp.GetRange(0, end));
                    str.InsertRange(0, temp.GetRange(end, rem));
                }
                else
                    str.Reverse(pos, int.Parse(lengths[i]));
                pos = (pos + int.Parse(lengths[i]) + skip) % str.Count;
                skip++;
            }
            int result = str[0] * str[1];
            //lines = "";
            List<byte> input = Encoding.ASCII.GetBytes(lines).ToList();
            input.Add(Convert.ToByte(17));
            input.Add(Convert.ToByte(31));
            input.Add(Convert.ToByte(73));
            input.Add(Convert.ToByte(47));
            input.Add(Convert.ToByte(23));
            str.Clear();
            pos = 0;
            skip = 0;
            for (int i = 0; i < 256; i++)
                str.Add(i);
            for (int i = 0; i < 64; i++)
            {
                foreach (byte x in input)
                {
                    if (pos + x > str.Count)
                    {
                        int end = str.Count - pos;
                        int rem = x - end;
                        List<int> temp = new List<int>();
                        temp.AddRange(str.GetRange(pos, end));
                        temp.AddRange(str.GetRange(0, rem));
                        temp.Reverse();
                        str.RemoveRange(pos, end);
                        str.RemoveRange(0, rem);
                        str.AddRange(temp.GetRange(0, end));
                        str.InsertRange(0, temp.GetRange(end, rem));
                    }
                    else
                        str.Reverse(pos, x);
                    pos = (pos + x + skip) % str.Count;
                    skip++;
                }
            }
            List<int> dense = new List<int>();
            for (int i = 0; i < 16; i++)
            {
                int dh = str[i * 16];
                for (int j = 1; j < 16; j++)
                {
                    dh ^= str[i * 16 + j];
                }
                dense.Add(dh);
            }
            string output = "";
            foreach (int d in dense)
            {
                string s = d.ToString("X").Length == 1 ? "0" + d.ToString("X") : d.ToString("X");
                output += s;
            }
            Console.WriteLine("Day 10, Problem 1: " + result);
            Console.WriteLine("Day 10, Problem 2: " + output);
        }

        /*  Day 11
         * problem 1:
         * traverse hex grid
         * find distance to point
         * 
         * problem 2:
         * what was farthest position along path
         */
        static void Problem11(string __input)
        {
            string input = File.ReadAllText(__input).Trim();
            List<string> dirs = new List<string>();
            char[] delims = { ',' };
            dirs.AddRange(input.Split(delims, StringSplitOptions.RemoveEmptyEntries));
            int x = 0;
            int y = 0;
            int z = 0;
            int max = 0;
            int dist = 0;
            foreach (string dir in dirs)
            {
                switch (dir)
                {
                    case "n":
                        y++;
                        z--;
                        break;
                    case "ne":
                        x++;
                        z--;
                        break;
                    case "nw":
                        x--;
                        y++;
                        break;
                    case "s":
                        y--;
                        z++;
                        break;
                    case "se":
                        x++;
                        y--;
                        break;
                    case "sw":
                        x--;
                        z++;
                        break;
                }

                dist = (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2;
                if (max < dist)
                    max = (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2;
            }
            Console.WriteLine("Day 11, Problem 1: " + dist);
            Console.WriteLine("Day 11, Problem 2: " + max);
        }

        /* Day 12
         * 
         */
        static void Problem12(string __input)
        {
            string[] input = File.ReadAllLines(__input);
            Dictionary<int, int> pipes = new Dictionary<int, int>();
            char[] delims = { '<', '-', '>', ',', ' ' };
            int groups = 0;
            int group_0 = 0;
            for (int i = 0; i < input.Length; i++)
            {
                List<int> next = new List<int>();
                string[] line = input[i].Split(delims, StringSplitOptions.RemoveEmptyEntries);
                if (pipes.ContainsKey(int.Parse(line[0])))
                {
                    continue;
                }
                pipes.Add(int.Parse(line[0]), 1);
                groups++;
                for (int j = 1; j < line.Length; j++)
                {
                    if (pipes.ContainsKey(int.Parse(line[j])))
                    {
                        pipes[int.Parse(line[j])]++;
                    }
                    else
                    {
                        pipes.Add(int.Parse(line[j]), 1);
                        next.Add(int.Parse(line[j]));
                    }
                }
                while (next.Count != 0)
                {
                    line = input[next[0]].Split(delims, StringSplitOptions.RemoveEmptyEntries);
                    next.RemoveAt(0);
                    for (int j = 1; j < line.Length; j++)
                    {
                        if (pipes.ContainsKey(int.Parse(line[j])))
                        {
                            pipes[int.Parse(line[j])]++;
                        }
                        else
                        {
                            pipes.Add(int.Parse(line[j]), 1);
                            next.Add(int.Parse(line[j]));
                        }
                    }
                }
                if (i == 0)
                    group_0 = pipes.Count;
            }
            Console.WriteLine("Day 12, Problem 1: " + group_0);
            Console.WriteLine("Day 12, Problem 2: " + groups);
        }

        /* Day 13
         * 
         */
        static void Problem13(string __input)
        {


            Console.WriteLine("Day 13, Problem 1: ");
            Console.WriteLine("Day 13, Problem 2: ");
        }

        /* Day 14
         * 
         */
        static void Problem14(string __input)
        {
            Console.WriteLine("Day 14, Problem 1: ");
            Console.WriteLine("Day 14, Problem 2: ");
        }

        /* Day 15
         * 
         */
        static void Problem15(string __input)
        {
            Console.WriteLine("Day 15, Problem 1: ");
            Console.WriteLine("Day 15, Problem 2: ");
        }

        /* Day 16
         * 
         */
        static void Problem16(string __input)
        {
            Console.WriteLine("Day 16, Problem 1: ");
            Console.WriteLine("Day 16, Problem 2: ");
        }

        /* Day 17
         * 
         */
        static void Problem17(string __input)
        {
            Console.WriteLine("Day 17, Problem 1: ");
            Console.WriteLine("Day 17, Problem 2: ");
        }

        /* Day 18
         * 
         */
        static void Problem18(string __input)
        {
            Console.WriteLine("Day 18, Problem 1: ");
            Console.WriteLine("Day 18, Problem 2: ");
        }

        /* Day 19
         * 
         */
        static void Problem19(string __input)
        {
            Console.WriteLine("Day 19, Problem 1: ");
            Console.WriteLine("Day 19, Problem 2: ");
        }

        /* Day 20
         * 
         */
        static void Problem20(string __input)
        {
            Console.WriteLine("Day 20, Problem 1: ");
            Console.WriteLine("Day 20, Problem 2: ");
        }

        /* Day 21
         * 
         */
        static void Problem21(string __input)
        {
            Console.WriteLine("Day 21, Problem 1: ");
            Console.WriteLine("Day 21, Problem 2: ");
        }

        /* Day 22
         * 
         */
        static void Problem22(string __input)
        {
            Console.WriteLine("Day 22, Problem 1: ");
            Console.WriteLine("Day 22, Problem 2: ");
        }

        /* Day 23
         * 
         */
        static void Problem23(string __input)
        {
            Console.WriteLine("Day 23, Problem 1: ");
            Console.WriteLine("Day 23, Problem 2: ");
        }

        /* Day 24
         * 
         */
        static void Problem24(string __input)
        {
            Console.WriteLine("Day 24, Problem 1: ");
            Console.WriteLine("Day 24, Problem 2: ");
        }

        /* Day 25
         * 
         */
        static void Problem25(string __input)
        {
            Console.WriteLine("Day 25, Problem 1: ");
            Console.WriteLine("Day 25, Problem 2: ");
        }
    }
}

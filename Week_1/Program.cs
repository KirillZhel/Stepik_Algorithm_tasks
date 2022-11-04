using System.Data;

namespace Week_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine(Task_1());
			//Console.WriteLine(Task_2());
			//Console.WriteLine(Task_3());
			//Task_4();
			Task_5();
		}

		private static void Task_5()
		{
			// https://ulearn.me/course/basicprogramming2/Ochered_dlya_skol_zyashchego_srednego_fa97b4e4-2711-4534-9767-3cf695fba842
			// может быть полезным 

			throw new NotImplementedException();
		}

		private static void Task_4()
		{
			var q = int.Parse(Console.ReadLine());
			Stack<int> ints = new Stack<int>();
			Stack<int> maxInts = new Stack<int>();
			var requests = new List<string>();

			for (int i = 0; i < q; i++)
			{
				requests.Add(Console.ReadLine());
			}

			foreach (var request in requests)
			{
				if (request.StartsWith("push"))
					PushTo(ints, maxInts, request);
				else
					ProcessRequest(ints, maxInts, request);
			}
		}

		private static void ProcessRequest(Stack<int> ints, Stack<int> maxInts, string request)
		{
			if (request == "max")
			{
				Console.WriteLine(maxInts.Peek());
			}

			if (request == "pop" && ints.Count > 0)
				ints.Pop();

			if (request == "pop" && maxInts.Count > 0)
				maxInts.Pop();
		}

		private static void PushTo(Stack<int> ints, Stack<int> maxInts, string request)
		{
			int number = int.Parse(request.Split(' ')[1]);

			if (ints.Count <= 0 || maxInts.Count <= 0)
			{
				ints.Push(number);
				maxInts.Push(number);
			}

			if (number >= maxInts.Peek())
			{
				maxInts.Push(number);
			}
			else
			{
				maxInts.Push(maxInts.Peek());
			}
		}

		private static int Task_3()
		{
			throw new NotImplementedException();
		}

		private static int Task_2()
		{
			var treeDescription = new int[int.Parse(Console.ReadLine())];

			var array = Console.ReadLine().Split(' ');

			var height = 0;

			for (int i = 0; i < treeDescription.Length; i++)
			{
				treeDescription[i] = int.Parse(array[i]);
			}

			foreach (var elem in treeDescription)
			{
				var flag = elem;
				var currentHeight = 0;

				while (flag >= 0)
				{
					flag = treeDescription[flag];
					currentHeight++;
				}

				if (currentHeight > height)
				{
					height = currentHeight;
				}
			}

			Console.WriteLine();
			return height + 1;
		}

		private static string Task_1()
		{
			var input = Console.ReadLine().ToCharArray();
			var mistakeIndex = 0;
			var stack = new Stack<char>();

			var bracketDictionary = new Dictionary<char, char>()
			{
				{ '{', '}'},
				{ '(', ')'},
				{ '[', ']'}
			};

			for (int i = 0; i < input.Length; i++)
			{
				if (bracketDictionary.ContainsKey(input[i]))
				{
					stack.Push(input[i]);
				}
				else if (stack.Count > 0)
				{
					if (bracketDictionary[stack.Pop()] != input[i])
					{
						mistakeIndex = i + 1;
						return $"{mistakeIndex}";
					}
				}
				else
				{
					mistakeIndex = i + 1;
					return $"{mistakeIndex}";
				}
			}
			return "Success";
		}
	}
}
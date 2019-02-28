using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Hackerrank
 * Work Schedule
 * Date: 2018.02.28
 * Author: Nelson Lopes
*/

class Result
{
	public static List<string> findSchedules(int workHours, int dayHours, string pattern)
	{

		List<List<int>> list = new List<List<int>>();

		// 1 <= work_hours <= 56
		if (0 > workHours || workHours > 56)
			return new List<string>();

		// 1 <= day_hours <= 8
		if (0 > dayHours || dayHours > 8)
			return new List<string>();

		// | pattern | = 7
		if (pattern.Length != 7)
			return new List<string>();

		// Each character of pattern E {0,1,...,8}
		if (pattern.Except("012345678?".ToList()).Any())
			return new List<string>();

		BuildWeekList(dayHours, workHours, 0, pattern, null, ref list);

		return list.Select(x => string.Join(string.Empty, x)).ToList();
	}

	public static void BuildWeekList(int dh, int wh, int pi, string p, List<int> w, ref List<List<int>> l)
	{
		if (w == null)
			w = new List<int>();

		var i = pi + 1;

		if (p[pi] == '?')
			for (int h = 0; h <= dh; h++)
			{
				if (AddHourDay(dh, wh, i, h, p, ref w, ref l))
					break;
			}
		else
			AddHourDay(dh, wh, i, Convert.ToInt32(p[pi].ToString()), p, ref w, ref l);
	}

	private static bool AddHourDay(int dh, int wh, int pi, int h, string p, ref List<int> w, ref List<List<int>> l)
	{
		var myWeek = new List<int>(w) { h };
		if (pi == p.Length)
		{
			if (myWeek.Sum() == wh)
			{
				l.Add(myWeek);
				return true;
			}
		}
		else
			BuildWeekList(dh, wh, pi, p, myWeek, ref l);

		return false;
	}
}

class Solution
{
	public static void Main(string[] args)
	{

		int workHours = Convert.ToInt32(Console.ReadLine().Trim());

		int dayHours = Convert.ToInt32(Console.ReadLine().Trim());

		string pattern = Console.ReadLine();

		List<string> result = Result.findSchedules(workHours, dayHours, pattern);

		Console.WriteLine((String.Join("\n", result)));

		Console.ReadLine();
	}
}

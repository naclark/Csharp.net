using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

public class MinutesService : IMinutesService
{
	public int GetMinutes(DateTime toDate)
	{
        DateTime today = DateTime.Now;
        TimeSpan minutes = toDate - today;
        return (int)minutes.TotalMinutes;
	}
}
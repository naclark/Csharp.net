using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RandomSeed
/// </summary>
public class RandomSeed
{
	public RandomSeed()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int GetSeed() {
        Random rand = new Random();
        return rand.Next(9999999);
    }

}
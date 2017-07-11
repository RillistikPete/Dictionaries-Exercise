using System;
using System.Collections.Generic;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("GOO", "Google");
            stocks.Add("DOW", "Dow Jones Industrial");

            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();
            purchases.Add((ticker: "GM", shares: 50, price: 23.21));
            purchases.Add((ticker: "CAT", shares: 32, price: 17.87));
            purchases.Add((ticker: "GOO", shares: 80, price: 98.02));
            purchases.Add((ticker: "GOO", shares: 80, price: 109.02));
            purchases.Add((ticker: "GOO", shares: 80, price: 68.02));
            purchases.Add((ticker: "GM", shares: 90, price: 4.08));

            Dictionary<string, double> valuations = new Dictionary<string, double>();

            var value = 0;
                /* 
                    Define a new Dictionary to hold the aggregated purchase information.
                    - The key should be a string that is the full company name.
                    - The value will be the valuation of each stock (price*amount)

                    {
                        "General Electric": 35900,
                        "AAPL": 8445,
                        ...
                    }
                */

                // Iterate over the purchases and 
                foreach ((string ticker, int shares, double price) purchase in purchases)
                {
                    value = (int) purchase.shares *  (int) purchase.price;
                    Console.WriteLine($"{purchase.ticker}: {value}");
                    // Does the company name key already exist in the report dictionary?
                    
                    // If it does, update the total valuation
                    if ( valuations.ContainsKey(stocks[purchase.ticker])){
                        valuations[stocks[purchase.ticker]] += value;
                        
                    }
                    else {
                        valuations.Add(stocks[purchase.ticker], value);
                        Console.WriteLine($"{stocks[purchase.ticker]}: {value}");
                    // If not, add the new key and set its value
                    }
                }
        
                    //show each of the companies and purchase information
                foreach(KeyValuePair<string, double> purchase in valuations)
                {
                    Console.WriteLine($"{purchase.Key} sold {purchase.Value}");
                }

                
        }
    }
}

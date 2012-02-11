using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Testing.Framework;
using System.Linq.Expressions;

namespace ObservableTests
{
	#region Stop Loss Specifications
	public class StopLossSpecifications
	{
		public Specification when_the_price_changes;
		public Specification when_the_monkey_doesnt_fit_the_main_idea;
	}
	
    public class PriceChanged 
	{
        public PriceChanged (decimal priorPrice, decimal newPrice)
        {
           se PriorPrice = priorPrice;
            NewPrice = newPrice;
        }
        public readonly decimal PriorPrice;
        public readonly decimal NewPrice;
	}
    
    // when buying stock at price $10 
    // when stock goes below $9  ( upperprice + -1 )
    // then sellpoint 
    
    // when buying stock at price $10
    // when stock goes up to $14 
    // then sellpoint becomes $13
    
    // When price changes 
    // Then should recieve a 'price changed message'
    
    // pricepoint should only move if it's held for more than 15 seconds.
    
    // stop loss should only be triggered if the price point is held for more than 30 seconds.
    
    /// <summary>
    /// Keywords: 
    /// pricechanged : the change of a price.
    /// stockprice : the 
    /// pricepoint : current high
    /// stoploss : the sale at the min price
    /// </summary>
    
    
    
	#endregion
	
	
	
	
	#region Structural How it works.
	
    public class TranformerSpecifications
    {
        public Specification when_a_price_changes_for_a_stock = new TransformedSpecification<AGiven, AWhen, AThen>{
            On = () => { return new AGiven(); },  // Prep ( series of prior events? )
            Name = "Name",
            Before = () => {},
            When = given => { return new AWhen(); },  // Returns a command
            Finally = () => {},
            AndTransformedBy = when => { return new AThen(); }, // Runs the command : AThen = ienum<event>
            Expect = {
                athen => true,
                athen => true,
            }
        };
    }

    public class AGiven
	{

	}
    public class AWhen
	{

	}
    public class AThen
	{

	}
    
    #endregion
	

}
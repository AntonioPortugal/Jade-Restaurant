using RECODME.RD.Jade.Data.MenuInfo;
using System;


namespace RECODME.RD.Jade.WebApi.Models.MenuViewModel
{
	public class MenuViewModel
	{
		public Guid Id { get; set; }
		public DateTime Date { get; set; }
		public Guid MealIdId { get; set; }
		public Guid RestaurantId { get; set; }

		public Menu ToMenu() 
		{
			return new Menu(Id, DateTime.UtcNow, DateTime.UtcNow, false, Date, RestaurantId, MealIdId);
		}


		public static MenuViewModel Parse(Menu menu)
		{
			return new MenuViewModel()
			{
				Id = menu.Id,
				Date = menu.Date,
				RestaurantId = menu.RestaurantId,
				MealIdId = menu.MealId,
			};
		}


	}
}

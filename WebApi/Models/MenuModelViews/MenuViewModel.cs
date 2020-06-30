using RECODME.RD.Jade.Data.MenuInfo;
using System;


namespace WebApi.Models.MenuViewModel
{
	public class MenuViewModel
	{
		public Guid Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime Date { get; set; }
		public Guid MealIdId { get; set; }
		public Guid RestaurantId { get; set; }

		public Menu ToDietaryRestriction()
		{
			return new Menu(Id, DateTime.UtcNow, DateTime.UtcNow, IsDeleted, Date, RestaurantId, MealIdId);
		}


		public static MenuViewModel Parse(Menu menu)
		{
			return new MenuViewModel()
			{
				Id = menu.Id,
				IsDeleted = menu.IsDeleted,
				Date = menu.Date,
				RestaurantId = menu.RestaurantId,
				MealIdId = menu.MealId,
			};
		}


	}
}

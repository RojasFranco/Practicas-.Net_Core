using System;
using System.Reflection;
using System.Text;

namespace GyL.DDD.DotNet.Aplication.Notifications.Messages
{
	public static class NotificationMessages
	{
		#region Create
		public static DefaultNotifications Create_DtoIsNull { get; set; } = new DefaultNotifications { Property = "Dto", Message = "Object is required" };
		public static DefaultNotifications Create_IsNullOrEmpty { get; set; } = new DefaultNotifications { Property = "field", Message = "Field is required" };
		#endregion Create

		#region GetById
		public static DefaultNotifications GetById_InvalidId { get; set; } = new DefaultNotifications { Property = "id", Message = "The id is invalid" };
		public static DefaultNotifications GetById_NotFound { get; set; } = new DefaultNotifications { Property = "Entity", Message = "Not found" };
		#endregion GetById

		#region GetAll
		public static DefaultNotifications GetAll_NotFound { get; set; } = new DefaultNotifications { Property = "List<Entity>", Message = "Not found" };
		public static DefaultNotifications GetAll_IsNullOrEmpty { get; set; } = new DefaultNotifications { Property = "field", Message = "Field is required" };
		#endregion GetAll

		#region Update
		public static DefaultNotifications Update_DtoIsNull { get; set; } = new DefaultNotifications { Property = "Dto", Message = "Object is required" };
		public static DefaultNotifications Update_InvalidId { get; set; } = new DefaultNotifications { Property = "id", Message = "The id is invalid" };
		public static DefaultNotifications Update_IsNullOrEmpty { get; set; } = new DefaultNotifications { Property = "field", Message = "Field is required" };
		#endregion Update

		#region Delete
		public static DefaultNotifications Delete_InvalidId { get; set; } = new DefaultNotifications { Property = "id", Message = "The id is invalid" };
		#endregion Delete
	}

	public class DefaultNotifications
	{
		public string Property { get; set; }
		public string Message { get; set; }

		public override string ToString()
		{
			return $"{Property} {Message}";
		}

		public static string GetProperties()
		{
			StringBuilder stringBuilder = new StringBuilder();
			Type type = typeof(NotificationMessages);
			DefaultNotifications errorNotification = new DefaultNotifications();
			stringBuilder.AppendLine("| Property | Message |");
			stringBuilder.AppendLine("| -- | -- |");
			foreach (PropertyInfo propertyInfo in type.GetProperties())
			{
				DefaultNotifications error = (DefaultNotifications)propertyInfo.GetValue(errorNotification);
				stringBuilder.AppendLine($"| {error.Property} | {error.Message} |");
			}
			return stringBuilder.ToString();
		}
	}
}

using System.Linq;
using System.Reflection;

namespace GyL.DDD.DotNet.Aplication.Util
{
	public static class Mapper
	{
		public static M Map<T, M>(T @object) where T : class, new() where M : class, new()
		{
			M objectMapped = new M();
			foreach (var item in @object.GetType().GetProperties())
			{
				PropertyInfo propertyInfo = objectMapped.GetType().GetProperties().FirstOrDefault(x => x.Name == item.Name);
				if (propertyInfo != null)
				{
					propertyInfo.SetValue(objectMapped, item.GetValue(@object));
				}
			}
			return objectMapped;
		}
	}
}

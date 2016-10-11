namespace XamLoc.FormsCore
{
    public class Developer
    {
        public string Name { get; set; }

        public string Country { get; set; }

		public string Description
		{
			get
			{
				if (string.IsNullOrEmpty(Name))
					return "";
				
				if (string.IsNullOrEmpty(Description))
					return "";


				return $"Developer "+Name+" from "+Description;
			}
		}
    }
}
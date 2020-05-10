namespace MovieDbLite.MVC.ViewModels
{
    public class AwardViewModel : AwardBase
    {
     
        public string FriendlyName
        {
            get
            {
                string detailName = AwardShowName == null ? "" : $"({AwardShowName})";
                return $"{AwardName} {detailName}";
            }
        }

        public string? AwardShowName { get; set; }
    }
}

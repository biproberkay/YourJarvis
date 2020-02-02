namespace YourJarvis.ApplicationCore.Entities.ArticleAggregate
{
    public class Rating
    {
        public int RatingId { get; set; }
        public double RatingScore { get; set; }

        //[ForeignKey("UserIDfk")]   
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string UserIDfk { get; set; }

        public int ArticleIDfk { get; set; }
        //[ForeignKey("ArticleIDfk")]   
        public virtual Article Article { get; set; }
    }
}

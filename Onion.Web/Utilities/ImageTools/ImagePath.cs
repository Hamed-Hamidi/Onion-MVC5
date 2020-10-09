using System.Web;

namespace Onion.Web.Utilities.ImageTools
{
    public class ImagePath
    {
        #region Slider

        public static string SliderOriginalPath = "/Content/images/Slider/Org/";
        public static string SliderOriginalServerPath = HttpContext.Current.Server.MapPath("/Content/images/Slider/Org/");

        public static string SliderThumbPath = "/Content/images/Slider/Thumb/";
        public static string SliderThumbServerPath = HttpContext.Current.Server.MapPath("/Content/images/Slider/Thumb/");

        #endregion

        #region Singer

        public static string SingerOriginalPath = "/Content/images/Singer/Org/";
        public static string SingerOriginalServerPath = HttpContext.Current.Server.MapPath("/Content/images/Singer/Org/");

        public static string SingerThumbPath = "/Content/images/Singer/Thumb/";
        public static string SingerThumbServerPath = HttpContext.Current.Server.MapPath("/Content/images/Singer/Thumb/");

        #endregion

        #region Song

        public static string SongOriginalPath = "/Content/images/Song/Org/";
        public static string SongOriginalServerPath = HttpContext.Current.Server.MapPath("/Content/images/Song/Org/");

        public static string SongThumbPath = "/Content/images/Song/Thumb/";
        public static string SongThumbServerPath = HttpContext.Current.Server.MapPath("/Content/images/Song/Thumb/");

        #endregion
    }
}
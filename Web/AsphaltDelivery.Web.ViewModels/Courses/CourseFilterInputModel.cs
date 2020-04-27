namespace AsphaltDelivery.Web.ViewModels.Courses
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AsphaltDelivery.Data.Models;

    public class CourseFilterInputModel
    {
        public CourseFilterInputModel()
        {
            this.Drivers = new HashSet<Driver>();
            this.Trucks = new HashSet<Truck>();
            this.Firms = new HashSet<Firm>();
            this.AsphaltBases = new HashSet<AsphaltBase>();
            this.AsphaltMixtures = new HashSet<AsphaltMixture>();
            this.RoadObjects = new HashSet<RoadObject>();
        }

        public int Id { get; set; }

        [Display(Name = "Filter courses from this datetime inclusive")]
        public string FilterFromDateTime { get; set; }

        [Display(Name = "Filter courses to this datetime inclusive")]
        public string FilterToDateTime { get; set; }

        [Display(Name = "Driver Full Name")]
        public int[] DriverIds { get; set; }

        [Display(Name = "Driver Full Names")]
        public string DriverFullNames { get; set; }

        public IEnumerable<Driver> Drivers { get; set; }

        [Display(Name = "Truck Registration Number")]
        public int[] TruckIds { get; set; }

        [Display(Name = "Truck Registration Numbers")]
        public string TruckRegistrationNumbers { get; set; }

        public IEnumerable<Truck> Trucks { get; set; }

        [Display(Name = "Firm Name")]
        public int[] FirmIds { get; set; }

        [Display(Name = "Firm Names")]
        public string FirmNames { get; set; }

        public IEnumerable<Firm> Firms { get; set; }

        [Display(Name = "Asphalt Base Name")]
        public int[] AsphaltBaseIds { get; set; }

        [Display(Name = "Asphalt Base Names")]
        public string AsphaltBaseNames { get; set; }

        public IEnumerable<AsphaltBase> AsphaltBases { get; set; }

        [Display(Name = "Asphalt Mixture Type")]
        public int[] AsphaltMixtureIds { get; set; }

        [Display(Name = "Asphalt Mixture Types")]
        public string AsphaltMixtureTypes { get; set; }

        public IEnumerable<AsphaltMixture> AsphaltMixtures { get; set; }

        [Display(Name = "Road Object Name")]
        public int[] RoadObjectIds { get; set; }

        [Display(Name = "Road Object Names")]
        public string RoadObjectNames { get; set; }

        public IEnumerable<RoadObject> RoadObjects { get; set; }

        public List<CoursesListingViewModel> FilteredCourses { get; set; }

        [Display(Name = "Total Weight By Distance in tkm")]
        public string TotalWeightByDistance { get; set; }
    }
}

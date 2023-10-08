namespace Owl.Overdrive.Business.DTOs.CompanyDtos.Display
{
    public class CompanySimpleDto
    {
        /// <summary>
        /// Company idetification.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// The name of the company.
        /// </summary>
        public string Name { get; set; } = null!;
    }
}

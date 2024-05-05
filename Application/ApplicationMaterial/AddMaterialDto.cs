using Domain.Entities;

namespace Application.ApplicationMaterial
{
    public class AddMaterialDto
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public double Thickness { get; set; }
        public string MaterialGrade { get; set; } = default!;
        public int Quantity { get; set; }
        public int StatusId { get; set; }
        public Guid LocationId { get; set; }
        public List<MaterialImage>? MaterialImage { get; set; } = default!;
    }
}

namespace Manga.MvcApp.UseCases.Register
{
    using System.ComponentModel.DataAnnotations;

    public sealed class RegisterRequest
    {
        [Required]
        [StringLength(100)]
        public string Personnummer { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public double InitialAmount { get; set; }
    }
}

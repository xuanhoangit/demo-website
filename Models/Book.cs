using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
// using System.Web.WebPages.Html;

namespace BookStoreApp.Models;
public class Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Isbn { get; set; }
    [Required]
    public int AuthorId { get; set; }
    [Required]
    public int GenreID { get; set; }
    [Required]
    public int PublisherID { get; set; }
    [NotMapped]
    public string? AuthorName{ get; set; }
    [NotMapped]
    public string? GenreName { get; set; }
    [NotMapped]
    public string? PublisherName { get; set; }
    // [NotMapped]
    // public List<SelectListItem> bookList { get; set; }
    [NotMapped]
    public List<SelectListItem>? authorList { get; set; }
    [NotMapped]
    public List<SelectListItem>? genreList { get; set; }
    [NotMapped]
    public List<SelectListItem>? publisherList { get; set; }
}
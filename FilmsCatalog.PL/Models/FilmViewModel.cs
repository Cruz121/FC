using System;
using System.ComponentModel.DataAnnotations;

namespace FilmsCatalog.PL.Models
{
    public class FilmViewModel
    {
        /// <summary>
        /// Идентификатор 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Год выпуска
        /// </summary>
        [Display(Name = "Год выпуска")]
        [Range(1800, 2100, ErrorMessage = "Введите корректную дату!")]
        public uint YearRelease { get; set; }

        /// <summary>
        /// Pежиссёр
        /// </summary>
        [Display(Name = "Pежиссёр")]
        public string MovieDirector { get; set; }

        /// <summary>
        /// Пользователь, который выложил информацию
        /// </summary>
        [Display(Name = "Выложил фильм")]
        public string UserPosted { get; set; }

        /// <summary>
        /// Постер
        /// </summary>
        [Display(Name = "Постер")]
        public byte[] Poster { get; set; }
    }
}

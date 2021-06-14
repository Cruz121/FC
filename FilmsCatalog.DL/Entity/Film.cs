namespace FilmsCatalog.DL.Entity
{
    public class Film
    {
        /// <summary>
        /// Идентификатор 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Год выпуска
        /// </summary>
        public uint YearRelease { get; set; }

        /// <summary>
        /// Pежиссёр
        /// </summary>
        public string MovieDirector { get; set; }

        /// <summary>
        /// Пользователь, который выложил информацию
        /// </summary>
        public string UserPosted { get; set; }

        /// <summary>
        /// Постер
        /// </summary>
        public byte[] Poster { get; set; }
    }
}

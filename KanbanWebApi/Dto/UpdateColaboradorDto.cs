﻿namespace KanbanWebApi.Dto
{
    public class UpdateColaboradorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Situacao { get; set; } = true;
        public string Linkedin { get; set; }
        public int CargoId { get; set; }
    }
}

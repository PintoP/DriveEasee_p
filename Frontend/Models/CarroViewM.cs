using System.ComponentModel;

namespace Frontend.Models
{
    public class CarroViewM
    {
        public int IdCarro { get; set; }
        [DisplayName("Matricula")]
        public string? Matricula { get; set; }
        public int? Tara { get; set; }
        public int? Lotacao { get; set; }
        public int EstadoCarroIdEstadoCarro { get; set; }
        public int CategoriaCarroIdCategoriaCarro { get; set; }
        public int ModeloIdModelo { get; set; }
    }
}
